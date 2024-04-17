namespace SpeechAPI.Interfaces
{
    public interface ISpeechRepository
    {
        Task<byte[]> TextToSpeechAsync(string text);
        Task<string> SpeechToTextAsync(byte[] audioData);
    }
}
