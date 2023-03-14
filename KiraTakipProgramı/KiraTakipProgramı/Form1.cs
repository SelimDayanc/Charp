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
using DevExpress.XtraEditors.Filtering.Templates;

namespace KiraTakipProgramı
{









    public partial class Form1 : DevExpress.XtraBars.TabForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=MSI;Initial Catalog=KiraTakip;Integrated Security=True");
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void listele()
        {


            for (int i = 1;i<10;i++)
            {
                int degiskeni;
            }




            listView1.Items.Clear();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select *from KiraTakipT",conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = reader["id"].ToString();
                list.SubItems.Add(reader["isim"].ToString());
                list.SubItems.Add(reader["soyad"].ToString());
                list.SubItems.Add(reader["telefon"].ToString());
                listView1.Items.Add(list);
            }
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("insert into KiraTakipT (isim,soyad,telefon,eposta,kirabaslangic,bildirim) values ('" + textEdit1.Text+"','"+ textEdit2.Text + "','"+ textEdit3.Text + "','"+ textEdit4.Text + "','"+ dateTimePicker1.Value + "','"+ comboBox2.Text + "')", conn);
            comm.ExecuteNonQuery();
            conn.Close();
            listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("Delete from KiraTakipT where id = "+id+"",conn);
            comm.ExecuteNonQuery();
            conn.Close();
            listele();

        }
        int id = 0;
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            id =int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            listView2.Items.Clear();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select *from KiraTakipT where id = "+id+"", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string baslangıc = reader["kirabaslangic"].ToString();
                string b2, b3, b4, b5, b6, b7, b8, b9, b10, b11;
                
                ListViewItem list= new ListViewItem();
                list.Text = baslangıc;
                listView2.Items.Add(list);
            }
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                label8.Visible = true;
                comboBox2.Visible = true;
            }
            else
            {
                label8.Visible = false;
                comboBox2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
