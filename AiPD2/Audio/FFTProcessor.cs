namespace AiPD2.Audio
{
    internal static class FFTProcessor
    {
        public static double[] ComputeSpectrum(double[] samples)
        {
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(samples);

            double[] magnitudes = FftSharp.FFT.Magnitude(spectrum);

            return magnitudes;
        }

        public static double[][] ComputeSpectra(double[][] frames)
            => frames.Select(ComputeSpectrum).ToArray();
    }
}
