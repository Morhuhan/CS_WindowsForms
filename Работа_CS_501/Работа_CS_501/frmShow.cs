using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;


namespace Работа_CS_501
{
    public partial class frmShow : Form
    {
        //DllImportAttribute attribute = new DllImportAttribute("user32");
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(
            IntPtr hWndm, uint Msg, uint WParam, uint Lparam);

        const uint WN_SYSCOMMAND = 0x0112;
        const uint SC_MOVE = 0xF012;

        public string msg { get; set; }

        public frmShow()
        {
            InitializeComponent();
        }

        private void frmShow_Load(object sender, EventArgs e)
        {

        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            if (Opacity < 0.01)
            {
                tmrClose.Enabled = false;
                Close();
            }
            Opacity -= 0.02;
            if (tmrClose.Interval > 1000)
            {
                tmrClose.Interval = 10;
            }
        }

        private void frmShow_Paint(object sender, PaintEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter;

            //TextBoxRenderer.DrawTextBox(e.Graphics, new Rectangle(0, 0, Width, Height), msg, Font, flags, TextBoxState.Normal);

            tmrClose.Enabled = true;
        }

        private void frmShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                tmrClose.Enabled = false;
                Close();
            }
        }

        private void frmShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Capture = false;
                PostMessage(Handle, WN_SYSCOMMAND, SC_MOVE, 0);
            }
        }
    }
}
