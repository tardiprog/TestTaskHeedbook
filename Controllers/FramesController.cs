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
    public class FrameController : ControllerBase
    {
        private FFmpeg _ffmpeg;
        private string workingPath = Environment.OSVersion.Platform == PlatformID.Win32NT ? ".\\" : "./";
        public FrameController(FFmpeg fFmpeg)
        {
            _ffmpeg = fFmpeg;

        }
        [HttpPost]
        public void GetFrames([FromBody]string path)
        {
            var fileName = path.Split("/").Last();
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            var dir = workingPath
                + "Frames"
                + Path.DirectorySeparatorChar;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            _ffmpeg.GetFrameFromVideo(path, dir + fileNameWithoutExt + "_%03d.jpg");

        }
    }
}
