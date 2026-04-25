namespace AiPD2.Audio
{
    internal static class CepstrumProcessor
    {
        public static double[] ComputeRealCepstrum(double[] frame)
        {
            // Step 1: FFT
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(frame);

            // Step 2: log magnitude, wrapped as complex
            System.Numerics.Complex[] logComplex = spectrum
                .Select(c => new System.Numerics.Complex(
                    Math.Log(c.Magnitude == 0 ? double.Epsilon : c.Magnitude), 0))
                .ToArray();

            // Step 3: inverse FFT in-place
            FftSharp.FFT.Inverse(logComplex);

            // Step 4: absolute value of real part → real cepstrum
            return logComplex.Select(c => Math.Abs(c.Real)).ToArray();
        }

        public static double EstimateFundamentalFrequency(double[] cepstrum, double[] frame, int sampleRate, int frameSize, double energyThreshold = 0.001, int minHz = 50, int maxHz = 500)
        {
            double energy = frame.Select(s => s * s).Average();
            if (energy < energyThreshold)
                return 0;

            // τ must be > 0, and we look for the peak
            // Typical F0 range: 50 Hz–500 Hz → τ range: sampleRate/500 to sampleRate/50
            int tauMin = (int)Math.Ceiling((double)sampleRate / maxHz);
            int tauMax = (int)Math.Floor((double)sampleRate / minHz);
            tauMax = Math.Min(tauMax, cepstrum.Length - 1);

            int peakTau = tauMin;
            for (int tau = tauMin; tau <= tauMax; tau++)
            {
                if (cepstrum[tau] > cepstrum[peakTau])
                    peakTau = tau;
            }

            return (double)sampleRate / peakTau; // f0 = 1/τ_max
        }
    }
}
