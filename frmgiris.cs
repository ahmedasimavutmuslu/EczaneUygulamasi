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
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent();
            this.Text = "Giriş Ekranı";
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=EczaneUygulamasi;User Id=postgres;Password=onigiri801;Integrated Security=true;");

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtkadi.Text;
            string password = txtsifre.Text;
            baglanti.Open();
            NpgsqlCommand girisKontrol = new NpgsqlCommand("select * from eczane where kadi=@p1 and sifre=@p2", baglanti);
            girisKontrol.Parameters.AddWithValue("@p1", txtkadi.Text);
            girisKontrol.Parameters.AddWithValue("@p2", txtsifre.Text);
            NpgsqlDataReader da = girisKontrol.ExecuteReader();
            
            if (da.Read())
            {
                Form1 aktar = new Form1();
                aktar.eczaneAdi = da["adi"].ToString();
                aktar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiiniz bilgilerle eşleşen bir eczane bulunamadı.");
            }
            baglanti.Close();
        }

        private void txtkadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmgiris_Load(object sender, EventArgs e)
        {

        }
    }
}
