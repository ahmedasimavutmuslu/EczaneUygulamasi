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
    public partial class frmreceteekle : Form
    {
        public frmreceteekle()
        {
            InitializeComponent();
            this.Text = "Reçete Sorgula";

        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=EczaneUygulamasi;User Id=postgres;Password=onigiri801;Integrated Security=true;");

        private void button1_Click(object sender, EventArgs e)
        {

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from recete where hastano=@p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", int.Parse(txthastano.Text));
            DataTable dt = new DataTable();
            da.Fill(dt);           
            comboBox1.ValueMember = "receteno";
            comboBox1.DisplayMember = "receteno";
            comboBox1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand girisKontrol = new NpgsqlCommand("select adi from recete inner join hastane on hastane.hastaneno=recete.hastaneno where receteno=@p1", baglanti);
            girisKontrol.Parameters.AddWithValue("@p1", int.Parse(comboBox1.Text));
            NpgsqlDataReader da = girisKontrol.ExecuteReader();

            if (da.Read())
            {
                txthastaneadi.Text = da["adi"].ToString();
            }
            baglanti.Close();

            baglanti.Open();

            NpgsqlCommand girisKontrol2 = new NpgsqlCommand("select adi from recete inner join hasta on hasta.hastano=recete.hastano where receteno=@p1", baglanti);
            girisKontrol2.Parameters.AddWithValue("@p1", int.Parse(comboBox1.Text));
            NpgsqlDataReader da2 = girisKontrol2.ExecuteReader();

            if (da2.Read())
            {
                txthastaadi.Text = da2["adi"].ToString();
            }

            baglanti.Close();

            baglanti.Open();

            NpgsqlCommand girisKontrol3 = new NpgsqlCommand("select adi from recete inner join doktor on doktor.doktorno=recete.doktorno where receteno=@p1", baglanti);
            girisKontrol3.Parameters.AddWithValue("@p1", int.Parse(comboBox1.Text));
            NpgsqlDataReader da3 = girisKontrol3.ExecuteReader();

            if (da3.Read())
            {
                txtdoktoradi.Text = da3["adi"].ToString();
            }

            baglanti.Close();



            baglanti.Open();

            NpgsqlCommand girisKontrol4 = new NpgsqlCommand("select teshis from recete where receteno=@p1", baglanti);
            girisKontrol4.Parameters.AddWithValue("@p1", int.Parse(comboBox1.Text));
            NpgsqlDataReader da4 = girisKontrol4.ExecuteReader();

            if (da4.Read())
            {
                txtteshisadi.Text = da4["teshis"].ToString();
            }

            baglanti.Close();

            baglanti.Open();

            NpgsqlCommand girisKontrol5 = new NpgsqlCommand("select soyadi from recete inner join doktor on doktor.doktorno=recete.doktorno where receteno=@p1", baglanti);
            girisKontrol5.Parameters.AddWithValue("@p1", int.Parse(comboBox1.Text));
            NpgsqlDataReader da5 = girisKontrol5.ExecuteReader();

            if (da5.Read())
            {
                txtdoktorsoyadi.Text = da5["soyadi"].ToString();
            }

            baglanti.Close();


            

          


            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter("select adi from recete inner join receteilac ON recete.receteno = receteilac.recetenoilac INNER JOIN ilac  ON ilac.ilacno = receteilac.ilacnoilac where receteno=@p1", baglanti);
            da6.SelectCommand.Parameters.AddWithValue("@p1", int.Parse(txthastano.Text));
            DataTable dt1 = new DataTable();
            da6.Fill(dt1);
            comboBox2.ValueMember = "adi";
            comboBox2.DisplayMember = "adi";
            comboBox2.DataSource = dt1;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void txtilacadi_Click(object sender, EventArgs e)
        {

        }

        private void frmreceteekle_Load(object sender, EventArgs e)
        {

        }
    }
}
