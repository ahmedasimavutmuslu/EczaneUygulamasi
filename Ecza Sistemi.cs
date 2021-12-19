using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Eczane Sistemi";
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=EczaneUygulamasi;User Id=postgres;Password=onigiri801;Integrated Security=true;");
        public string eczaneAdi;         
        private void Form1_Load(object sender, EventArgs e)
        {
            txthosgeldin.Text = eczaneAdi;

            try
            {
                baglanti.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show(" "+ex);
            }

        }

        private void reçetEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reçeteEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reçeteSorgulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreceteekle frm = new frmreceteekle();
            frm.Show();
        }

        private void ilaçEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmilacekle frm = new frmilacekle();
            frm.Show();
        }

        private void ilaçDepoSorgulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmilacdeposorgula frm = new frmilacdeposorgula();
            frm.Show();
        }

        private void çalışanEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcalisanekle frm = new frmcalisanekle();
            frm.Show();
        }
    }
}
