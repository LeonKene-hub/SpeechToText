using Microsoft.CognitiveServices.Speech.Audio;

namespace SpeechAPI.Interfaces
{
    public interface ISpeechRepository
    {
        Task<byte[]> TextToSpeechAsync(string text);
        Task<string> SpeakToTextAsync(byte[] audioData, AudioConfig audioConfig);
    }
}
