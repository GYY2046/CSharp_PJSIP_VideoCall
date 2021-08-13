using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace friVideoCall
{
    public partial class VideoWindows : Form
    {
        Point pt;
        public VideoWindows()
        {
            InitializeComponent();
        }

        private void panelLocalVideo_MouseDown(object sender, MouseEventArgs e)
        {
            pt = Cursor.Position;
        }

        private void panelLocalVideo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int px = Cursor.Position.X - pt.X;
                int py = Cursor.Position.Y - pt.Y;
                var newPoint = new Point(panelLocalVideo.Location.X + px, panelLocalVideo.Location.Y + py);
                if (newPoint.X < 0 || newPoint.Y < 0)
                    return;
                if (newPoint.X + panelLocalVideo.Width > panelRemoteVideo.Width
                   || newPoint.Y + panelLocalVideo.Height > panelRemoteVideo.Height)
                    return;
                panelLocalVideo.Location = newPoint;
                pt = Cursor.Position;
            }
        }



    }
}
