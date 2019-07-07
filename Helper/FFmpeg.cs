using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskHeedbook.Helper
{
    public class FFmpeg
    {
        private string _ffmpegPath;
        public FFmpeg()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                _ffmpegPath = "ffmpeg.exe";
            }
            else
            {
                _ffmpegPath = "ffmpeg";
            }
        }

        public void GetAudioFromVideo(string pathToVideo, string pathToWav)
        {

            var ffmpeg = new Process
            {
                StartInfo = { UseShellExecute = false, RedirectStandardError = true, FileName = _ffmpegPath }
            };

            var arguments =
                    $"-i {pathToVideo} -vn -ar 44100 -ac 2 -ab 192K -f wav {pathToWav}";
            ffmpeg.StartInfo.Arguments = arguments;
            ffmpeg.Start();
            ffmpeg.WaitForExit();
        }


        public void GetFrameFromVideo(string pathToVideo, string pathToImg)
        {
            var ffmpeg = new Process
            {
                StartInfo = { UseShellExecute = false, RedirectStandardError = true, FileName = _ffmpegPath }
            };

            var arguments =
                    $"-i {pathToVideo} -vf fps=1/3 {pathToImg} -hide_banner";
            ffmpeg.StartInfo.Arguments = arguments;
            ffmpeg.Start();
            ffmpeg.WaitForExit();
        }
    }
}
