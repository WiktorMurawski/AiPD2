using AiPD2.Models;

namespace AiPD2.Audio
{
    internal class FrequencyBands
    {
        public static readonly FrequencyBand[] Bands =
{
            new(    0,   630, "ERSB1"),
            new(  630,  1720, "ERSB2"),
            new( 1720,  4400, "ERSB3"),
            new( 4400, 11025, "ERSB4"),
        };

    }
}
