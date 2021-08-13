using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace friVideoCall
{
    public class RingBack
    {
        private AudioMediaPlayer player;
        private AudioMedia audioMedia;
        private bool isPlaying;
        private bool _disposed;
        private string wavFilePath;
        private object lockisPlaying;
        public RingBack(string wavPath)
        {
            wavFilePath = wavPath;
            player = new AudioMediaPlayer();
            audioMedia = Endpoint.instance().audDevManager().getPlaybackDevMedia();
            player.createPlayer(wavFilePath);
            lockisPlaying = new object();
            isPlaying = false;
        }

        public void ringStart()
        {
            lock (lockisPlaying)
            {
                if (isPlaying)
                    return;
                isPlaying = true;
            }
            //E:\Work\Person\pjproject_csharp\pjsua2_csharp_video_demo\audio

            //player.createPlayer(@"E:\Work\Person\pjproject_csharp\pjsua2_csharp_video_demo\audio\starting.wav");
           
            player.startTransmit(audioMedia);
        }
        public void ringStop()
        {
            lock (lockisPlaying)
            {
                if (isPlaying)
                {
                    player.stopTransmit(audioMedia);
                    isPlaying = false;
                }
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //标记gc不在调用析构函数
        }
        ~RingBack()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            lock (this)
            {
                if (_disposed) return; //如果已经被回收，就中断执行
                if (disposing)
                {
                    if (player != null)
                    {
                        player.Dispose();
                        player = null;
                    }
                    audioMedia.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
