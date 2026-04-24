namespace AiPD2.Audio.Windows
{
    internal class HanningWindow : IWindow
    {
        private readonly FftSharp.Windows.Hanning _window = new();
        public double[] Apply(double[] signal)
        {
            return _window.Apply(signal);
        }
    }
}
