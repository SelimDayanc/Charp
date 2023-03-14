using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GirişEkranı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        SqlConnection conn = new SqlConnection("Data Source=MSI;Initial Catalog=Try;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
            
        {
            conn.Open();
            SqlCommand giris = new SqlCommand("insert into Try1 values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','"+textBox4.Text.ToString()+"')", conn);
            giris.ExecuteNonQuery();
            conn.Close();
            SqlCommand giris2 = new SqlCommand("Select * from Try1 where isim='" + textBox1.Text+"'",conn);
            SqlDataReader reader = giris2.ExecuteReader();
            
            if (reader.Read())
            {
                Form1 form1 = new Form1();
                MessageBox.Show("Böyle bir kullanıcı adı mevcut lütfen farklı bir kullanıcı adı giriniz !");
                
                form1.Show();
                this.Hide();
                
            }
            if (textBox1.Text.Length < 5 || textBox2.Text != textBox3.Text)
            {
                Form1 form1 = new Form1();
                MessageBox.Show("Hatalı Kayıt İşlemi")           
                form1.Show();
                this.Hide();
            }
            else
            {
                Form1 form1 = new Form1();
                
                MessageBox.Show("Başarılı Kayıt İşlemi");
                form1.Show();
                this.Hide();
            }
            



        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
