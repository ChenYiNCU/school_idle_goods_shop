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
using Shop.forms;

namespace Shop.UserControls
{
    public partial class UC_Response : UserControl
    {
        string username = "";
        public UC_Response(string name)
        {
            username = name;
            InitializeComponent();
            fillDataview1();
            My_Conbobox1();
        }
        public void My_Conbobox1()
        {
            con1.Items.Add("总求购");
            con1.Items.Add("我的求购");
            con1.Items.Add("我的回应");
            
        }
        public void fillDataview1()
        {
            string constr = "server=localhost;User Id=root;password=root;Database=shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();

            MySqlDataAdapter AdapterSelect = new MySqlDataAdapter("select dem_id,goods_name,price,description,user_name from demands", conn);
            DataTable dt = new DataTable();
            AdapterSelect.Fill(dt);

            dataGridView1.DataSource = dt.DefaultView;
            conn.Close();
        }
        public void fillDataview2()
        {
            string constr = "server=localhost;User Id=root;password=root;Database=shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();

            MySqlDataAdapter AdapterSelect = new MySqlDataAdapter("select dem_id,goods_name,price,description from demands where user_name='" + username + "'", conn);
            DataTable dt = new DataTable();
            AdapterSelect.Fill(dt);

            dataGridView1.DataSource = dt.DefaultView;
            conn.Close();
        }
        public void fillDataview3()
        { 
            string constr = "server=localhost;User Id=root;password=root;Database=shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();

            MySqlDataAdapter AdapterSelect = new MySqlDataAdapter("select a.dem_id,a.goods_name,a.price,a.description,a.user_name from demands a,response b where a.dem_id = b.dem_id", conn);
            DataTable dt = new DataTable();
            AdapterSelect.Fill(dt);

            dataGridView1.DataSource = dt.DefaultView;
            conn.Close();
        }

        private void con1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (con1.SelectedItem.ToString()) //获取选择的内容
            {

                case "总求购": fillDataview1(); break;

                case "我的求购": fillDataview2(); break;

                case "我的回应": fillDataview3(); break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            string constr = "server=localhost;User Id=root;password=root;Database=shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            MySqlDataAdapter AdapterSelect;
            string G_name = this.textBox1.Text;
            switch (this.con1.Text)
            {
                case "我的求购": AdapterSelect = new MySqlDataAdapter("select dem_id,goods_name,price,description from demands where user_name='" + username + "' and goods_name = '" + G_name + "'", conn); break;
                case "我的回应": AdapterSelect = new MySqlDataAdapter("select a.dem_id,a.goods_name,a.price,a.description,a.user_name from demands a,response b where a.dem_id = b.dem_id and goods_name = '" + G_name + "'", conn); break;
                default: AdapterSelect = new MySqlDataAdapter("select dem_id,goods_name,price,description,user_name from demands where goods_name = '" + G_name + "'", conn); break;
            }

            DataTable dt = new DataTable();
            AdapterSelect.Fill(dt);

            dataGridView1.DataSource = dt.DefaultView;
            conn.Close();
        }

        private void re()
        {
            string constr = "server=localhost;User Id=root;password=root;Database=shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            MySqlDataAdapter AdapterSelect;
            string G_name = this.textBox1.Text;
            switch (this.con1.Text)
            {
                case "我的求购": AdapterSelect = new MySqlDataAdapter("select dem_id,goods_name,price,description from demands where user_name='" + username + "'", conn); break;
                case "我的回应": AdapterSelect = new MySqlDataAdapter("select a.dem_id,a.goods_name,a.price,a.description,a.user_name from demands a,response b where a.dem_id = b.dem_id ", conn); break;
                default: AdapterSelect = new MySqlDataAdapter("select dem_id,goods_name,price,description,user_name from demands", conn); break;
            }

            DataTable dt = new DataTable();
            AdapterSelect.Fill(dt);

            dataGridView1.DataSource = dt.DefaultView;
            conn.Close();
        }


            private void button1_Click(object sender, EventArgs e)
        {
            using (F_demands fd = new F_demands(username))
            {
                fd.ShowDialog();
            }
            re();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (F_response fr = new F_response(username))
            {
                fr.ShowDialog();
            }
            re();
        }
    }

}
