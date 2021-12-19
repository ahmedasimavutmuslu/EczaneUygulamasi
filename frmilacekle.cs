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

    

    public partial class frmilacekle : Form
    {
        public frmilacekle()
        {
            InitializeComponent();
            this.Text = "İlaç Ekle";
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=EczaneUygulamasi;User Id=postgres;Password=onigiri801;Integrated Security=true;");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komut = new NpgsqlCommand("insert into ilac (adi,fiyati,ilacno,kategori,kodu,teminedilecekdepo,tipi,miktari) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);

            komut.Parameters.AddWithValue("@p1", txtadi.Text);
            komut.Parameters.AddWithValue("@p2", double.Parse(txtfiyati.Text));
            komut.Parameters.AddWithValue("@p3", int.Parse(txtilacno.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(txtkategori.Text));
            komut.Parameters.AddWithValue("@p5", int.Parse(txtkodu.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(txtdepo.Text));
            komut.Parameters.AddWithValue("@p7", int.Parse(txttipi.Text));
            komut.Parameters.AddWithValue("@p8", int.Parse(txtmiktari.Text));

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("İlac kaydı başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmilacekle_Load(object sender, EventArgs e)
        {

        }
    }
}
