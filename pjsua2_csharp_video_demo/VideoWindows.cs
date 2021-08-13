using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjsua2_csharp_video_demo
{
    public partial class VideoWindows : Form
    {
        Point pt;
        public VideoWindows()
        {
            InitializeComponent();
        }

        private void panelLocal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLocal_MouseDown(object sender, MouseEventArgs e)
        {
            pt = Cursor.Position;
        }

        private void panelLocal_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int px = Cursor.Position.X - pt.X;
                int py = Cursor.Position.Y - pt.Y;
                panelLocal.Location = new Point(panelLocal.Location.X + px, panelLocal.Location.Y + py);

                pt = Cursor.Position;
            }
        }
    }
}
