using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWMS
{
    public partial class F_Main : Form
    {
        ModuleClass.MyModule mymodule = new PWMS.ModuleClass.MyModule();//实例化一个MyModule对象

        public F_Main()
        {
            InitializeComponent();

        }

        #region //实现各个窗口的调用
        #region //实现一级窗口的调用
        private void Tool_Stuffbusic_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(),1);
        }

        private void Tool_Stusum_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_DayWordPad_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_AddressBook_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Back_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_NewLogon_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Setup_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_WordBook_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Counter_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Menu_9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tool_Help_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

           #endregion
           #region   //实现工具栏窗口的调用
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (Button_Stuffbusic.Enabled == true)
                mymodule.Show_Form(sender.ToString().Trim(), 1);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (Button_Stusum.Enabled == true)
                mymodule.Show_Form(sender.ToString().Trim(), 1);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (Button_AddressBook.Enabled == true)
                mymodule.Show_Form(sender.ToString().Trim(), 1);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        
        }

        private void toolStripButton11_Click_1(object sender, EventArgs e)
        {
            if (Button_DayWordPad.Enabled == true)
                mymodule.Show_Form(sender.ToString().Trim(), 1);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

           #endregion
           #region    //实现二级菜单的窗口调用
        private void Tool_Folk_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_EmployeeGenre_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Kultur_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Visage_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Branch_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Laborage_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Business_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Duthcall_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_WordPad_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }
           #endregion
        #endregion

        private void Preen_Main()
        {
            statusStrip1.Items[2].Text = DataClass.MyMeans.Login_Name;  //在状态栏显示当前登录的用户名
            treeView1.Nodes.Clear();
            mymodule.GetMenu(treeView1, menuStrip1);  //调用公共类MyModule下的GetMenu()方法，将menuStrip1控件的子菜单添加到treeView1控件中
            //mymodule.MainMenuF(menuStrip1);   //将菜单栏中的各子菜单项设为不可用状态
            mymodule.MainPope(menuStrip1, DataClass.MyMeans.Login_Name);  //根据权限设置相应子菜单的可用状态
        }

        private void F_Main_Load(object sender, EventArgs e)
        {
            F_Login FrmLogin = new F_Login();   //声时登录窗体，进行调用
            FrmLogin.Tag = 1;   //将登录窗体的Tag属性设为1，表示调用的是登录窗体
            FrmLogin.ShowDialog();
            FrmLogin.Dispose();
            statusStrip1.Items[2].Text = DataClass.MyMeans.Login_Name;
            if (DataClass.MyMeans.Login_n == 1)
            {
                Preen_Main();
            }
            DataClass.MyMeans.Login_n = 3;
            Tool_Help.Enabled = true;
        }

        private void F_Main_Activated(object sender, EventArgs e)
        {
            if (DataClass.MyMeans.Login_n == 2) 
                Preen_Main();   
            DataClass.MyMeans.Login_n = 3;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Trim() == "系统退出")   
            {
                Application.Exit(); 
            }
            mymodule.TreeMenuF(menuStrip1, e);
        }

    }
}
