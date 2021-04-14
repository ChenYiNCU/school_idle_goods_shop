using Shop.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Shop
{
    public partial class Form1 : Form
    {
        string username="";
        string password = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = User.Text.ToString();
            password = Password.Text.ToString();
            String connetStr = "server=localhost;port=3306;user=root;password=111111; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            string sql = "select * from login where login_name='" + username + "'and login_pw='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            read.Read();
            if(read.HasRows)
            {
                using (Form_Main fm = new Form_Main(username))
                {
                    fm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("登录失败！请重新登录...");
            }
        }
    }
}
