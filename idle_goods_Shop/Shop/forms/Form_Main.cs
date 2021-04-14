using Shop.UserControls;
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
    public partial class Form_Main : Form
    {
        int PanelWidth;
        bool isCollapsed;
        string username = "";
        public Form_Main(string name)              //登录成功后传入用户名
        {
            username = name;
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            label4.Text = username;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if(panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if(panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;        //居中显示
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            UC_Home uch = new UC_Home(username);
            AddControlsToPanel(uch);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uch = new UC_Home(username);
            AddControlsToPanel(uch);
        }

        private void btnResponse_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnResponse);
            UC_Goods ucg = new UC_Goods(username);
            AddControlsToPanel(ucg);

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnOrder);
            UC_Buy ucb = new UC_Buy(username);
            AddControlsToPanel(ucb);
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            UC_Person ucb = new UC_Person(username);
            moveSidePanel(btnPerson);
            AddControlsToPanel(ucb);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSell);
            UC_Sell ucb = new UC_Sell(username);
            AddControlsToPanel(ucb);
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSell);
            UC_Sell ucb = new UC_Sell(username);
            AddControlsToPanel(ucb);
        }

        private void btnRes_Click_1(object sender, EventArgs e)
        {
            moveSidePanel(btnRes);
            UC_Response ucb = new UC_Response(username);
            AddControlsToPanel(ucb);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_About);
            UC_About ucb = new UC_About();
            AddControlsToPanel(ucb);
        }
    }
}
