using AiPD2.Models;

namespace AiPD2.Audio
{
    internal static class Windowing
    {
        public static void Apply(float[] frame, WindowType windowType)
        {
            Action<float[], int> windowFunc = windowType switch
            {
                WindowType.Rectangular => ApplyRectangular,
                WindowType.Triangular => ApplyTriangular,
                WindowType.Hamming => ApplyHamming,
                WindowType.Hanning => ApplyHanning,
                WindowType.Blackman => ApplyBlackman,
                _ => throw new ArgumentOutOfRangeException(nameof(windowType))
            };

            windowFunc(frame, frame.Length);
        }

        private static void ApplyRectangular(float[] frame, int n)
        {
            throw new NotImplementedException();
        }
        private static void ApplyTriangular(float[] frame, int n)
        {
            throw new NotImplementedException();
        }
        private static void ApplyHamming(float[] frame, int n)
        {
            throw new NotImplementedException();
        }
        private static void ApplyHanning(float[] frame, int n)
        {
            throw new NotImplementedException();
        }
        private static void ApplyBlackman(float[] frame, int n)
        {
            throw new NotImplementedException();
        }
    }
}
