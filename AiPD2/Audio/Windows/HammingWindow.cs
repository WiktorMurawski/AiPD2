namespace AiPD2.Audio.Windows
{
    internal class HammingWindow : IWindow
    {
        private readonly FftSharp.Windows.Hamming _window = new();
        public double[] Apply(double[] signal)
        {
            return _window.Apply(signal);
        }
    }
}
