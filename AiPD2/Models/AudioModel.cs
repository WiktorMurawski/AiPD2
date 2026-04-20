namespace AiPD1.Models
{
    internal class AudioModel
    {
        public List<float[]> Frames { get; private set; } = new List<float[]>();
        public int FrameCount => Frames.Count;

        //public Waveform Wave { get; private set; }

        public AudioModel(string filePath)
        {
            //Wave = new Waveform(filePath);
            DivideIntoFrames();
            CalculateParameters();
        }

        public void FrameSizeChanged()
        {
            DivideIntoFrames();
            CalculateParameters();
        }

        public void CalculateParameters()
        {
            // todo
        }

        private void DivideIntoFrames()
        {
            // todo
        }
    }
}
