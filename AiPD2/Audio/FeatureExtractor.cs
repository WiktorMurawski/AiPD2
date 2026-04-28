namespace AiPD2.Audio
{
    internal static class FeatureExtractor
    {
        public static double[] ComputeVolume(double[][] spectra, int frameSize)
        {
            int numFrames = spectra.Length;
            double[] volume = new double[numFrames];

            for (int n = 0; n < numFrames; n++)
            {
                double sum = 0;
                for (int k = 0; k < spectra[n].Length; k++)
                    sum += spectra[n][k] * spectra[n][k];

                volume[n] = sum / frameSize;
            }

            return volume;
        }

        public static double[] ComputeFrequencyCentroid(double[][] spectra, int sampleRate, int frameSize)
        {
            double[] centroids = new double[spectra.Length];
            double frequencyResolution = (double)sampleRate / frameSize;

            for (int n = 0; n < spectra.Length; n++)
            {
                double weightedSum = 0;
                double magnitudeSum = 0;

                for (int k = 0; k < spectra[n].Length; k++)
                {
                    double frequency = k * frequencyResolution;
                    weightedSum += frequency * spectra[n][k];
                    magnitudeSum += spectra[n][k];
                }

                centroids[n] = magnitudeSum == 0 ? 0 : weightedSum / magnitudeSum;
            }

            return centroids;
        }

        public static double[] ComputeEffectiveBandwidth(double[][] spectra, int sampleRate, int frameSize, double[] frequencyCentroids)
        {
            double[] bandwidths = new double[spectra.Length];
            double frequencyResolution = (double)sampleRate / frameSize;

            for (int n = 0; n < spectra.Length; n++)
            {
                double weightedSum = 0;
                double magnitudeSum = 0;

                for (int k = 0; k < spectra[n].Length; k++)
                {
                    double frequency = k * frequencyResolution;
                    double magnitudeSquared = spectra[n][k] * spectra[n][k];
                    double deviation = frequency - frequencyCentroids[n];

                    weightedSum += deviation * deviation * magnitudeSquared;
                    magnitudeSum += magnitudeSquared;
                }

                bandwidths[n] = magnitudeSum == 0 ? 0 : Math.Sqrt(weightedSum / magnitudeSum);
            }

            return bandwidths;
        }

        public static double[][] ComputeBandEnergy(double[][] spectra, int sampleRate, int frameSize, double[] windowCoefficients)
        {
            double windowSum = windowCoefficients.Sum();
            double frequencyResolution = (double)sampleRate / frameSize;
            double[][] bandEnergy = new double[FrequencyBands.Bands.Length][];

            for (int b = 0; b < FrequencyBands.Bands.Length; b++)
            {
                int kMin = (int)Math.Floor(FrequencyBands.Bands[b].LowHz / frequencyResolution);
                int kMax = (int)Math.Ceiling(FrequencyBands.Bands[b].HighHz / frequencyResolution);
                kMax = Math.Min(kMax, spectra[0].Length - 1);

                bandEnergy[b] = new double[spectra.Length];

                for (int n = 0; n < spectra.Length; n++)
                {
                    double sum = 0;
                    for (int k = kMin; k <= kMax; k++)
                        sum += spectra[n][k] * spectra[n][k];

                    bandEnergy[b][n] = sum / windowSum;
                }
            }

            return bandEnergy;
        }

        public static double[][] ComputeBandEnergyRatio(double[][] bandEnergy)
        {
            int numBands = bandEnergy.Length;
            int numFrames = bandEnergy[0].Length;
            double[][] ratio = new double[numBands][];

            for (int b = 0; b < numBands; b++)
                ratio[b] = new double[numFrames];

            for (int n = 0; n < numFrames; n++)
            {
                double totalEnergy = 0;
                for (int b = 0; b < numBands; b++)
                    totalEnergy += bandEnergy[b][n];

                for (int b = 0; b < numBands; b++)
                    ratio[b][n] = totalEnergy == 0 ? 0 : bandEnergy[b][n] / totalEnergy;
            }

            return ratio;
        }

        public static double[][] ComputeSpectralFlatnessMeasure(double[][] spectra, int sampleRate, int frameSize)
        {
            double[][] sfm = new double[FrequencyBands.Bands.Length][];
            double frequencyResolution = (double)sampleRate / frameSize;

            for (int b = 0; b < FrequencyBands.Bands.Length; b++)
            {
                int kMin = (int)Math.Floor(FrequencyBands.Bands[b].LowHz / frequencyResolution);
                int kMax = (int)Math.Ceiling(FrequencyBands.Bands[b].HighHz / frequencyResolution);
                kMax = Math.Min(kMax, spectra[0].Length - 1);
                int bandLength = kMax - kMin + 1;

                sfm[b] = new double[spectra.Length];

                for (int n = 0; n < spectra.Length; n++)
                {
                    double arithmeticMean = 0;
                    double logSum = 0;

                    for (int k = kMin; k <= kMax; k++)
                    {
                        double power = spectra[n][k] * spectra[n][k];
                        arithmeticMean += power;
                        logSum += Math.Log(power == 0 ? double.Epsilon : power);
                    }

                    arithmeticMean /= bandLength;

                    if (arithmeticMean == 0)
                    {
                        sfm[b][n] = 1;
                        continue;
                    }

                    double geometricMean = Math.Exp(logSum / bandLength);
                    sfm[b][n] = geometricMean / arithmeticMean;
                }
            }

            return sfm;
        }

        public static double[][] ComputeSpectralCrestFactor(double[][] spectra, int sampleRate, int frameSize)
        {
            double[][] scf = new double[FrequencyBands.Bands.Length][];
            double frequencyResolution = (double)sampleRate / frameSize;

            for (int b = 0; b < FrequencyBands.Bands.Length; b++)
            {
                int kMin = (int)Math.Floor(FrequencyBands.Bands[b].LowHz / frequencyResolution);
                int kMax = (int)Math.Ceiling(FrequencyBands.Bands[b].HighHz / frequencyResolution);
                kMax = Math.Min(kMax, spectra[0].Length - 1);
                int bandLength = kMax - kMin + 1;

                scf[b] = new double[spectra.Length];

                for (int n = 0; n < spectra.Length; n++)
                {
                    double max = 0;
                    double arithmeticMean = 0;

                    for (int k = kMin; k <= kMax; k++)
                    {
                        double power = spectra[n][k] * spectra[n][k];
                        arithmeticMean += power;
                        if (power > max) max = power;
                    }

                    arithmeticMean /= bandLength;

                    scf[b][n] = arithmeticMean == 0 ? 1 : max / arithmeticMean;
                }
            }

            return scf;
        }
    }
}
