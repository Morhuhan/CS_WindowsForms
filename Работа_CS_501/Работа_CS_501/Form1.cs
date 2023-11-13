using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Работа_CS_501
{
    public partial class frmMain : Form
    {
        private frmShow showForm;

        public frmMain()
        {
            InitializeComponent();
        }

        private void FrmName_Load(object sender, EventArgs e)
        {

            //showForm.Show();
            //showForm.BringToFront();
            //BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showForm = new frmShow();
            showForm.msg = ("Message");
            showForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dialogue dlg = new Dialogue();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                lblText.Text = dlg.msg;
            }
            else
            {
                lblText.Text = "Отменено пользоавтелем";
            }
        }
    }
}
