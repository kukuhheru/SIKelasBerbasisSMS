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
    public partial class frmPengumuman : Form
    {
        private Database database = new Database(@"Dsn=MySQLServer");
        private int jumlahSMSsekarang, jumlahUpdate;

        public frmPengumuman()
        {
            InitializeComponent();
            cekData();
            jumlahSMSsekarang = jumlahUpdate;
        }

        private void cekData()
        {
            jumlahUpdate = database.executeScalar("SELECT Count(*) FROM pengumuman");
        }

        private void ambilDataSekarang()
        {
            lstPengumuman.Items.Clear();
            int i = 0;

            database.executeReader("SELECT kode_pengumuman, a.no_hp, b.nama_dosen, isi_pengumuman, tanggal, jam FROM pengumuman a, dosen b WHERE a.no_hp = b.no_hp GROUP BY kode_pengumuman");
            while (database.reader.Read())
            {
                lstPengumuman.Items.Add(database.reader.GetString(0), 0);
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(1));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(2));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(3));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(4));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(5));
                i++;
            }

            database.reader.Close();
        }

        private void updateDataAmbil(int nilai)
        {
            int i = lstPengumuman.Items.Count;
            if (nilai != 0)
                nilai = jumlahUpdate - jumlahSMSsekarang;
            else
                nilai = 1;

            database.executeReader("SELECT kode_pengumuman, a.no_hp, b.nama_dosen, isi_pengumuman, tanggal, jam FROM pengumuman a, dosen b WHERE (a.no_hp = b.no_hp) GROUP BY kode_pengumuman ORDER BY kode_pengumuman DESC LIMIT " + nilai.ToString());
            while (database.reader.Read())
            {
                lstPengumuman.Items.Add(database.reader.GetString(0), 0);
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(1));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(2));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(3));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(4));
                lstPengumuman.Items[i].SubItems.Add(database.reader.GetString(5));
                i++;
            }

            database.reader.Close();
        }

        private void updateData()
        {
            database.execute("UPDATE pengumuman SET isi_pengumuman='" + txtIsi.Text + "' WHERE kode_pengumuman=" + lblId.Text);
        }

        private void hapusData()
        {
            database.execute("DELETE FROM pengumuman WHERE kode_pengumuman=" + lblId.Text);
        }

        private void frmPengumuman_Load(object sender, EventArgs e)
        {
            ambilDataSekarang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblId.Text) > 0)
            {
                updateData();
                lstPengumuman.Items[Convert.ToInt32(lblIndex.Text)].SubItems[3].Text = txtIsi.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblId.Text) > 0)
            {
                hapusData();
                lstPengumuman.Items.RemoveAt(Convert.ToInt32(lblIndex.Text));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            database.execute("INSERT INTO pengumuman (isi_pengumuman, no_hp, tanggal, jam) VALUES('" + txtTambah.Text + "','Admin',CURDATE(),CURTIME())");
            updateDataAmbil(0);

            txtTambah.Clear();
            groupBox1.Visible = false;
            button3.Text = "Tambah";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible == false)
            {
                button3.Text = "Batal";
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
                button3.Text = "Tambah";
            }
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblId.Text) > 0)
            {
                hapusData();
                ambilDataSekarang();
            }
        }

        private void lstPengumuman_Click(object sender, EventArgs e)
        {
            if (lstPengumuman.SelectedItems.Count > 0)
            {
                txtIsi.Text = lstPengumuman.SelectedItems[0].SubItems[3].Text;
                lblNo.Text = lstPengumuman.SelectedItems[0].SubItems[1].Text;
                lblNama.Text = lstPengumuman.SelectedItems[0].SubItems[2].Text;
                lblId.Text = lstPengumuman.SelectedItems[0].Text;
                lblIndex.Text = lstPengumuman.SelectedItems[0].Index.ToString();
                button1.Enabled = true;
            }
        }


    }
}
