namespace AiPD2.Models
{
    internal class FrequencyBand
    {
        public double LowHz { get; }
        public double HighHz { get; }
        public string Label { get; }

        public FrequencyBand(double lowHz, double highHz, string label)
        {
            LowHz = lowHz;
            HighHz = highHz;
            Label = label;
        }
    }
}
