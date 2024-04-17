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

        public async Task<String> ConvertSpeechToTextAsync(byte[] audioData) {
        
            return await _speechRepository.SpeechToTextAsync(audioData);
        
        }
    }
}
