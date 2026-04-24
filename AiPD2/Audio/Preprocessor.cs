namespace AiPD2.Audio
{
    internal static class Preprocessor
    {
        public static double[] RemoveDCOffset(double[] samples)
        {
            double mean = samples.Average();
            return samples.Select(s => s - mean).ToArray();
        }

        public static double[] Normalize(double[] samples)
        {
            double peak = samples.Max(Math.Abs);
            if (peak == 0) return samples;
            return samples.Select(s => s / peak).ToArray();
        }

        public static double[] PadToPowerOfTwo(double[] samples)
        {
            int nextPow2 = (int)Math.Pow(2, Math.Ceiling(Math.Log2(samples.Length)));
            if (nextPow2 == samples.Length) return samples;

            double[] padded = new double[nextPow2];
            Array.Copy(samples, padded, samples.Length);

            return padded;
        }
    }
}
