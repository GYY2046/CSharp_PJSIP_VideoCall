using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
{
    public class RingBack
    {
        private AudioMediaPlayer player;
        private AudioMedia audioMedia;
        private bool isPlaying;
        private bool _disposed;
        public RingBack()
        {
            player = new AudioMediaPlayer();
            audioMedia = Endpoint.instance().audDevManager().getPlaybackDevMedia();
            isPlaying = false;
        }

        public void ringStart()
        {
            if (isPlaying)
                return;
            isPlaying = true;
            //E:\Work\Person\pjproject_csharp\pjsua2_csharp_video_demo\audio
            player.createPlayer(@"E:\Work\Person\pjproject_csharp\pjsua2_csharp_video_demo\audio\starting.wav");
            player.startTransmit(audioMedia);
        }
        public void ringStop()
        {
            if (isPlaying)
            {
                player.stopTransmit(audioMedia);
                isPlaying = false;
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
            if (_disposed) return; //如果已经被回收，就中断执行
            if (disposing)
            {
                player.Dispose();
                audioMedia.Dispose();
            }
            _disposed = true;
        }
    }
}
