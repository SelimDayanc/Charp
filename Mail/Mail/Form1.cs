using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random random = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.outlook.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("selim_dync@hotmail.com", "Selim1345.");

            MailMessage eposta = new MailMessage();
            eposta.From = new MailAddress("selim_dync@hotmail.com");
            eposta.To.Add(textBox1.Text.ToString());
            eposta.Subject = "Doğrulama Kodu";
            eposta.Body = "Doğrulama Kodunuz ='"+random.Next(100000, 999999)+"'";
            sc.Send(eposta);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) MessageBox.Show("alooo");
        }
    }
}
