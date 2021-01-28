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
    public partial class F_response : Form
    {
        string username = "";
        public F_response(string name)
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
            string search = "select count(*) from goods where goods_id = '" + int.Parse(this.textBox4.Text) + "' and saler_name = '"+ username + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(search, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int count = int.Parse(dt.Rows[0][0].ToString());
            if (count > 0)
            {
                string Insertsql = "insert into response(dem_id,user_name,goods_id) values('" + int.Parse(this.textBox1.Text) + "','" + username + "','" + int.Parse(this.textBox4.Text) + "')";
                MySqlCommand cmd = new MySqlCommand(Insertsql, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("您未发布该商品", "确定");
            }
            conn.Close();
            this.Dispose();
        }
    }
}
