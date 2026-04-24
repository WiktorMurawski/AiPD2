using AiPD2.Models;

namespace AiPD2.Audio
{
    internal static class Windowing
    {
        private static Windows.IWindow CreateWindow(WindowType windowType) => windowType switch
        {
            WindowType.Rectangular => new Windows.RectangularWindow(),
            WindowType.Hamming => new Windows.HammingWindow(),
            WindowType.Hanning => new Windows.HanningWindow(),
            WindowType.Blackman => new Windows.BlackmanWindow(),
            WindowType.Triangular => new Windows.TriangularWindow(),
            _ => throw new ArgumentOutOfRangeException(nameof(windowType), $"No implementation for {windowType}.")
        };

        public static double[] ApplyWindow(double[] frame, WindowType windowType)
        {
            Windows.IWindow window = CreateWindow(windowType);
            return window.Apply(frame);
        }
    }
}
