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
    public partial class frmcalisanekle : Form
    {
        public frmcalisanekle()
        {
            InitializeComponent();
            this.Text = "Çalışan Ekle";
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=EczaneUygulamasi;User Id=postgres;Password=onigiri801;Integrated Security=true;");
        private void frmcalisanekle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komut = new NpgsqlCommand("insert into calisanlar (adi,soyadi, tckimlik,eczaneno,mudurno,personelno,adresi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);

            komut.Parameters.AddWithValue("@p1", txtadi.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyadi.Text);
            komut.Parameters.AddWithValue("@p3", txttckimlik.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(txteczaneno.Text));
            komut.Parameters.AddWithValue("@p5", int.Parse(txtmudurno.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(txtpersonelno.Text));
            komut.Parameters.AddWithValue("@p7", txtadres.Text);
            

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Çalışan kaydı başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
