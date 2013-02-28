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
    public partial class frmJadwal : Form
    {
        private Database database = new Database(@"Dsn=MySQLServer");

        private void ambilDataRuang()
        {
            lstRuang.Items.Clear();
            cmbRuang.Items.Clear();
            int i = 0;

            database.executeReader("SELECT * FROM ruang");
            while (database.reader.Read())
            {
                lstRuang.Items.Add(database.reader.GetString(0), 0);
                lstRuang.Items[i].SubItems.Add(database.reader.GetString(1));
                cmbRuang.Items.Add(database.reader.GetString(0));
                i++;
            }

            database.reader.Close();
            cmbRuang.SelectedIndex = 0;
        }

        private bool cekKodeRuang()
        {
            int jum = 0;
            jum = database.executeScalar("SELECT Count(*) FROM ruang WHERE kode_ruang='" + txtKodeRuang.Text + "'");

            if (jum > 0)
                return true;
            else
                return false;
        }

        private void tambahRuang()
        {
            string strSQL = "";
            if (cekKodeRuang())
                strSQL = "UPDATE ruang SET keterangan='" + txtKeteranganRuang.Text + "' WHERE kode_ruang='" + txtKodeRuang.Text + "'";
            else
                strSQL = "INSERT INTO ruang VALUES ('" + txtKodeRuang.Text + "','" + txtKeteranganRuang.Text + "')";

            if (strSQL != "")
                database.execute(strSQL);
            ambilDataRuang();
        }

        private void setEnableRuang()
        {
            if (txtKodeRuang.Text != "" && txtKeteranganRuang.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void ambilDataKelas()
        {
            lstKelas.Items.Clear();
            cmbKelas.Items.Clear();
            int i = 0;

            database.executeReader("SELECT * FROM kelas");
            while (database.reader.Read())
            {
                lstKelas.Items.Add(database.reader.GetString(0), 0);
                lstKelas.Items[i].SubItems.Add(database.reader.GetString(1));
                cmbKelas.Items.Add(database.reader.GetString(0));
                i++;
            }

            database.reader.Close();
            cmbKelas.SelectedIndex = 0;
        }

        private bool cekKodeKelas()
        {
            int jum = 0;
            jum = database.executeScalar("SELECT Count(*) FROM kelas WHERE kode_kelas='" + txtKodeKelas.Text + "'");

            if (jum > 0)
                return true;
            else
                return false;
        }

        private void tambahKelas()
        {
            string strSQL = "";
            if (cekKodeKelas())
                strSQL = "UPDATE kelas SET keterangan='" + txtKeteranganKelas.Text + "' WHERE kode_kelas='" + txtKodeKelas.Text + "'";
            else
                strSQL = "INSERT INTO kelas VALUES ('" + txtKodeKelas.Text + "','" + txtKeteranganKelas.Text + "')";

            if (strSQL != "")
                database.execute(strSQL);

            ambilDataKelas();
        }

        private void setEnableKelas()
        {
            if (txtKodeKelas.Text != "" && txtKeteranganKelas.Text != "")
                button4.Enabled = true;
            else
                button4.Enabled = false;
        }

        //memasukkan data dosen
        private void input_dosen()
        {
            cmbDosen.Items.Clear();
            database.executeReader("SELECT * FROM dosen");
            while (database.reader.Read())
            {
                cmbDosen.Items.Add(database.reader.GetString(0) + "--" + database.reader.GetString(1));
            }

            database.reader.Close();
            cmbDosen.SelectedIndex = 0;
        }

        //memasukkan data mata kuliah
        private void input_matkul()
        {
            cmbMataKuliah.Items.Clear();
            database.executeReader("SELECT * FROM mata_kuliah");
            while (database.reader.Read())
            {
                cmbMataKuliah.Items.Add(database.reader.GetString(0) + "--" + database.reader.GetString(1));
            }

            database.reader.Close();
            cmbMataKuliah.SelectedIndex = 0;
        }

        private void hapusRuang()
        {
            if (lstRuang.SelectedItems.Count > 0)
            {
                database.execute("DELETE FROM ruang WHERE kode_ruang='" + lstRuang.SelectedItems[0].Text + "'");
                lstRuang.Items.RemoveAt(Convert.ToInt32(lstRuang.SelectedItems[0].Index));
            }
        }

        private void hapusKelas()
        {
            if (lstKelas.SelectedItems.Count > 0)
            {
                database.execute("DELETE FROM kelas WHERE kode_kelas='" + lstKelas.SelectedItems[0].Text + "'");
                lstKelas.Items.RemoveAt(Convert.ToInt32(lstKelas.SelectedItems[0].Index));
            }
        }

        private String getHari(int kode_hari)
        {
            String hari="";
            switch (kode_hari)
            {
                case 0: hari = "Senin"; break;
                case 1: hari = "Selasa"; break;
                case 2: hari = "Rabu"; break;
                case 3: hari = "Kamis"; break;
                case 4: hari = "Jumat"; break;
                case 5: hari = "Sabtu"; break;
                default: hari = "Minggu"; break;
            }
            return hari;
        }

        private void ambilDataJadwal()
        {
            lstJadwal.Items.Clear();
            int i = 0;
            database.executeReader("SELECT kode_jadwal, kode_hari, waktu_mulai, waktu_akhir, b.nama_mk, c.nama_dosen, kode_kelas, kode_ruang FROM jadwal a, mata_kuliah b, dosen c WHERE a.kode_mk = b.kode_mk AND a.nip_dosen = c.nip_dosen");

            while (database.reader.Read())
            {
                lstJadwal.Items.Add(database.reader.GetInt32(0).ToString());
                lstJadwal.Items[i].SubItems.Add(getHari(database.reader.GetInt32(1)));
                lstJadwal.Items[i].SubItems.Add(database.reader.GetString(2));
                lstJadwal.Items[i].SubItems.Add(database.reader.GetString(3));
                lstJadwal.Items[i].SubItems.Add(database.reader.GetString(4));
                lstJadwal.Items[i].SubItems.Add(database.reader.GetString(5));
                lstJadwal.Items[i].SubItems.Add(database.reader.GetString(6));
                lstJadwal.Items[i].SubItems.Add(database.reader.GetString(7));
                i++;
            }

            database.reader.Close();
        }

        private void tambahJadwal()
        {
            String[] selektor;
            String kode_hari="0";
            String kode_mk = "";
            String nip_dosen = "";
            String kode_ruang = cmbRuang.Text ;
            String kode_kelas = cmbKelas.Text ;
            String strSQL;

            switch(cmbHari.Text){
                case "Senin": kode_hari="0";break;
                case "Selasa": kode_hari="1";break;
                case "Rabu": kode_hari="2";break;
                case "Kamis": kode_hari="3";break;
                case "Jumat": kode_hari="4";break;
                case "Sabtu": kode_hari="5";break;
                default: kode_hari="6";break;
            }

            selektor = cmbMataKuliah.Text.Split('-');
            kode_mk = selektor[0];
            selektor = cmbDosen.Text.Split('-');
            nip_dosen = selektor[0];

            //Masukkan data
            if (lblId.Text == "")
            {
                strSQL = "INSERT INTO jadwal (kode_mk,kode_kelas,kode_ruang,kode_hari,nip_dosen,waktu_mulai,waktu_akhir) VALUES (" +
                         "'" + kode_mk + "','" + kode_kelas + "','" + kode_ruang + "'," + kode_hari + ",'" + nip_dosen + "','" + txtWaktuMulai.Text + "','" + txtWaktuAkhir.Text + "')";

                if (bentrokDosen(nip_dosen, kode_hari, txtWaktuMulai.Text))
                {
                    MessageBox.Show("Dosen juga mengajar pada jam ini", "Bentrok Dosen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (bentrokRuang(kode_ruang, kode_hari, txtWaktuMulai.Text))
                {
                    MessageBox.Show("Ruang " + kode_ruang + " telah dipakai pada pukul " + txtWaktuMulai.Text, "Bentrok Ruang", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (bentrokKelas(kode_kelas, kode_hari, txtWaktuMulai.Text))
                {
                    MessageBox.Show("Kelas " + kode_kelas + " juga kuliah pada jam ini", "Bentrok Kelas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (strSQL != "")
                        database.execute(strSQL);
                    ambilDataJadwal();
                }
            }
            else
            {
                strSQL = "UPDATE jadwal SET kode_mk='" + kode_mk + "', kode_kelas='" + kode_kelas + "', kode_ruang='" + kode_ruang + "', kode_hari=" + kode_hari + ", nip_dosen='" + nip_dosen + "', waktu='" + txtWaktuMulai.Text + "' WHERE kode_jadwal=" + lblId.Text;
                button5.Text = "Tambah";
                if (strSQL != "")
                    database.execute(strSQL);

                ambilDataJadwal();
            }

        }

        private String getKodeMK(String id)
        {
            String hasil = "";
            database.executeReader("SELECT kode_mk FROM jadwal WHERE kode_jadwal=" + id);

            while (database.reader.Read())
            {
                hasil = database.reader.GetString(0);
            }

            database.reader.Close();
            return hasil;
        }

        private String getNip(String id)
        {
            String hasil = "";
            database.executeReader("SELECT nip_dosen FROM jadwal WHERE kode_jadwal=" + id);

            while (database.reader.Read())
            {
                hasil = database.reader.GetString(0);
            }

            database.reader.Close();
            return hasil;
        }

        private bool bentrokRuang(String ruang, String hari, String jam)
        {
            int jum = 0;
            jum = database.executeScalar("SELECT Count(*) FROM jadwal WHERE kode_ruang='" + ruang + "' AND kode_hari=" + hari + " AND waktu_mulai='" + jam + "'");

            if (jum > 0)
                return true;
            else
                return false;
        }

        private bool bentrokDosen(String dosen, String hari, String jam)
        {
            int jum = 0;
            jum = database.executeScalar("SELECT Count(*) FROM jadwal WHERE nip_dosen='" + dosen + "' AND kode_hari=" + hari + " AND waktu_mulai='" + jam + "'");

            if (jum > 0)
                return true;
            else
                return false;
        }

        private bool bentrokKelas(String kelas, String hari, String jam)
        {
            int jum = 0;
            jum = database.executeScalar("SELECT Count(*) FROM jadwal WHERE kode_kelas='" + kelas + "' AND kode_hari=" + hari + " AND waktu_mulai='" + jam + "'");

            if (jum > 0)
                return true;
            else
                return false;
        }

        private void hapusJadwal()
        {
            if (lstJadwal.SelectedItems.Count > 0)
            {
                database.execute("DELETE FROM jadwal WHERE kode_jadwal=" + lstJadwal.SelectedItems[0].Text);
                lstJadwal.Items.RemoveAt(Convert.ToInt32(lstJadwal.SelectedItems[0].Index));
            }
        }

        public frmJadwal()
        {
            InitializeComponent();
        }

        private void frmJadwal_Load(object sender, EventArgs e)
        {
            ambilDataJadwal();
            ambilDataRuang();
            ambilDataKelas();
            input_dosen();
            input_matkul();
            cmbHari.SelectedIndex = 0;
        }

        private void txtKodeRuang_TextChanged(object sender, EventArgs e)
        {
            if (cekKodeRuang())
            {
                button1.Text = "Update";
                txtKodeRuang.BackColor = Color.Red;
                txtKodeRuang.ForeColor = Color.White;
                txtKodeRuang.Font = new Font("Trebuchet MS", 8, FontStyle.Bold);
            }
            else
            {
                button1.Text = "Tambah";
                txtKodeRuang.BackColor = Color.White;
                txtKodeRuang.ForeColor = Color.Black;
                txtKodeRuang.Font = new Font("Trebuchet MS", 8, FontStyle.Regular);
            }
            setEnableRuang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tambahRuang();
        }

        private void lstRuang_Click(object sender, EventArgs e)
        {
            if (lstRuang.SelectedItems.Count > 0)
            {
                setEnableRuang();
                cmbRuang.Text = txtKodeRuang.Text = lstRuang.SelectedItems[0].Text;
                txtKeteranganRuang.Text = lstRuang.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void txtKodeKelas_TextChanged(object sender, EventArgs e)
        {
            if (cekKodeKelas())
            {
                button4.Text = "Update";
                txtKodeKelas.BackColor = Color.Red;
                txtKodeKelas.ForeColor = Color.White;
                txtKodeKelas.Font = new Font("Trebuchet MS", 8, FontStyle.Bold);
            }
            else
            {
                button4.Text = "Tambah";
                txtKodeKelas.BackColor = Color.White;
                txtKodeKelas.ForeColor = Color.Black;
                txtKodeKelas.Font = new Font("Trebuchet MS", 8, FontStyle.Regular);
            }
            setEnableKelas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tambahKelas();
        }

        private void lstKelas_Click(object sender, EventArgs e)
        {
            if (lstKelas.SelectedItems.Count > 0)
            {
                setEnableKelas();
                cmbKelas.Text = txtKodeKelas.Text = lstKelas.SelectedItems[0].Text;
                txtKeteranganKelas.Text = lstKelas.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hapusRuang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hapusKelas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tambahJadwal();
            button7.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editJadwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstJadwal.SelectedItems.Count > 0)
            {
                lblId.Text = lstJadwal.SelectedItems[0].Text;
                cmbHari.Text = lstJadwal.SelectedItems[0].SubItems[1].Text;
                txtWaktuMulai.Text = lstJadwal.SelectedItems[0].SubItems[2].Text;
                cmbMataKuliah.Text = getKodeMK(lblId.Text) + "--" + lstJadwal.SelectedItems[0].SubItems[3].Text;
                cmbDosen.Text = getNip(lblId.Text) + "--" + lstJadwal.SelectedItems[0].SubItems[4].Text;
                cmbKelas.Text = lstJadwal.SelectedItems[0].SubItems[5].Text;
                cmbRuang.Text = lstJadwal.SelectedItems[0].SubItems[6].Text;
                button5.Text = "Update";
                button7.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Visible = false;
            button5.Text = "Tambah";
            lblId.Text = "";
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hapusJadwal();
        }
    }
}
