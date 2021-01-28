using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Shop.UserControls
{
    public partial class UC_Sell : UserControl
    {
        string username = "";
        public UC_Sell(string name)
        {
            InitializeComponent();
            username = name;
            My_Conbobox();
        }
        /*  添加下拉列表的选项，USB选择列表 */
        public void My_Conbobox()
        {
            string t_name;
            String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            String sqlSelect = "select * from type";
            MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);
            
            MySqlDataReader reader = cmd.ExecuteReader();     //执行SQL，返回一个“流”
            while (reader.Read())
            {
                t_name = reader["type_name"].ToString();  // 打印出每个用户的用户名
                G_type.Items.Add(t_name);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = G_type.Text;
            this.dataGridView1.Rows[index].Cells[1].Value = G_name.Text;
            this.dataGridView1.Rows[index].Cells[2].Value = G_num.Text;
            this.dataGridView1.Rows[index].Cells[3].Value = G_price.Text;
            this.dataGridView1.Rows[index].Cells[4].Value = G_d.Text;
            this.G_type.Text = "";
            this.G_name.Text = "";
            this.G_num.Text = "";
            this.G_price.Text = "";
            this.G_d.Text = "";
            setTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var str=this.dataGridView1.SelectedCells[2].Value.ToString();
            int num = int.Parse(str);
            num=num+1;
            this.dataGridView1.SelectedCells[2].Value = num;
            setTotal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = this.dataGridView1.SelectedCells[2].Value.ToString();
            int num = int.Parse(str);
            num = num - 1;
            this.dataGridView1.SelectedCells[2].Value = num;
            setTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
            setTotal();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            setTotal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String type, g_name, num, price,Insertsql, search;
            MySqlDataAdapter da;
            DataTable dt;
            int Num, type_id;
            float Price;
            String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();

            //获取总行数
            int rows =  this.dataGridView1.Rows.Count-1;
            for(int i = 0; i < rows; i++)
            {
                type = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                g_name = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                num = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                price = this.dataGridView1.Rows[i].Cells[3].Value.ToString();

                Num = int.Parse(num);
                Price = float.Parse(price);

                //获取typeid
                search = "select type_id from type where type_name = '" + type + "'";
                da = new MySqlDataAdapter(search, conn);
                dt = new DataTable();
                da.Fill(dt);
                type_id = int.Parse(dt.Rows[0][0].ToString());


                Insertsql = "insert into goods(type_id,goods_name,saler_name,totalnum,price) values('" + type_id + "','" + g_name + "','" + username + "','" + Num + "','" + Price + "')";
                MySqlCommand cmd = new MySqlCommand(Insertsql, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            this.dataGridView1.Rows.Clear();
            setTotal();
        }

        //获取总价
        private void setTotal()
        {
            String num, price;
            int Num;
            float Price,total=0;
            int rows = this.dataGridView1.Rows.Count - 1;
            for (int i = 0; i < rows; i++)
            {
                num = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                price = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                Num = int.Parse(num);
                Price = float.Parse(price);
                total = total + Num*Price;
            }
            this.Total.Text = total.ToString(); 
        }
    }
}
