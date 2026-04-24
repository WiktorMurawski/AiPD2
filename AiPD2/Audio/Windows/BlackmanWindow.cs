namespace AiPD2.Audio.Windows
{
    internal class BlackmanWindow : IWindow
    {
        private readonly FftSharp.Windows.Blackman _window = new();
        public double[] Apply(double[] signal)
        {
            return _window.Apply(signal);
        }
    }
}
