using SpeechAPI.Interfaces;

namespace SpeechAPI.Services
{
    public class TextToSpeechService
    {
        private readonly ISpeechRepository _speechRepository;

        public TextToSpeechService(ISpeechRepository speechRepository)
        {
            _speechRepository = speechRepository;
        }

        public async Task<byte[]>ConvertTextToSpeechAsync(string text)
        {
            return await _speechRepository.TextToSpeechAsync(text);
        }

       
    }
}
