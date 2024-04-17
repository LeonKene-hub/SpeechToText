using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechAPI.Services;
using System;
using System.IO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ConvertSpeechToTextAndSaveAsync(IFormFile audioFile)
        {
            if (audioFile == null || audioFile.Length == 0)
            {
                return BadRequest("Nenhum arquivo de áudio enviado.");
            }

            try
            {
                var uploadFolderPath = "audio/audiowav";

                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                if (Path.GetExtension(audioFile.FileName).ToLower() != ".wav")
                {
                    var tempFileName = Guid.NewGuid().ToString() + ".wav";
                    var tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName);

                    using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
                    {
                        await audioFile.CopyToAsync(fileStream);
                    }

                    // Usa o serviço de conversão para converter o arquivo para .wav
                    var audioConversionService = new AudioConversionService();
                    audioConversionService.ConvertToWav(tempFilePath, tempFilePath);

                    audioFile = new FormFile(new FileStream(tempFilePath, FileMode.Open), 0, new FileInfo(tempFilePath).Length, audioFile.Name, audioFile.FileName);
                }

                var audioFileName = Guid.NewGuid().ToString() + ".wav";
                var filePath = Path.Combine(uploadFolderPath, audioFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await audioFile.CopyToAsync(fileStream);
                }

                var azureSpeechService = new AzureSpeechService("70bef364dba34db7be1c23f2add497be", "pt-BR");
                var transcription = await azureSpeechService.TranscribeAudio(filePath);

                return Ok($"Transcrição do áudio: {transcription}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao salvar o arquivo de áudio: {ex.Message}");
            }
        }

    }
}
