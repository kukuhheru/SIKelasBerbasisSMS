using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminSMS
{
    public partial class Login : Form
    {
        private Database database = new Database(@"Dsn=MySQLServer");
        private int kesempatan = 3;
        public Login()
        {
            InitializeComponent();
        }

        private bool cekLogin()
        {
            int jum = 0;
            jum = database.executeScalar("SELECT Count(*) FROM admin WHERE user_name='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "'");

            if (jum > 0)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cekLogin())
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                kesempatan--;
                lblKesempatan.Text = kesempatan.ToString();
                if (kesempatan > 0)
                    MessageBox.Show("Username dan Password tidak cocok.", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    MessageBox.Show("Maaf, anda telah gagal login sebanyak 3 kali. Program akan ditutup.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
