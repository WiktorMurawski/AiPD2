using AiPD2.Models;

namespace AiPD2.Audio
{
    internal static class FrameSplitter
    {
        public static float[][] SplitIntoFrames(float[] samples, AudioProcessingSettings settings)
        {
            int frameSize = settings.FrameSize;
            int hopSize = settings.HopSize;
            int numFrames = (int)Math.Ceiling((double)(samples.Length - frameSize) / hopSize) + 1;
            float[][] frames = new float[numFrames][];

            for (int i = 0; i < numFrames; i++)
            {
                int startIdx = i * hopSize;
                int samplesToCopy = Math.Min(frameSize, samples.Length - startIdx);

                frames[i] = new float[frameSize];
                Array.Copy(samples, startIdx, frames[i], 0, samplesToCopy);
            }

            return frames;
        }
    }
}
