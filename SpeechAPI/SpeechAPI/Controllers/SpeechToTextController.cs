using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;
using SpeechAPI.Services;

namespace SpeechAPI.Controllers
{
    [ApiController]
    [Route("api/speechtotext")]
    public class SpeechToTextController : ControllerBase
    {
        private readonly SpeechToTextService _speechToTextService;

        public SpeechToTextController(SpeechToTextService speechToTextService)
        {
            _speechToTextService = speechToTextService;

        }

        [HttpPost]
        public async Task<IActionResult> ConvertSpeechToTextAsync(IFormFile file)
        {
            if (file == null)
                return BadRequest("Arquivo vazio ou não recebido.");

            var _speechConfig = SpeechConfig.FromSubscription("", "brazilsouth");

            using var stream = file.OpenReadStream();

            var reader = new BinaryReader(stream);
            using var audioConfigStream = AudioInputStream.CreatePushStream();
            using var audioConfig = AudioConfig.FromStreamInput(audioConfigStream);

            var recognizer = new SpeechRecognizer(_speechConfig, "pt-BR", audioConfig);

            byte[] readBytes;
            do
            {
                readBytes = reader.ReadBytes(1024);
                audioConfigStream.Write(readBytes, readBytes.Length);
            } while (readBytes.Length > 0);

            var text = await recognizer.RecognizeOnceAsync();
            return Ok(text.Text);
        }
    }
}

