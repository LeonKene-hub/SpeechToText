using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;

namespace SpeechAPI.Services
{
    public class AzureSpeechService
    {
        private readonly string _subscriptionKey;
        private readonly string _language;

        public AzureSpeechService(string subscriptionKey, string language)
        {
            _subscriptionKey = subscriptionKey;
            _language = language;
        }

        public async Task<string> TranscribeAudio(string audioFilePath)
        {
            var speechConfig = SpeechConfig.FromSubscription(_subscriptionKey, "brazilsouth");
            speechConfig.SpeechRecognitionLanguage = _language;

            using var audioInput = AudioConfig.FromWavFileInput(audioFilePath);

            using var recognizer = new SpeechRecognizer(speechConfig, audioInput);

            var result = await recognizer.RecognizeOnceAsync();

            return result.Text;
        }
    }
}
