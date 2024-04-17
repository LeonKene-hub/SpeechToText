using Microsoft.CognitiveServices.Speech.Audio;
using SpeechAPI.Interfaces;

namespace SpeechAPI.Services
{
    public class SpeechToTextService
    {
        private readonly ISpeechRepository _speechRepository;

        public SpeechToTextService(ISpeechRepository speechRepository)
        {
            _speechRepository = speechRepository;
        }

        public async Task<string> ConvertSpeechToTextAsync(byte[] audioDAta, AudioConfig audioConfig)
        {
            return await _speechRepository.SpeakToTextAsync(audioDAta, audioConfig);
        }
    }
}
