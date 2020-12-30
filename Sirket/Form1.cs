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

namespace Sirket
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void girisBTN_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Sirket;User Id=postgres;Password=atif;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand();
            com.Connection = conn;
            com.CommandType = CommandType.Text;
            com.CommandText="SELECT * FROM sema.kisi WHERE kullanicino ='"+ kullaniciAdiTB.Text + "' AND sifre = '"+ sifreTB.Text+"';";
            NpgsqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                int yetki = dr.GetInt32(6);
                switch (yetki)
                {
                    case 0:
                        yetkliliSayfa fr = new yetkliliSayfa(int.Parse(kullaniciAdiTB.Text));
                        fr.Show();
                        this.Hide();
                        dr.Close();
                        com.Dispose();
                        conn.Close();
                        break;
                    case 1:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }

        private void giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
