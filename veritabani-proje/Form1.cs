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

namespace veritabani_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; database=dbKutuphane; password=smymys140502; user id=postgres");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kitaplar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into kitaplar (id,no,adi,yazaradi,teslimtarihi)" +
                " values (@id,@no, @adi,@yazaradi, @teslimtarihi)", baglanti);
            komut1.Parameters.AddWithValue("@id", int.Parse(txtid.Text));
            komut1.Parameters.AddWithValue("@no", int.Parse(txtno.Text));
            komut1.Parameters.AddWithValue("@adi", txtad.Text);
            komut1.Parameters.AddWithValue("@yazaradi", txtyazaradi.Text);
            komut1.Parameters.AddWithValue("@teslimtarihi", Convert.ToDateTime(txttarih.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from kitaplar where adi=@adi", baglanti);
            komut2.Parameters.AddWithValue("@adi",txtad.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update kitaplar set teslimtarihi=@teslimtarihi where id=@id ", baglanti);
            komut3.Parameters.AddWithValue("@id", int.Parse(txtid.Text));
            komut3.Parameters.AddWithValue("@teslimtarihi", Convert.ToDateTime(txttarih.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
