using DevExpress.Accessibility.Tab;
using DevExpress.XtraTab;
using DevExpress.XtraTab.Buttons;
using DevExpress.XtraTab.ViewInfo;
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
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.Data.Svg;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace EmlakOtomasyonuOdev
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }
        
       
        SqlConnection conn = new SqlConnection("Data Source=MSI;Initial Catalog=EmlakOtomasyonKonut;Integrated Security=True");

        #region Sayfa Açma Kapama
        private void xtraTabControl1_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {

            xtraTabControl1.SelectedTabPage.PageVisible = false;
            

        }
        private void navBarItem1_ItemChanged(object sender, EventArgs e)
        {
            xtraTabPageListele.PageVisible = true;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageListele.PageVisible = true;
            xtraTabPageListele.Show();
            Listele();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageEkle.PageVisible = true;
            xtraTabPageEkle.Show();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageDuzenle.PageVisible = true;
            xtraTabPageDuzenle.Show();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageAra.PageVisible = true;
            xtraTabPageAra.Show();
        }

        private void xtrabuyuk_CustomHeaderButtonClick(object sender, CustomHeaderButtonEventArgs e)
        {

            Application.Exit();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageGoruntule.PageVisible = true;
            KiraListele();
            xtraTabPageGoruntule.Show();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageEkle2.PageVisible = true;
            xtraTabPageEkle2.Show();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageDuzenle2.PageVisible = true;
            xtraTabPageDuzenle2.Show();
        }

        private void xtraTabControl2_CustomHeaderButtonClick(object sender, CustomHeaderButtonEventArgs e)
        {

            xtraTabControl2.SelectedTabPage.PageVisible = false;


        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPageTapu.PageVisible = true;
            xtraTabPageTapu.Show();
        }

       
        private void xtraTabControl3_CustomHeaderButtonClick(object sender, CustomHeaderButtonEventArgs e)
        {
            xtraTabControl3.SelectedTabPage.PageVisible = false;
        }
        #endregion

        void Listele()
        {
            
            listView1.Items.Clear();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from EmlakOtomasyonTable", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = reader["id"].ToString();
                list.SubItems.Add(reader["sehir"].ToString());
                list.SubItems.Add(reader["ilce"].ToString());
                list.SubItems.Add(reader["mahalle"].ToString());
                list.SubItems.Add(reader["binaAdi"].ToString());
                list.SubItems.Add(reader["kat"].ToString());
                list.SubItems.Add(reader["daire"].ToString());
                list.SubItems.Add(reader["binaYasi"].ToString());
                list.SubItems.Add(reader["metreKare"].ToString());
                list.SubItems.Add(reader["odaSayisi"].ToString());
                list.SubItems.Add(reader["balkonSayisi"].ToString());
                list.SubItems.Add(reader["esyali"].ToString());
                list.SubItems.Add(reader["evTipi"].ToString());
                list.SubItems.Add(reader["fiyat"].ToString());
                listView1.Items.Add(list);
            }

            conn.Close();

        }

        private void konutEkleBtn_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlCommand comm = new SqlCommand("insert into EmlakOtomasyonTable (sehir,ilce,mahalle,binaAdi,kat,daire,binaYasi,metreKare,odaSayisi,balkonSayisi,esyali,evTipi,fiyat) values ('" + textBox13.Text + "','" + textBox18.Text + "','" + txtMahalle.Text + "','" + txtBinaAdi.Text + "','" + txtKat.Text + "','" + txtDaire.Text + "','" + txtBinaYasi.Text + "','" + txtMetreKare.Text + "','" + comboOdaSayisi.Text + "','" + comboBalkonSayisi.Text + "','" + comboEsyali.Text + "','" + comboEvTipi.Text + "','" + txtFiyat.Text + "')", conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void btnKonutTemizle_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox18.Text = "";
            txtMahalle.Text = "";
            txtBinaAdi.Text = "";
            txtKat.Text = "";
            txtDaire.Text = "";
            txtBinaYasi.Text = "";
            txtMetreKare.Text = "";
            comboOdaSayisi.Text = "";
            comboBalkonSayisi.Text = "";
            comboEsyali.Text = "";
            comboEvTipi.Text = "";
            txtFiyat.Text = "";
        }

        private void btnKonutSil_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlCommand comm = new SqlCommand("Delete  from EmlakOtomasyonTable where id = @id", conn);
            comm.Parameters.AddWithValue("@id", txtId.Text);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void btnKonutTemizle2_Click(object sender, EventArgs e)
        {
            textBox22.Text = "";
            textBox25.Text = "";
            txtMahalle2.Text = "";
            txtBinaAdi2.Text = "";
            txtKat2.Text = "";
            txtDaire2.Text = "";
            txtBinaYasi2.Text = "";
            txtMetreKare2.Text = "";
            comboOdaSayisi2.Text = "";
            comboBalkonSayisi2.Text = "";
            comboEsyali2.Text = "";
            comboEvTipi2.Text = "";
            txtFiyat2.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            illerCombo2();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from EmlakOtomasyonTable where id = @id", conn);
            comm.Parameters.AddWithValue("@id", txtId.Text);
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {


                textBox22.Text = reader["sehir"].ToString();
                textBox25.Text = reader["ilce"].ToString();
                txtMahalle2.Text = reader["mahalle"].ToString();
                txtBinaAdi2.Text = reader["binaAdi"].ToString();
                txtKat2.Text = reader["kat"].ToString();
                txtDaire2.Text = reader["daire"].ToString();
                txtBinaYasi2.Text = reader["binaYasi"].ToString();
                txtMetreKare2.Text = reader["metreKare"].ToString();
                comboOdaSayisi2.Text = reader["odaSayisi"].ToString();
                comboBalkonSayisi2.Text = reader["balkonSayisi"].ToString();
                comboEsyali2.Text = reader["esyali"].ToString();
                comboEvTipi2.Text = reader["evTipi"].ToString();
                txtFiyat2.Text = reader["fiyat"].ToString();
                textBox22.Enabled = true;
                textBox25.Enabled = true;
                txtMahalle2.Enabled = true;
                txtBinaAdi2.Enabled = true;
                txtKat2.Enabled = true;
                txtDaire2.Enabled = true;
                txtBinaYasi2.Enabled = true;
                txtMetreKare2.Enabled = true;
                comboOdaSayisi2.Enabled = true;
                comboBalkonSayisi2.Enabled = true;
                comboEsyali2.Enabled = true;
                comboEvTipi2.Enabled = true;
                txtFiyat2.Enabled = true;


            }
            conn.Close();








        }

        void illerCombo2()
        {
            /*conn.Open();
            SqlCommand comm = new SqlCommand("Select * from iller", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                textBox22.Properties.Items.Add(reader[1]);
            }
            conn.Close();*/

        }
        void illerCombo()
        {
            /*conn.Open();
            SqlCommand comm = new SqlCommand("Select * from iller", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                comboSehir.Properties.Items.Add(reader[1]);
            }
            conn.Close();*/

        }
        void illerCombo3()
        {/*
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from iller", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                textBox27.Properties.Items.Add(reader[1]);
            }
            conn.Close();*/
        }
        private void comboSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*comboIlce.Properties.Items.Clear();
            comboIlce.Text = "";
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from ilceler where sehir = @p1", conn);
            comm.Parameters.AddWithValue("@p1", comboSehir.SelectedIndex + 1);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                comboIlce.Properties.Items.Add(reader[0]);
            }
            conn.Close();*/
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            /*illerCombo();
            illerCombo3();*/
        }

        private void comboSehir2_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*comboIlce2.Properties.Items.Clear();
            comboIlce2.Text = "";
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from ilceler where sehir = @p1", conn);
            comm.Parameters.AddWithValue("@p1", comboSehir2.SelectedIndex + 1);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                comboIlce2.Properties.Items.Add(reader[1]);
            }
            conn.Close();*/
        }

        private void btnKonutDuzenle_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlCommand comm = new SqlCommand("Update EmlakOtomasyonTable set sehir = @sehir,ilce = @ilce ,mahalle=@mahalle,binaAdi=@binaAdi,kat=@kat,daire=@daire,binaYasi=@binaYasi,metreKare=@metreKare,odaSayisi=@odaSayisi,balkonSayisi=@balkonSayisi,esyali=@esyali,evTipi=@evTipi,fiyat=@fiyat where id = @id", conn);
            comm.Parameters.AddWithValue("@id", txtId.Text);
            comm.Parameters.AddWithValue("@sehir", textBox22.Text);
            comm.Parameters.AddWithValue("@ilce", textBox25.Text);
            comm.Parameters.AddWithValue("@mahalle", txtMahalle2.Text);
            comm.Parameters.AddWithValue("@binaAdi", txtBinaAdi2.Text);
            comm.Parameters.AddWithValue("@kat", txtKat2.Text);
            comm.Parameters.AddWithValue("@daire", txtDaire2.Text);
            comm.Parameters.AddWithValue("@odaSayisi", comboOdaSayisi2.Text);
            comm.Parameters.AddWithValue("@balkonSayisi", comboBalkonSayisi2.Text);
            comm.Parameters.AddWithValue("@binaYasi", txtBinaYasi2.Text);
            comm.Parameters.AddWithValue("@metreKare", txtMetreKare2.Text);
            comm.Parameters.AddWithValue("@esyali", comboEsyali2.Text);
            comm.Parameters.AddWithValue("@evTipi", comboEvTipi2.Text);
            comm.Parameters.AddWithValue("@fiyat", txtFiyat2.Text);
            comm.ExecuteNonQuery();



            conn.Close();


        }

        private void btnAra1_Click(object sender, EventArgs e)
        {
            
            listView4.Items.Clear();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from EmlakOtomasyonTable where sehir =@sehir AND ilce=@ilce AND mahalle=@mahalle", conn);
            comm.Parameters.AddWithValue("@sehir", textBox27.Text);
            comm.Parameters.AddWithValue("@ilce", textBox28.Text);
            comm.Parameters.AddWithValue("@mahalle", textBox1.Text);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = reader["id"].ToString();
                list.SubItems.Add(reader["sehir"].ToString());
                list.SubItems.Add(reader["ilce"].ToString());
                list.SubItems.Add(reader["mahalle"].ToString());
                list.SubItems.Add(reader["odaSayisi"].ToString());
                list.SubItems.Add(reader["esyali"].ToString());
                list.SubItems.Add(reader["evTipi"].ToString());
                list.SubItems.Add(reader["fiyat"].ToString());
                listView4.Items.Add(list);
            }

            conn.Close();
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Text = "";
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from ilceler where sehir = @p1", conn);
            comm.Parameters.AddWithValue("@p1", comboBoxEdit2.SelectedIndex + 1);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                comboBoxEdit1.Properties.Items.Add(reader[1]);
            }
            conn.Close();*/
        }

        private void btnAra2_Click(object sender, EventArgs e)
        {
           
            listView4.Items.Clear();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from EmlakOtomasyonTable where fiyat between '" + int.Parse(textBox2.Text) + "' AND '" + int.Parse(textBox3.Text) + "' AND esyali=@esyali AND evTipi=@evTipi", conn);
            comm.Parameters.AddWithValue("@esyali", comboBoxEdit3.Text);
            comm.Parameters.AddWithValue("@evTipi", comboBoxEdit4.Text);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = reader["id"].ToString();
                list.SubItems.Add(reader["sehir"].ToString());
                list.SubItems.Add(reader["ilce"].ToString());
                list.SubItems.Add(reader["mahalle"].ToString());
                list.SubItems.Add(reader["odaSayisi"].ToString());
                list.SubItems.Add(reader["esyali"].ToString());
                list.SubItems.Add(reader["evTipi"].ToString());
                list.SubItems.Add(reader["fiyat"].ToString());
                listView4.Items.Add(list);
            }

            conn.Close();

        }
        byte toplam1 = 0;
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            toplam1 += 1;
            if (toplam1 == 1)
            {
                textBox2.Text = "";
            }



        }
        byte toplam2 = 0;
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            toplam2 += 1;
            if (toplam2 == 1)
            {
                textBox3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox27.Text = "";
            textBox28.Text = "";
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBoxEdit3.Text = "";
            comboBoxEdit4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        #region KiraTakip
        #endregion
        void KiraListele()
        {
            listView2.Items.Clear();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from emlakKiraTable", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = reader["id"].ToString();
                list.SubItems.Add(reader["isim"].ToString());
                list.SubItems.Add(reader["soyisim"].ToString());
                list.SubItems.Add(reader["telefon"].ToString());
                list.SubItems.Add(reader["eposta"].ToString());
                list.SubItems.Add(reader["baslangictarihi"].ToString());
                list.SubItems.Add(reader["fiyat"].ToString());
                listView2.Items.Add(list);
            }
            conn.Close();

        }

        private void btnKiraEkle_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlCommand comm = new SqlCommand("insert into emlakKiraTable (isim,soyisim,telefon,eposta,baslangictarihi,fiyat,bireyseleposta,sifre) values ('" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + dateEdit1.Text + "','" + textBox19.Text + "','" + textBox21.Text + "','"+textBox10.Text+"')", conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label33.Visible = true;
                textBox21.Visible = true;
                label62.Visible = true;
                textBox10.Visible = true;

            }
            else
            {
                
                label33.Visible = false;
                textBox21.Visible = false;
                label62.Visible = false;
                textBox10.Visible = false;

            }
        }

        private void btnKiraEkleTemizle_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            dateEdit1.Text = "";
            textBox19.Text = "";
            textBox21.Text = "";
        }
        int id = 0;
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            listView3.Items.Clear();
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from emlakKiraTable where id = '" + id + "'", conn);
            SqlDataReader reader = comm.ExecuteReader();


            while (reader.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = reader["baslangictarihi"].ToString();
                ListViewItem list1 = new ListViewItem();
                ListViewItem list2 = new ListViewItem();
                ListViewItem list3 = new ListViewItem();
                ListViewItem list4 = new ListViewItem();
                ListViewItem list5 = new ListViewItem();
                ListViewItem list6 = new ListViewItem();
                ListViewItem list7 = new ListViewItem();
                ListViewItem list8 = new ListViewItem();
                ListViewItem list9 = new ListViewItem();
                ListViewItem list10 = new ListViewItem();
                ListViewItem list11 = new ListViewItem();
                ListViewItem list12 = new ListViewItem();
                DateTime a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13;
                a1 = (DateTime)reader["baslangictarihi"];
                a2 = a1.AddDays(30);
                a3 = a2.AddDays(30);
                a4 = a3.AddDays(30);
                a5 = a4.AddDays(30);
                a6 = a5.AddDays(30);
                a7 = a6.AddDays(30);
                a8 = a7.AddDays(30);
                a9 = a8.AddDays(30);
                a10 = a9.AddDays(30);
                a11 = a10.AddDays(30);
                a12 = a11.AddDays(30);
                a13 = a12.AddDays(30);
                list1.Text = a2.ToString();
                list2.Text = a3.ToString();
                list3.Text = a4.ToString();
                list4.Text = a5.ToString();
                list5.Text = a6.ToString();
                list6.Text = a7.ToString();
                list7.Text = a8.ToString();
                list8.Text = a9.ToString();
                list9.Text = a10.ToString();
                list10.Text = a11.ToString();
                list11.Text = a12.ToString();
                list12.Text = a13.ToString();
                listView3.Items.Add(list1);
                listView3.Items.Add(list2);
                listView3.Items.Add(list3);
                listView3.Items.Add(list4);
                listView3.Items.Add(list5);
                listView3.Items.Add(list6);
                listView3.Items.Add(list7);
                listView3.Items.Add(list8);
                listView3.Items.Add(list9);
                listView3.Items.Add(list10);
                listView3.Items.Add(list11);
                listView3.Items.Add(list12);

            }
            conn.Close();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from emlakKiraTable where id = '" + textBox20.Text + "'", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                textBox4.Text = reader["isim"].ToString();
                textBox5.Text = reader["soyisim"].ToString();
                textBox23.Text = reader["telefon"].ToString();
                textBox24.Text = reader["eposta"].ToString();
                dateEdit2.Text = reader["baslangictarihi"].ToString();
                textBox26.Text = reader["fiyat"].ToString();
                textBox12.Text = reader["bireyseleposta"].ToString();
                textBox11.Text = reader["sifre"].ToString();
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox23.Enabled = true;
                textBox24.Enabled = true;
                dateEdit2.Enabled = true;
                textBox26.Enabled = true;
                textBox12.Enabled = true;
                textBox11.Enabled = true;
            }
            conn.Close();
        }

        private void btnKiraDüzenleTemizle_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = ""; 
            textBox23.Text = "";
            textBox24.Text = "";
            dateEdit2.Text = "";
            textBox26.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
        }

        private void btnKiraTakipSil_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlCommand comm = new SqlCommand("Delete from emlakKiraTable where id = '"+textBox20.Text+"'",conn);
            comm.ExecuteNonQuery();
            conn.Close();

        }

        private void btnKiraTakipDuzenle_Click(object sender, EventArgs e)
        {
           
            conn.Open();
            SqlCommand comm = new SqlCommand("Update emlakKiraTable set isim=@isim,soyisim=@soyisim,telefon=@telefon,eposta=@eposta,baslangictarihi=@baslangictarihi,fiyat=@fiyat,bireyseleposta=@bireyseleposta,sifre=@sifre where id = '" + textBox20.Text+"'", conn);
            comm.Parameters.AddWithValue("@isim",textBox4.Text);
            comm.Parameters.AddWithValue("@soyisim", textBox5.Text);
            comm.Parameters.AddWithValue("@telefon", textBox23.Text);
            comm.Parameters.AddWithValue("@eposta", textBox24.Text);
            comm.Parameters.AddWithValue("@baslangictarihi", dateEdit2.Text);
            comm.Parameters.AddWithValue("@fiyat", textBox26.Text);
            comm.Parameters.AddWithValue("@bireyseleposta", textBox12.Text);
            comm.Parameters.AddWithValue("@sifre", textBox11.Text);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {

            double toplam, alici, satici;
            alici = (Convert.ToDouble(textBox6.Text) * 2) / 100;
            satici = (Convert.ToDouble(textBox6.Text) * 2) / 100;
            toplam = alici + satici;
            label55.Text = alici.ToString()+ " TL";
            label56.Text = satici.ToString() + " TL";
            label58.Text = toplam.ToString() + " TL";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from emlakKiraTable where id = '"+textBox7.Text+"'",conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {

                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.outlook.com";
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential(reader["bireyseleposta"].ToString(), reader["sifre"].ToString());

                MailMessage eposta = new MailMessage();
                eposta.From = new MailAddress(reader["bireyseleposta"].ToString());
                eposta.To.Add(reader["eposta"].ToString());
                eposta.Subject = textBox8.Text;
                eposta.Body = textBox9.Text;
                try{
                sc.Send(eposta);
                    MessageBox.Show("Başarıyla Gönderildi");
                }
                catch (Exception)
                {
                    MessageBox.Show("Başarısız Oldu");
                }
            }
            
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
