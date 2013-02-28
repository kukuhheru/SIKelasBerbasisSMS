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
    public partial class frmChat : Form
    {
        private Database database = new Database(@"Dsn=MySQLServer");
        private int jumlahSMSsekarang;

        public frmChat()
        {
            InitializeComponent();
        }

        private void ambilDataSekarang()
        {
            int i = 0;
            DateTime a;
            ChatBox.Clear();
            lstChat.Items.Clear();

            database.executeReader("SELECT * FROM chat ORDER BY kode_chat DESC");
            while (database.reader.Read())
            {
                a = DateTime.Parse(database.reader.GetString(3));
                ChatBox.SelectionColor = Color.DarkRed;
                ChatBox.SelectionFont = new Font("Trebuchet MS", 7, FontStyle.Regular);
                ChatBox.SelectedText = a.ToLongDateString() + ", " + database.reader.GetString(4) + "\n";
                
                ChatBox.SelectionColor = Color.Blue;
                ChatBox.SelectionFont = new Font("Trebuchet MS", 9, FontStyle.Bold);
                ChatBox.SelectedText = database.reader.GetString(2) + "\n";
                ChatBox.SelectionColor = Color.Black;
                ChatBox.SelectionFont = new Font("Trebuchet MS", 8, FontStyle.Regular);
                ChatBox.SelectedText = database.reader.GetString(1) + "\n\n";

                lstChat.Items.Add(database.reader.GetInt32(0).ToString());
                lstChat.Items[i].SubItems.Add(database.reader.GetString(1));
                lstChat.Items[i].SubItems.Add(database.reader.GetString(2));
                i++;
            }
            database.reader.Close();
        }

        private void kirimChat()
        {
            database.execute("INSERT INTO chat (isi_chat, no_hp, tanggal, jam)VALUES ('" + txtChat.Text + "','Admin', CURDATE(), CURTIME())");
            txtChat.Clear();
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void hapusData()
        {
            database.execute("DELETE FROM chat WHERE kode_chat=" + lblId.Text);
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private int cekChat()
        {
            int jumSMS = 0;
            jumSMS = database.executeScalar("SELECT Count(*) FROM chat");
            return jumSMS;
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            if (!txtChat.Focused)
                txtChat.Focus();
        }

        private void lstChat_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstChat.GetItemAt(e.X, e.Y) != null)
            {
                ChatBox.Find(lstChat.GetItemAt(e.X, e.Y).SubItems[1].Text, ChatBox.Text.Length, ChatBox.Text.Length, RichTextBoxFinds.None);
                lblId.Text = lstChat.GetItemAt(e.X, e.Y).Text;
                ChatBox.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kirimChat();
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Shift && e.KeyCode == Keys.Enter)
                kirimChat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hapusData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((jumlahSMSsekarang < cekChat()) || (jumlahSMSsekarang > cekChat()))
            {
                ambilDataSekarang();
                jumlahSMSsekarang = cekChat();
            }
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hapusData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
