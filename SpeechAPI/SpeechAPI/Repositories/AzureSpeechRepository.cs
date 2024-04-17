using SpeechAPI.Interfaces;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace SpeechAPI.Repositories
{
    public class AzureSpeechRepository : ISpeechRepository
    {
        private readonly SpeechConfig _speechConfig;

        public AzureSpeechRepository(IConfiguration configuration)
        {
            _speechConfig = SpeechConfig.FromSubscription(
                configuration["AzureSpeechSubscriptionKey"],
                configuration["AzureSpeechRegion"]
            );
        }

        public async Task<byte[]> TextToSpeechAsync(string text)
        {
            using (var synthesizer = new SpeechSynthesizer(_speechConfig))
            {
                var result = await synthesizer.SpeakTextAsync(text);
                return result.AudioData;
            }
        }

        public async Task<string> SpeakToTextAsync(byte[] audioData, AudioConfig audioConfig)
        {
            _speechConfig.SpeechRecognitionLanguage = "pt-BR";

            using (var recognizer = new SpeechRecognizer(_speechConfig, audioConfig))
            {
                var result = await recognizer.RecognizeOnceAsync();
                return result.Text;
            }
        }

    }
}
