﻿using System;
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
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
      
        SqlConnection conn = new SqlConnection("Data Source=MSI;Initial Catalog=EmlakOtomasyonKonut;Integrated Security=True");
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox3.Text == textBox4.Text && textBox3.Text.Length>7)
            {
            conn.Open();
            SqlCommand comm = new SqlCommand("Update emlakGiris set sifre = '"+textBox4.Text+"' where kullaniciAdi = '"+textBox1.Text+"'",conn);
            comm.ExecuteNonQuery();
            conn.Close();
            }
            else
            {
                MessageBox.Show("Şifreler eşlemşmiyor veya şifre 8 karakterden küçük");
            }

        }
    }
}
