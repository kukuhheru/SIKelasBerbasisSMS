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
    public partial class Form1 : Form
    {
        private Database database = new Database(@"Dsn=MySQLServer");

        private string[] pengumuman = new string[3];
        private int pengumumanLoader = 0;
        private DateTime sekarang = new DateTime();
        private int jumlahSMSsekarang;
        private int jumlahUpdate,counter = 0;
        
        public Form1()
        {
            InitializeComponent();
            tampilJam();
            cekSMS();
            jumlahSMSsekarang = jumlahUpdate;
        }

        private void ambilDataSekarang()
        {
            DateTime a;
            int i = 0;
            database.executeReader("SELECT isi_pengumuman, b.nama_dosen, tanggal, jam FROM pengumuman a, dosen b WHERE a.no_hp = b.no_hp ORDER BY kode_pengumuman DESC LIMIT 3");
            while (database.reader.Read())
            {
                a = DateTime.Parse(database.reader.GetString(2));
                pengumuman[i] = "\"" + database.reader.GetString(0) + "\"" + "\ndari: " + database.reader.GetString(1) + " pada: " + a.ToLongDateString() + ", " + database.reader.GetString(3);
                i++;
            }
            database.reader.Close();
        }
        
        private void ambilDataSMS()
        {
            int i = 0;
            String nama="";
            lstPesanMasuk.Items.Clear();
            database.executeReader("SELECT b.nama_dosen, a.pesan, a.waktu_terima, no_pengirim, kode_sms FROM sms_masuk a LEFT JOIN dosen b ON a.no_pengirim = b.no_hp ORDER BY kode_sms DESC");
            while (database.reader.Read())
            {
                if (database.reader.IsDBNull(0))
                    nama = database.reader.GetString(3);
                else
                    nama = database.reader.GetString(0);

                lstPesanMasuk.Items.Add(nama, 0);
                lstPesanMasuk.Items[i].SubItems.Add(database.reader.GetString(1));
                lstPesanMasuk.Items[i].SubItems.Add(database.reader.GetDateTime(2).ToString());
                lstPesanMasuk.Items[i].SubItems.Add(database.reader.GetInt32(4).ToString());
                i++;
            }

            database.reader.Close();
        }
        
        private void cekSMS()
        {
            jumlahUpdate = database.executeScalar("SELECT Count(*) FROM sms_masuk");
        }

        private void updateSMS()
        {
            int baru = jumlahUpdate - jumlahSMSsekarang;
            String nama = "";

            database.executeReader("SELECT b.nama_dosen, a.pesan, a.waktu_terima, no_pengirim, kode_sms FROM sms_masuk a LEFT JOIN dosen b ON a.no_pengirim = b.no_hp ORDER BY kode_sms DESC LIMIT " + baru.ToString());
            while (database.reader.Read())
            {
                if (database.reader.IsDBNull(0))
                    nama = database.reader.GetString(3);
                else
                    nama = database.reader.GetString(0);

                lstPesanMasuk.Items.Insert(0,nama, 1);
                lstPesanMasuk.Items[0].SubItems.Add(database.reader.GetString(1));
                lstPesanMasuk.Items[0].SubItems.Add(database.reader.GetDateTime(2).ToString());
                lstPesanMasuk.Items[0].SubItems.Add(database.reader.GetInt32(4).ToString());
            }

            database.reader.Close();
        }
        
        private void hapusData()
        {
            string strSQL = "DELETE FROM sms_masuk WHERE kode_sms=" + lstPesanMasuk.SelectedItems[0].SubItems[3].Text;

            database.execute(strSQL);

            if (lstPesanMasuk.SelectedItems.Count > 0)
                lstPesanMasuk.Items.RemoveAt(lstPesanMasuk.SelectedItems[0].Index);
        }

        private void tampilJam()
        {
            String hh, mm, ss;
            sekarang = DateTime.Now;

            if (sekarang.Hour.ToString().Length > 1)
                hh = sekarang.Hour.ToString();
            else
                hh = "0" + sekarang.Hour.ToString();

            if (sekarang.Minute.ToString().Length > 1)
                mm = sekarang.Minute.ToString();
            else
                mm = "0" + sekarang.Minute.ToString();

            if (sekarang.Second.ToString().Length > 1)
                ss = sekarang.Second.ToString();
            else
                ss = "0" + sekarang.Second.ToString();

            lblJam.Text = hh + ":" + mm;
            lblDetik.Text = ss;
            txtTanggal.Text = sekarang.ToLongDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pengumuman[0] = "";
            pengumuman[1] = "";
            pengumuman[2] = "";

            ambilDataSekarang();
            ambilDataSMS();
            lblPengumuman.Text = pengumuman[0];
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tampilJam();

            counter++;
            if (counter > 6)
            {
                pengumumanLoader++;
                if (pengumumanLoader > 2) pengumumanLoader = 0;
                lblPengumuman.Text = pengumuman[pengumumanLoader];
                counter = 0;

                //Update sms dan pengumuman
                cekSMS();
                if (jumlahSMSsekarang < jumlahUpdate)
                {
                    ambilDataSekarang();
                    updateSMS();
                    jumlahSMSsekarang = jumlahUpdate;
                }
            }
        }

        private void pengumumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPengumuman fPengumuman = new frmPengumuman();
            fPengumuman.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChat fChat = new frmChat();
            fChat.ShowDialog();
        }

        private void lblPengumuman_Click(object sender, EventArgs e)
        {
            pengumumanToolStripMenuItem_Click(sender, e);
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPesanMasuk.SelectedItems.Count > 0)
            {
                hapusData();
                cekSMS();
                jumlahSMSsekarang = jumlahUpdate;
            }
        }

        private void masterMataKuliahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMataKuliah fMK = new frmMataKuliah();
            fMK.ShowDialog();
        }

        private void masterDosenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDosen fDosen = new frmDosen();
            fDosen.ShowDialog();
        }

        private void masterKelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJadwal fJadwal = new frmJadwal();
            fJadwal.ShowDialog();
        }

        private void pembuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPembuat fPembuat = new frmPembuat();
            fPembuat.ShowDialog();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            ambilDataSekarang();
        }

        private void lstPesanMasuk_DoubleClick(object sender, EventArgs e)
        {
            if (lstPesanMasuk.SelectedItems.Count > 0)
                MessageBox.Show("Pada: " + lstPesanMasuk.SelectedItems[0].SubItems[2].Text + "\n" + lstPesanMasuk.SelectedItems[0].SubItems[1].Text, "Dari: " + lstPesanMasuk.SelectedItems[0].Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
