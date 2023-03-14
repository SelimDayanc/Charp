using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            xtraTabPage6.PageVisible = false;
            xtraTabPage5.PageVisible = false;
        }

        private void xtraTabPage5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {
        
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage5.PageVisible = true;
            xtraTabPage5.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabPage6.PageVisible = true;
            xtraTabPage6.Show();
        }

        private void xtraTabControl1_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            if (e.Button.Tag.ToString()=="min")
            {
            this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                Application.Exit();
            }
        }

        private void xtraTabControl2_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            try
            {

                xtraTabControl2.SelectedTabPage.PageVisible = false;
            }
            catch (Exception)
            {
                xtraTabControl2.Visible = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime deger = dateTimePicker1.Value;
            label1.Text = deger.AddMonths(1).ToString();
            
        }
    }
}
