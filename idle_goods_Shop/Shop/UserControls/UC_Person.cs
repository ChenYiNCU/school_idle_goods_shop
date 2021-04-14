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
    public partial class UC_Person : UserControl
    {
        string username = "";
        String sex = "";
        String home = "";
        String tel = "";

        public UC_Person(string name)
        {
            InitializeComponent();
            username = name;
            userBOX.Text = username;
            sexBox.Text = sex;
            homeBOX.Text = home;
            telBox.Text = tel;
        }

        //点击查看，信息会在文本框里显示
        private void watchButton_Click(object sender, EventArgs e)
        {
            String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            String sql = "select * from personInfo where person_name='" + userBOX.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            //查询操作
            MySqlDataReader read = cmd.ExecuteReader();
            if(read.Read())
            {
                sexBox.Text = read["person_sex"].ToString();
                homeBOX.Text = read["person_home"].ToString();
                telBox.Text = read["person_tel"].ToString();
            }
            read.Close();
            conn.Close();
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            String connetStr = "server=localhost;port=3306;user=root;password=root; database=Shop;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            String update_sql = "update personinfo set person_name ='" + userBOX.Text + "',person_sex='" + sexBox.Text + "',person_home='" + homeBOX.Text + "',person_tel='" + telBox.Text + "'where person_name ='" + userBOX.Text + "'";
            MySqlCommand cmd = new MySqlCommand(update_sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("修改成功！点击查看刷新信息页！");
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }
    }
}
