using AiPD2.Audio;

namespace AiPD2.Models
{
    internal static class AudioAnalyzer
    {
        public static AnalysisResult Analyze(Waveform waveform, AudioProcessingSettings settings)
        {
            double[] processed = waveform.Samples;
            if (settings.RemoveDCOffset)
                processed = Preprocessor.RemoveDCOffset(processed);
            if (settings.Normalize)
                processed = Preprocessor.Normalize(processed);

            processed = Windowing.ApplyWindow(processed, settings.WindowType);
            double[] windowedSignal = processed;

            double[] padded = Preprocessor.PadToPowerOfTwo(processed);

            double[] fullSpectrum = FFTProcessor.ComputeSpectrum(padded);

            double[][] frames = FrameSplitter.SplitIntoFrames(processed, settings.FrameSize, settings.HopSize);
            double[][] frameLevelSpectra = FFTProcessor.ComputeSpectra(frames);

            return new AnalysisResult
            {
                WindowedSignal = windowedSignal,
                FullSignalSpectrum = fullSpectrum,
                FrameLevelSpectra = frameLevelSpectra,
                Volume = Array.Empty<double>(),
                FrequencyCentroid = Array.Empty<double>(),
                EffectiveBandwidth = Array.Empty<double>(),
                BandEnergy = Array.Empty<double[]>(),
                BandEnergyRatio = Array.Empty<double[]>(),
                SpectralFlatnessMeasure = Array.Empty<double>(),
                SpectralCrestFactor = Array.Empty<double>()
            };
        }
    }
}
