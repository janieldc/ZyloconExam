using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZyloconExam
{
    public class Services
    {
        public void ScreenCapture(Form frm, string path)
        {
            using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));

                bmp.Save(path + "\\" + "ZyloconScreenCapTest-JanielDelaCruz.png", ImageFormat.Png);
            }
        }
    }
}
