namespace AiPD2.Audio
{
    internal static class FrameSplitter
    {
        public static double[][] SplitIntoFrames(double[] samples, int frameSize, int hopSize)
        {
            int numFrames = (int)Math.Ceiling((double)(samples.Length - frameSize) / hopSize) + 1;
            double[][] frames = new double[numFrames][];

            for (int i = 0; i < numFrames; i++)
            {
                int startIdx = i * hopSize;
                int samplesToCopy = Math.Min(frameSize, samples.Length - startIdx);

                frames[i] = new double[frameSize];
                Array.Copy(samples, startIdx, frames[i], 0, samplesToCopy);
            }

            return frames;
        }
    }
}
