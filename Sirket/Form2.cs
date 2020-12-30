using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sirket
{
    public partial class yetkliliSayfa : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=Sirket;User Id=postgres;Password=atif;");
        NpgsqlDataReader kullaniciData;
        NpgsqlCommand com = new NpgsqlCommand();
        string ad, soyad, dogumTarihi, sifre, mail;
        int kulkaniciNo;

        public yetkliliSayfa(int _kullaniciNo)
        {
            InitializeComponent();
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT * FROM sema.kisi WHERE kullanicino ='" + _kullaniciNo + "';";
            kullaniciData = com.ExecuteReader();
            while (kullaniciData.Read()) {
                ad = kullaniciData.GetString(0);
                soyad = kullaniciData.GetString(2);
                dogumTarihi = kullaniciData.GetDate(4).ToString();
                kulkaniciNo = kullaniciData.GetInt32(1);
                sifre = kullaniciData.GetString(5);
                mail = kullaniciData.GetString(3);
            }
            com.Connection.Close();
        }

        private void personelEkleBTN_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string kayit = "insert into sema.kisi(ad,soyad,mail,sifre,dogumtarihi,yetkikodu) values (@ad,@soy,@mail,@sifre,@dogumtarihi,@yetki)";
            NpgsqlCommand komut = new NpgsqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@ad", personelAd.Text);
            komut.Parameters.AddWithValue("@soy", personelSoyad.Text);
            komut.Parameters.AddWithValue("@mail", personelMail.Text);
            komut.Parameters.AddWithValue("@sifre", personelSifre.Text);
            komut.Parameters.AddWithValue("@dogumtarihi", Convert.ToDateTime(personelDog.Text));
            komut.Parameters.AddWithValue("@yetki", int.Parse(personelYetki.Text));
            komut.ExecuteNonQuery();
            kayit = "insert into sema.personel(maas,departman,kullanicino) values (@maas,@dep,(select kullanicino from sema.kisi order by kullanicino desc limit 1))";
            komut = new NpgsqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@maas", int.Parse(personelMaas.Text));
            komut.Parameters.AddWithValue("@dep", personelDepartman.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") { 
                baglanti.Open();
                com.Connection = baglanti;
                com.CommandText = "DELETE FROM sema.personel WHERE kullanicino = '"+ int.Parse(textBox1.Text) +"';";
                com.ExecuteNonQuery();
                baglanti.Close();
            }
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            
            if (kAdTB.Text == "")
                MessageBox.Show("Değiştirmek istiyorsanız yeni şifreyi istemiyorsanız mevcut şifreyi girin.");
            else
            {
                baglanti.Open();
                com.Connection = baglanti;
                com.CommandText = "UPDATE sema.kisi SET sifre = '" + kSifreTB.Text + "', ad = '" + kAdTB.Text + "', soyad = '" + kSoyadTB.Text + "', mail = '" + kMailTB.Text + "', dogumtarihi = '" + kDogTB.Text + "' WHERE kullanicino = '" + kulkaniciNo + "'; ";
                com.ExecuteNonQuery();
                baglanti.Close();
            }
            this.Refresh();
        }

        private void yetkliliSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void personelBTN_Click(object sender, EventArgs e)
        {
            personelIslem.Visible = true;
            
        }

        private void yetkliliSayfa_Load(object sender, EventArgs e)
        {
            hosgeldiniz.Text = "Hoşgeldiniz " + ad + " " + soyad;
            kAdTB.Text = ad;
            kSoyadTB.Text = soyad;
            kDogTB.Text = dogumTarihi;
            kMailTB.Text = mail;
            kSifreTB.Text = sifre;
        }
    }
}
