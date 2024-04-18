using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechAPI.Domain;
using SpeechAPI.Services;

namespace SpeechAPI.Controllers
{
    [ApiController]
    [Route("api/texttospeech")]
    public class TextToSpeechController : ControllerBase
    {
        private readonly TextToSpeechService _textToSpeechService;

        public TextToSpeechController(TextToSpeechService textToSpeechService)
        {
            _textToSpeechService = textToSpeechService;
        }

        [HttpPost]
        public async Task<IActionResult> ConvertTextToSpeechAsync(TextDomain text)
        {
            var audioData = await _textToSpeechService.ConvertTextToSpeechAsync(text.Texto);
            return File(audioData, "audio/wav");
        }
    }
}
