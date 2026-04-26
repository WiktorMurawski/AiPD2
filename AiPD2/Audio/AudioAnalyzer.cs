using AiPD2.Audio.Windows;
using AiPD2.Models;

namespace AiPD2.Audio
{
    internal static class AudioAnalyzer
    {
        public static AnalysisResult Analyze(Waveform waveform, AudioProcessingSettings settings)
        {
            // Preprocessing
            double[] processed = waveform.Samples;
            if (settings.RemoveDCOffset)
                processed = Preprocessor.RemoveDCOffset(processed);
            if (settings.Normalize)
                processed = Preprocessor.Normalize(processed);

            // Framing
            double[][] frames = FrameSplitter.SplitIntoFrames(processed, settings.FrameSize, settings.HopSize);

            // Padding
            processed = Preprocessor.PadToPowerOfTwo(processed);
            int paddedLength = processed.Length;

            // Windowing
            IWindow window = Windowing.CreateWindow(settings.WindowType);
            double[] windowedSignal = window.Apply(processed);
            processed = windowedSignal;
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i] = window.Apply(frames[i]);
            }
            double[] frameWindowCoefficients = window.GetCoefficients(settings.FrameSize);

            // FFT
            double[] fullSpectrum = FFTProcessor.ComputeSpectrum(processed);
            double[][] frameLevelSpectra = FFTProcessor.ComputeSpectra(frames);

            // Feature Extraction
            double[] volume = FeatureExtractor.ComputeVolume(frameLevelSpectra, settings.FrameSize);
            double[] frequencyCentroid = FeatureExtractor.ComputeFrequencyCentroid(frameLevelSpectra, waveform.SampleRate, settings.FrameSize);
            double[] effectiveBandwidth = FeatureExtractor.ComputeEffectiveBandwidth(frameLevelSpectra, waveform.SampleRate, settings.FrameSize, frequencyCentroid);
            double[][] bandEnergy = FeatureExtractor.ComputeBandEnergy(frameLevelSpectra, waveform.SampleRate, settings.FrameSize, frameWindowCoefficients);
            double[][] bandEnergyRatio = FeatureExtractor.ComputeBandEnergyRatio(bandEnergy);
            double[][] spectralFlatnessMeasure = FeatureExtractor.ComputeSpectralFlatnessMeasure(frameLevelSpectra, waveform.SampleRate, settings.FrameSize);
            double[][] spectralCrestFactor = FeatureExtractor.ComputeSpectralCrestFactor(frameLevelSpectra, waveform.SampleRate, settings.FrameSize);

            double[][] cepstrum = frames.Select(f => CepstrumProcessor.ComputeRealCepstrum(f)).ToArray();

            double[] rawF0 = cepstrum
                .Select((c, i) => CepstrumProcessor.EstimateFundamentalFrequency(c, frames[i], waveform.SampleRate, settings.FrameSize))
                .ToArray();

            double[] fundamentalFrequency = CepstrumProcessor.MedianFilter(rawF0);

            return new AnalysisResult
            {
                PaddedLength = paddedLength,
                WindowedWaveform = windowedSignal,
                FullSignalSpectrum = fullSpectrum,
                WindowedFrames = frames,
                FrameLevelSpectra = frameLevelSpectra,
                Volume = volume,
                FrequencyCentroid = frequencyCentroid,
                EffectiveBandwidth = effectiveBandwidth,
                BandEnergy = bandEnergy,
                BandEnergyRatio = bandEnergyRatio,
                SpectralFlatnessMeasure = spectralFlatnessMeasure,
                SpectralCrestFactor = spectralCrestFactor,
                FundamentalFrequency = fundamentalFrequency,
                Cepstrum = cepstrum,
            };
        }
    }
}
