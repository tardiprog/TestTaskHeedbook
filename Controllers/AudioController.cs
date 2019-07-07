using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestTaskHeedbook.Helper;

namespace TestTaskHeedbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private FFmpeg _ffmpeg;
        private string workingPath = Environment.OSVersion.Platform == PlatformID.Win32NT ? ".\\" : "./";
        public AudioController(FFmpeg fFmpeg)
        {
            _ffmpeg = fFmpeg;

        }
        [HttpPost]
        public void GetAudio([FromBody]string path)
        {
            var fileName = path.Split("/").Last();
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);           
            var dir = workingPath
                + "Audios"
                + Path.DirectorySeparatorChar;
            var pathToWav = dir + fileNameWithoutExtension + ".wav";
            _ffmpeg.GetAudioFromVideo(path, pathToWav);

        }
    }
}
