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
    public partial class F_User : Form
    {
        public F_User()
        {
            InitializeComponent();
        }

        DataClass.MyMeans myDataClass = new PWMS.DataClass.MyMeans();
        ModuleClass.MyModule myModule = new PWMS.ModuleClass.MyModule();
        private static DataSet myDS;

        private void F_User_Activated(object sender, EventArgs e)
        {
            ModuleClass.MyModule.User_ID = "";
            ModuleClass.MyModule.User_Name = "";

            myDS = myDataClass.getDataSet("select ID,Name from tb_Login", "tb_Login");
            dataGridView1.DataSource = myDS.Tables[0];
            if (dataGridView1.RowCount < 2)
            {
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
            }
            else
            {
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            F_UserAdd FrmUserAdd = new F_UserAdd();
            FrmUserAdd.Text = "用户添加操作";
            FrmUserAdd.Tag = 1;
            FrmUserAdd.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID == "")
            {
                MessageBox.Show("您未选中数据!");
                return;
            }
            F_UserAdd FrmUserAmd = new F_UserAdd();
            FrmUserAmd.Text = "用户修改操作";
            FrmUserAmd.Tag = 2;
            FrmUserAmd.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ModuleClass.MyModule.User_ID = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            ModuleClass.MyModule.User_Name = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID == "")
            {
                MessageBox.Show("您未选中数据!");
                return;
            }
            else
            {
                if (ModuleClass.MyModule.User_ID != DataClass.MyMeans.Login_ID)
                {
                    myDataClass.getsqlcom("Delete from tb_Login where ID='" + ModuleClass.MyModule.User_ID.Trim() + "'");
                    myDataClass.getsqlcom("Delete from tb_UserPope where ID='" + ModuleClass.MyModule.User_ID.Trim() + "'");
                    MessageBox.Show("删除成功!");
                }
                else
                {
                    MessageBox.Show("不能删除当前登录用户!");
                }
            }
        }

        private void F_User_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID == "")
            {
                MessageBox.Show("您未选中数据!");
                return;
            }
            F_UserPope FrmUserPope = new F_UserPope();
            FrmUserPope.Text = "用户权限设置";
            FrmUserPope.ShowDialog();
        }


    }
}
