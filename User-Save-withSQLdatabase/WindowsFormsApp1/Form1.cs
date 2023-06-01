using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-H7NGVUR\\SQLEXPRESS;Initial Catalog=kayıtlar;Integrated Security=True");
        private void disp()
        {
            connect.Open();
            SqlCommand komut = new SqlCommand("Select *from gelenler",connect);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = oku["adsoyad"].ToString(); ;
                add.SubItems.Add(oku["firma"].ToString());
                add.SubItems.Add(oku["telefon"].ToString());
                listView1.Items.Add(add);
            }
            connect.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            disp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand insert = new SqlCommand("Insert into gelenler (adsoyad,firma,telefon) Values ('"+ textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+ "','" + textBox3.Text.ToString()+"')",connect);
            insert.ExecuteNonQuery();
            connect.Close();
            disp();
        }
    }
}
