using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace AdminSMS
{
    public partial class frmPembuat : Form
    {
        private String[] nama = new String[3];
        private String[] nim = new String[3];
        SoundPlayer a;
        private int i = 0;

        public frmPembuat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPembuat_Load(object sender, EventArgs e)
        {
            nama[0] = "Deta Pratama";
            nama[1] = "Kukuh Heru Irawan";
            nama[2] = "Adam Hendrabrata";

            nim[0] = "0710683001";
            nim[1] = "0710683017";
            nim[2] = "0710683040";

            a = new SoundPlayer(Application.StartupPath + "/DirikuDirinya.wav");
            a.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNama.Text  = nama[i];
            lblNim.Text = nim[i];
            i++;
            if (i > 2) i = 0;
        }

        private void frmPembuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            a.Stop();
            a.Dispose();
        }
    }
}
