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
    public partial class UC_Goods : UserControl
    {
        string username = "";
        int kucun = 0;
        int goods_id = 0;
        string goods_name = "";
        float price = 0;
        string s_goods_name = "";
        string type_name = "";

        public UC_Goods(string name)
        {
            username = name;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kucun <= 0)
            {
                MessageBox.Show("当前库存为0，不能购买");
            }
            else
            {
                String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
                MySqlConnection conn = new MySqlConnection(connetStr);

                conn.Open();
                string sql2 = "select * from card_item where goods_id=@g and buyer_name=@p";
                MySqlCommand cmd1 = new MySqlCommand(sql2, conn);
                cmd1.Parameters.AddWithValue("g", goods_id);
                cmd1.Parameters.AddWithValue("p", username);
                object result = cmd1.ExecuteScalar();

                if (result != null)                 //已经购买过了
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
                else                  //未购买过
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
                select(s_goods_name, type_name);

            }



        }

        private void select(string s_goods_name, string type_name)
        {
            if (s_goods_name == "")
            {
                if (type_name != "")
                {
                    //按类型查找
                    int type_id = 0;
                    String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
                    MySqlConnection conn = new MySqlConnection(connetStr);
                    conn.Open();
                    string sql = "select * from type where type_name=@t";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("t", type_name);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        type_id = reader.GetInt16("type_id");             //通过类型名得到类型id
                    }
                    conn.Close();
                    conn.Open();
                    string sql2 = "select * from goods where type_id=@tn";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("tn", type_id);              //通过类型id得到商品列表
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd2;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("请选择类型或者输入商品名进行查找！", "提示");
                }
            }
            else
            {
                //按名字查找
                String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
                MySqlConnection conn = new MySqlConnection(connetStr);
                conn.Open();
                string sql = string.Format(@"select * from goods where goods_name like '%{0}%'", s_goods_name);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("name", s_goods_name);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            s_goods_name = Goods_name.Text.ToString();
            type_name = comboBox1.Text.ToString();
            select(s_goods_name, type_name);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string goods_id1 = "";
            goods_id1 = this.dataGridView1.SelectedCells[1].Value.ToString();
            goods_id = Convert.ToInt16(goods_id1);
            kucun = Convert.ToInt16(this.dataGridView1.SelectedCells[4].Value.ToString());
            goods_name = this.dataGridView1.SelectedCells[3].Value.ToString();
            price = float.Parse(this.dataGridView1.SelectedCells[5].Value.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
