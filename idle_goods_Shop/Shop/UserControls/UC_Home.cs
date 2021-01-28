using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Shop.UserControls
{
    public partial class UC_Home : UserControl
    {
        string username = "";


        public UC_Home(string name)
        {
            username = name;
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void add(int goods_id, string goods_name)
        {
            float price = 0;
            int kucun = 0;

            String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            string sql1 = "select * from goods where goods_id=@g";
            MySqlCommand cmd = new MySqlCommand(sql1, conn);
            cmd.Parameters.AddWithValue("g", goods_id);
            MySqlDataReader reader2 = cmd.ExecuteReader();
            while (reader2.Read())                                         //在商品表里读取出价格
            {
                kucun = reader2.GetInt32("totalnum");
                price = reader2.GetFloat("price");
            }
            conn.Close();
            if (kucun <= 0)
            {
                MessageBox.Show("当前库存为0，不能购买");
            }
            else
            {
                conn.Open();
                string sql2 = "select * from card_item where goods_id=@g and buyer_name=@p";
                MySqlCommand cmd1 = new MySqlCommand(sql2, conn);
                cmd1.Parameters.AddWithValue("g", goods_id);
                cmd1.Parameters.AddWithValue("p", username);
                object result = cmd1.ExecuteScalar();
                if (result != null)                                         //判断是否已经购买过
                {
                    conn.Close();
                    conn.Open();
                    string sql = "update card_item set amount=amount+1 where buyer_name=@p and goods_id=@p1";
                    MySqlCommand cmd_a = new MySqlCommand(sql, conn);
                    cmd_a.Parameters.AddWithValue("p", username);
                    cmd_a.Parameters.AddWithValue("p1", goods_id);
                    cmd_a.ExecuteNonQuery();
                    conn.Close();

                }
                else
                {
                    conn.Close();
                    conn.Open();
                    string sql = "insert into card_item values(@p,@p1,@p2,@p3,@p4)";
                    MySqlCommand cmd2 = new MySqlCommand(sql, conn);
                    cmd2.Parameters.AddWithValue("p", username);
                    cmd2.Parameters.AddWithValue("p1", goods_id);
                    cmd2.Parameters.AddWithValue("p2", goods_name);
                    cmd2.Parameters.AddWithValue("p3", 1);
                    cmd2.Parameters.AddWithValue("p4", price);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                conn.Open();
                string sql_g1 = "update goods set totalnum = totalnum-1 where  goods_id=@p1";
                MySqlCommand cmd_g1 = new MySqlCommand(sql_g1, conn);

                cmd_g1.Parameters.AddWithValue("p1", goods_id);
                cmd_g1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("添加到购物车成功！");
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            add(1, "向上生长");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add(5, "挎包");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add(3, "鼠标");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add(2, "显微镜下的古人生活");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            add(6, "咖啡");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add(8, "耳机");
        }
    }
}
