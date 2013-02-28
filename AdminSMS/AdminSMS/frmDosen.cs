using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace AdminSMS
{
    public partial class frmDosen : Form
    {
        private Database database = new Database(@"Dsn=MySQLServer");

        private void ambilDataSekarang()
        {
            lstDosen.Items.Clear();
            int i = 0;
            database.executeReader("SELECT * FROM dosen");

            while (database.reader.Read())
            {
                lstDosen.Items.Add(database.reader.GetString(0), 0);
                lstDosen.Items[i].SubItems.Add(database.reader.GetString(1));
                lstDosen.Items[i].SubItems.Add(database.reader.GetString(2));
                i++;
            }

            database.reader.Close();
        }

        private bool cekNIP()
        {
            int jumNIP = 0;
            jumNIP = database.executeScalar("SELECT Count(*) FROM dosen WHERE nip_dosen='" + txtNIP.Text + "'");

            if (jumNIP > 0)
                return true;
            else
                return false;
        }

        private void tambahDosen()
        {
            string strSQL = "";
            if (cekNIP())
                strSQL = "UPDATE dosen SET nama_dosen='" + txtNama.Text + "', no_hp='" + txtNoHp.Text + "' WHERE nip_dosen='" + txtNIP.Text + "'";
            else
                strSQL = "INSERT INTO dosen VALUES ('" + txtNIP.Text + "','" + txtNama.Text + "', '" + txtNoHp.Text + "')";

            if (strSQL != "")
                database.execute(strSQL);
            
            ambilDataSekarang();
        }

        private void hapusData()
        {
            if (lstDosen.SelectedItems.Count > 0)
            {
                database.execute("DELETE FROM dosen WHERE nip_dosen='" + lstDosen.SelectedItems[0].Text + "'");
                lstDosen.Items.RemoveAt(Convert.ToInt32(lstDosen.SelectedItems[0].Index));
            }
        }

        private void setEnable()
        {
            if (txtNIP.Text != "" && txtNama.Text != "" && txtNoHp.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        public frmDosen()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDosen_Load(object sender, EventArgs e)
        {
            ambilDataSekarang();
        }

        private void txtNIP_TextChanged(object sender, EventArgs e)
        {
            if (cekNIP())
            {
                button1.Text = "Update";
                txtNIP.BackColor = Color.Red;
                txtNIP.ForeColor = Color.White;
                txtNIP.Font = new Font("Trebuchet MS", 8, FontStyle.Bold);
            }
            else
            {
                button1.Text = "Tambah";
                txtNIP.BackColor = Color.White;
                txtNIP.ForeColor = Color.Black;
                txtNIP.Font = new Font("Trebuchet MS", 8, FontStyle.Regular);
            }
            setEnable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tambahDosen();
        }

        private void lstDosen_Click(object sender, EventArgs e)
        {
            if (lstDosen.SelectedItems.Count > 0)
            {
                setEnable();
                txtNIP.Text = lstDosen.SelectedItems[0].Text;
                txtNama.Text = lstDosen.SelectedItems[0].SubItems[1].Text;
                txtNoHp.Text = lstDosen.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                txtNIP.Text = "";
                txtNama.Text = "";
                txtNoHp.Text = "";
            }
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hapusData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hapusData();
        }
    }
}
