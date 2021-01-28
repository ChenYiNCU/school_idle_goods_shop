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
    public partial class UC_Buy : UserControl
    {
        string username = "";
        int goods_id = 0;
        int amount = 0;

        public UC_Buy(string name)
        {
            username = name;
            InitializeComponent();
        }

        public void fillDataView()                  //查找购物车表并返回结果
        {

            int nums = 0;
            float money = 0;
            String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            string sql = "select * from card_item where buyer_name=@p";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("p", username);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();



            //计算总金额和总数量
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand(sql, conn);
            cmd2.Parameters.AddWithValue("p", username);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                int num = reader2.GetInt32("amount");
                float price = reader2.GetFloat("price");
                nums = nums + num;
                money = money + price * num;

            }
            SumMoney.Text = money.ToString() + "元";
            SumNum.Text = nums.ToString() + "件";

            conn.Close();

        }
        private void UC_Buy_Load(object sender, EventArgs e)
        {
            fillDataView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请点击左侧列表继续购物", "提示");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            string sql;
            if (amount <= 1)
            {
                sql = "delete from card_item where buyer_name=@p and goods_id=@p1";
            }
            else
            {
                sql = "update card_item set amount=amount-1 where buyer_name=@p and goods_id=@p1";

            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("p", username);
            cmd.Parameters.AddWithValue("p1", goods_id);
            cmd.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            string sql_g1 = "update goods set totalnum = totalnum+1 where  goods_id=@p1";
            MySqlCommand cmd_g1 = new MySqlCommand(sql_g1, conn);

            cmd_g1.Parameters.AddWithValue("p1", goods_id);
            cmd_g1.ExecuteNonQuery();
            conn.Close();
            fillDataView();
            MessageBox.Show("删除成功！", "删除");

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string goods_id1 = "";
            goods_id1 = this.dataGridView1.SelectedCells[1].Value.ToString();
            goods_id = Convert.ToInt16(goods_id1);
            amount = Convert.ToInt16(this.dataGridView1.SelectedCells[3].Value.ToString());
        }
    }
}
