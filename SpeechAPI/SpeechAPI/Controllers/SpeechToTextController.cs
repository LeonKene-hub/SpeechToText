using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> ConvertSpeechToTextAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await Request.Body.CopyToAsync(memoryStream);
                var audioData = memoryStream.ToArray();
                var text = await _speechToTextService.ConvertSpeechToTextAsync(audioData);
                return Ok(text);
            }
        }
    }
}

