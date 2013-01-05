using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWMS.PerForm
{
    public partial class F_UserAdd : Form
    {
        public F_UserAdd()
        {
            InitializeComponent();
        }

        ModuleClass.MyModule myModule = new PWMS.ModuleClass.MyModule();
        DataClass.MyMeans myDataClass = new PWMS.DataClass.MyMeans();
        private static DataSet myDS;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_UserAdd_Load(object sender, EventArgs e)
        {
            if ((int)this.Tag == 1)
            {
                ModuleClass.MyModule.User_ID = myModule.GetAutocoding("tb_Login", "ID");
            }
            else if ((int)this.Tag == 2)
            {
                myDS = myDataClass.getDataSet("select Name,Pass from tb_Login where ID='" + ModuleClass.MyModule.User_ID + "'", "tb_Login");
                text_Name.Text=myDS.Tables[0].Rows[0][0].ToString();
                text_Pass.Text = myDS.Tables[0].Rows[0][0].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((int)this.Tag == 1)
            {
                myDS = myDataClass.getDataSet("select * from tb_login where Name='"+text_Name.Text.Trim()+"'", "tb_Login");
                if (myDS.Tables[0].Rows.Count < 1 && text_Name.Text != "" && text_Pass.Text != "")
                {
                    string AddStr = "insert into tb_Login values('" + ModuleClass.MyModule.User_ID + "','" + text_Name.Text.Trim() + "','" + text_Pass.Text.Trim() + "')";
                    myDataClass.getsqlcom(AddStr);
                    myModule.ADD_Pope(ModuleClass.MyModule.User_ID, 0);
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    if (myDS.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("用户名已存在！");
                        text_Name.Text = "";
                        text_Pass.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("请将信息填写完整！");
                    }
                }
            }
            else if ((int)this.Tag == 2)
            {
                if (text_Name.Text != "" && text_Pass.Text != "")
                {
                    string AddStr = "update tb_Login set Name='" + text_Name.Text.Trim() + "',Pass='" + text_Pass.Text.Trim() + "' where ID='" + ModuleClass.MyModule.User_ID + "'";
                    myDataClass.getsqlcom(AddStr);
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
                else
                {
                        MessageBox.Show("请将信息填写完整！");
                }
            }
        }
    }
}
