using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AiPD2.Util
{
    internal static class AudioFileLoader
    {
        public static (float[] samples, int sampleRate, TimeSpan duration, string fileName) LoadWAVFile(string filePath)
        {

            using var reader = new AudioFileReader(filePath);

            ISampleProvider monoProvider = reader.WaveFormat.Channels switch
            {
                1 => reader,
                2 => new StereoToMonoSampleProvider(reader),
                _ => throw new NotSupportedException($"Nieobsługiwana liczba kanałów: {reader.WaveFormat.Channels}. Obsługiwane tylko mono lub stereo.")
            };

            int sampleRate = monoProvider.WaveFormat.SampleRate;
            TimeSpan duration = reader.TotalTime;
            string fileName = Path.GetFileName(filePath);

            int totalSamples = (int)(reader.Length / reader.WaveFormat.Channels / sizeof(float));
            float[] samples = new float[totalSamples];

            int samplesRead = monoProvider.Read(samples, 0, totalSamples);

            if (samplesRead < totalSamples)
            {
                throw new Exception("Przeczytano " + samplesRead + " próbek, oczekiwano " + totalSamples);
            }

            return (samples, sampleRate, duration, fileName);
        }
    }
}
