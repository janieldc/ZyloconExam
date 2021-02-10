using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ZyloconExam
{
    public partial class frmMain : Form
    {
        private static Timer _timer;
        private static Services _services;

        public frmMain()
        {
            InitializeComponent();
            OnInit();
        }

        private void OnInit()
        {
            _timer = new Timer();
            _timer.Enabled = true;
            _timer.Interval = 1000;
            _services = new Services();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Progress started.");
            _timer.Start();
            _timer.Tick += new EventHandler(timer_tick);
        }

        void timer_tick(object sender, EventArgs e)
        {
            if (prgBar.Value != prgBar.Maximum)
            {
                prgBar.Value++;
            }
            else
            {
                _timer.Stop();
                MessageBox.Show("Reached the maximum progress bar size.");
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to stop the progress?", "Progress stopping", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _timer.Stop();
                MessageBox.Show("Progress stopped.");
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _services.ScreenCapture(Form.ActiveForm, path);
            MessageBox.Show(String.Format("Screen captured. Image saved to {0}", path));
        }

    }
}
