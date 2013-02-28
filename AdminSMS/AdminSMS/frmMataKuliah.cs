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
    public partial class frmMataKuliah : Form
    {
        private Database database = new Database(@"Dsn=MySQLServer");

        private void ambilDataSekarang()
        {
            lstMK.Items.Clear();
            int i = 0;
            database.executeReader("SELECT * FROM mata_kuliah");

            while (database.reader.Read())
            {
                lstMK.Items.Add(database.reader.GetString(0), 0);
                lstMK.Items[i].SubItems.Add(database.reader.GetString(1));
                lstMK.Items[i].SubItems.Add(database.reader.GetString(2));
                i++;
            }

            database.reader.Close();
        }

        private bool cekNamaMK()
        {
            int jumMK = 0;
            jumMK = database.executeScalar("SELECT Count(*) FROM mata_kuliah WHERE kode_mk='"+txtKodeMK.Text+"'");

            if (jumMK > 0) 
                return true; 
            else 
                return false;
        }

        private void tambahMK()
        {
            string strSQL = ""; 
            if (cekNamaMK())
                strSQL = "UPDATE mata_kuliah SET nama_mk = '" + txtNamaMK.Text + "', sks=" + txtJumSKS.Text + " WHERE kode_mk='" + txtKodeMK.Text + "'";
            else
                strSQL = "INSERT INTO mata_kuliah VALUES ('" + txtKodeMK.Text + "','" + txtNamaMK.Text + "', " + txtJumSKS.Text + ")";

            if (strSQL!="")
                database.execute(strSQL);

            ambilDataSekarang();
        }

        private void hapusData()
        {
            if (lstMK.SelectedItems.Count > 0)
            {
                database.execute("DELETE FROM mata_kuliah WHERE kode_mk='" + lstMK.SelectedItems[0].Text + "'");
                lstMK.Items.RemoveAt(Convert.ToInt32(lstMK.SelectedItems[0].Index));
            }
        }

        private void setEnable()
        {
            if (txtKodeMK.Text != "" && txtNamaMK.Text != "" && txtJumSKS.Text != "" && Convert.ToInt32(txtJumSKS.Text)>0 )
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        public frmMataKuliah()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMataKuliah_Load(object sender, EventArgs e)
        {
            ambilDataSekarang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tambahMK();
        }

        private void txtKodeMK_TextChanged(object sender, EventArgs e)
        {
            if (cekNamaMK())
            {
                button1.Text = "Update";
                txtKodeMK.BackColor = Color.Red;
                txtKodeMK.ForeColor = Color.White;
                txtKodeMK.Font = new Font("Trebuchet MS", 8, FontStyle.Bold);
            }
            else
            {
                button1.Text = "Tambah";
                txtKodeMK.BackColor = Color.White;
                txtKodeMK.ForeColor = Color.Black;
                txtKodeMK.Font = new Font("Trebuchet MS", 8, FontStyle.Regular);
            }
            setEnable();
        }

        private void txtJumSKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hapusData();
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hapusData();
        }

        private void lstMK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMK.SelectedItems.Count > 0)
            {
                setEnable();
                txtKodeMK.Text = lstMK.SelectedItems[0].Text;
                txtNamaMK.Text = lstMK.SelectedItems[0].SubItems[1].Text;
                txtJumSKS.Text = lstMK.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                txtKodeMK.Text = "";
                txtNamaMK.Text = "";
                txtJumSKS.Text = "";
            }
        }
    }
}
