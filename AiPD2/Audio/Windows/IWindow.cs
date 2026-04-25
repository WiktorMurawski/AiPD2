namespace AiPD2.Audio.Windows
{
    internal interface IWindow
    {
        double[] Apply(double[] signal);
        double[] GetCoefficients(int size) => Apply(Enumerable.Repeat(1.0, size).ToArray());
    }
}
