namespace AiPD2.Audio
{
    internal static class Preprocessor
    {
        public static float[] RemoveDCOffset(float[] samples)
        {
            float mean = samples.Average();
            return samples.Select(s => s - mean).ToArray();
        }

        public static float[] Normalize(float[] samples)
        {
            float peak = samples.Max(Math.Abs);
            if (peak == 0) return samples;
            return samples.Select(s => s / peak).ToArray();
        }
    }
}
