namespace AiPD2.Audio.Windows
{
    internal class TriangularWindow : IWindow
    {
        public double[] Apply(double[] signal)
        {
            int n = signal.Length;

            double[] window = new double[n];
            for (int i = 0; i < n; i++)
            {
                double w = 1.0f - Math.Abs((i - (n - 1) / 2.0f) / ((n - 1) / 2.0f));
                window[i] = w;
            }

            double[] windowedFrame = new double[n];
            for (int i = 0; i < n; i++)
            {
                windowedFrame[i] = signal[i] * window[i];
            }

            return windowedFrame;
        }
    }
}
