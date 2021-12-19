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
    public partial class frmilacdeposorgula : Form
    {
        public frmilacdeposorgula()
        {
            InitializeComponent();
            this.Text = "Depo Sorgula";
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=EczaneUygulamasi;User Id=postgres;Password=onigiri801;Integrated Security=true;");
        private void frmilacdeposorgula_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from depo where depono=@p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", int.Parse(txtdepono.Text));
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "adi";
            comboBox1.DisplayMember = "adi";
            comboBox1.DataSource = dt; ;


            baglanti.Open();
           
            NpgsqlCommand girisKontrol4 = new NpgsqlCommand("select miktari from depo where depono=@p1 ", baglanti);
            girisKontrol4.Parameters.AddWithValue("@p1",int.Parse(txtdepono.Text));
            NpgsqlDataReader da4 = girisKontrol4.ExecuteReader();

            if (da4.Read())
            {
                txtmiktari.Text = da4["miktari"].ToString();
            }

            baglanti.Close();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
