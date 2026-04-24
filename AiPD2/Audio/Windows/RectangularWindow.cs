namespace AiPD2.Audio.Windows
{
    internal class RectangularWindow : IWindow
    {
        private readonly FftSharp.Windows.Rectangular _window = new();
        public double[] Apply(double[] signal)
        {
            return _window.Apply(signal);
        }
    }
}
