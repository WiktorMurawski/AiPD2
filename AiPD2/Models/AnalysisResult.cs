namespace AiPD2.Models
{
    internal class AnalysisResult
    {
        public required int PaddedLength { get; init; }

        public required double[] WindowedWaveform { get; init; }
        public required double[] FullSignalSpectrum { get; init; }
        public required double[][] WindowedFrames { get; init; }
        public required double[][] FrameLevelSpectra { get; init; }
        public required double[] Volume { get; init; }
        public required double[] FrequencyCentroid { get; init; }
        public required double[] EffectiveBandwidth { get; init; }
        public required double[][] BandEnergy { get; init; }
        public required double[][] BandEnergyRatio { get; init; }
        public required double[][] SpectralFlatnessMeasure { get; init; }
        public required double[][] SpectralCrestFactor { get; init; }

        public required double[] FundamentalFrequency { get; init; }
        public required double[][] Cepstrum { get; init; }
    }
}
