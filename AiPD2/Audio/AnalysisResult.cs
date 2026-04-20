namespace AiPD2.Audio
{
    internal class AnalysisResult
    {
        public required float[] FullSignalSpectrum { get; init; }
        public required float[][] FrameLevelSpectra { get; init; }
        public required float[] Volume { get; init; }
        public required float[] FrequencyCentroid { get; init; }
        public required float[] EffectiveBandwidth { get; init; }
        public required float[][] BandEnergy { get; init; }        // [bandIndex][frameIndex]
        public required float[][] BandEnergyRatio { get; init; }   // [bandIndex][frameIndex]
        public required float[] SpectralFlatnessMeasure { get; init; }
        public required float[] SpectralCrestFactor { get; init; }
    }
}
