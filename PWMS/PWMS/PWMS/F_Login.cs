using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PWMS.DataClass;


namespace PWMS
{
    public partial class F_Login : Form
    {
        DataClass.MyMeans MyClass = new PWMS.DataClass.MyMeans();
        public F_Login()
        {
            InitializeComponent();
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
                textPass.Focus();
        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
                butLogin.Focus();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" & textPass.Text != "")
            {
                SqlDataReader temDR = MyClass.getcom("select * from tb_Login where Name='" + textName.Text.
                    Trim() + "and Pass=" + textPass.Text.Trim() + "'");
                bool ifcom = temDR.Read();
                if (ifcom)
                {
                    DataClass.MyMeans.Login_Name = textName.Text.Trim();
                    DataClass.MyMeans.Login_ID = temDR.GetString(0);
                    DataClass.MyMeans.My_con.Dispose();
                    DataClass.MyMeans.Login_n = (int)(this.Tag);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";
                }
                MyClass.con_close();
            }
            else
                MessageBox.Show("请将登录信息填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void butClose_Click(object sender, EventArgs e)
        {
           
        }
    }
}
