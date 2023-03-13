using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmlakOtomasyonuOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=MSI;Initial Catalog=EmlakOtomasyonKonut;Integrated Security=True");
    
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from emlakGiris where kullaniciAdi = '"+textBox1.Text+"' AND sifre = '"+textBox2.Text+"'",conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                AnaMenu anamenu = new AnaMenu();
                anamenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SifremiUnuttum su = new SifremiUnuttum();
            su.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KayitOl ko = new KayitOl();
            ko.Show();
            this.Hide();

        }
    }
}
