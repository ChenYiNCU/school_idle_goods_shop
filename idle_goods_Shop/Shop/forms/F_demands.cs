using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.forms
{
    public partial class F_demands : Form
    {
        string username = "";
        public F_demands(string name)
        {
            InitializeComponent();
            username = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String connetStr = "server=localhost;port=3306;user=root;password=111111; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            string Insertsql = "insert into demands(goods_name,price,description,user_name) values('" + this.textBox1.Text + "','" + float.Parse(this.textBox3.Text) + "','" + this.textBox4.Text + "','" + username + "')";
            MySqlCommand cmd = new MySqlCommand(Insertsql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Dispose();
        }
    }
}
