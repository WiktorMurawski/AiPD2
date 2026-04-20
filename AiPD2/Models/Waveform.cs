namespace AiPD2.Models
{
    internal class Waveform
    {
        public string FileName { get; private set; }
        public int SampleRate { get; private set; }
        public TimeSpan Duration { get; private set; }
        public float[] Samples { get; private set; }

        public Waveform(string filePath)
        {
            (Samples, SampleRate, Duration, FileName) = Util.AudioFileLoader.LoadWAVFile(filePath);
        }
    }
}
