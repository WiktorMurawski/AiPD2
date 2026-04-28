namespace AiPD2.Audio
{
    internal static class CepstrumProcessor
    {
        public static double[] ComputeRealCepstrum(double[] frame)
        {
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(frame);

            System.Numerics.Complex[] logComplex = spectrum
                .Select(c => new System.Numerics.Complex(
                    Math.Log(c.Magnitude == 0 ? double.Epsilon : c.Magnitude), 0))
                .ToArray();

            FftSharp.FFT.Inverse(logComplex);

            return logComplex.Select(c => Math.Abs(c.Real)).ToArray();
        }

        public static double EstimateFundamentalFrequency(double[] cepstrum, double[] frame, int sampleRate, int frameSize, double energyThreshold = 0.001, int minHz = 50, int maxHz = 500)
        {
            double energy = frame.Select(s => s * s).Average();
            if (energy < energyThreshold)
                return 0;

            int tauMin = (int)Math.Ceiling((double)sampleRate / maxHz);
            int tauMax = (int)Math.Floor((double)sampleRate / minHz);
            tauMax = Math.Min(tauMax, cepstrum.Length - 1);

            int peakTau = tauMin;
            for (int tau = tauMin; tau <= tauMax; tau++)
            {
                if (cepstrum[tau] > cepstrum[peakTau])
                    peakTau = tau;
            }

            return (double)sampleRate / peakTau;
        }

        public static double[] MedianFilter(double[] values, int windowSize = 5)
        {
            double[] result = new double[values.Length];
            int half = windowSize / 2;

            for (int i = 0; i < values.Length; i++)
            {
                int start = Math.Max(0, i - half);
                int end = Math.Min(values.Length - 1, i + half);
                double[] window = values[start..(end + 1)];
                Array.Sort(window);
                result[i] = window[window.Length / 2];
            }

            return result;
        }
    }
}
