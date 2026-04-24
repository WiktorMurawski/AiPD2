namespace AiPD2.Audio
{
    internal class AnalysisResult
    {
        public required double[] WindowedSignal { get; init; }
        public required double[] FullSignalSpectrum { get; init; }
        public required double[][] FrameLevelSpectra { get; init; }
        public required double[] Volume { get; init; }
        public required double[] FrequencyCentroid { get; init; }
        public required double[] EffectiveBandwidth { get; init; }
        public required double[][] BandEnergy { get; init; }        // [bandIndex][frameIndex]
        public required double[][] BandEnergyRatio { get; init; }   // [bandIndex][frameIndex]
        public required double[] SpectralFlatnessMeasure { get; init; }
        public required double[] SpectralCrestFactor { get; init; }
    }
}
