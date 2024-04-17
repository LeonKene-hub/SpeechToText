using NAudio.Wave;
using System.IO;

namespace SpeechAPI.Services
{
    public class AudioConversionService 
    {
        public void ConvertToWav(string inputFilePath, string outputFilePath)
        {
            try
            {
                using (var reader = new AudioFileReader(inputFilePath))
                {
                    WaveFileWriter.CreateWaveFile(outputFilePath, reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao converter o arquivo para WAV: {ex.Message}");
            }
        }
    }
}
