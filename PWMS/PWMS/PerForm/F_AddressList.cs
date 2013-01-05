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
    public partial class F_AddressList : Form
    {
        public F_AddressList()
        {
            InitializeComponent();
        }

        DataClass.MyMeans MyDataClass = new PWMS.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new PWMS.ModuleClass.MyModule();
        private static DataSet MyDS_Grid;
        private static string tempFile = "";

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入查询条件");
                return;
            }
            MyDS_Grid = MyDataClass.getDataSet("Select * from tb_AddressBook where " + tempFile + "='" + textBox1.Text + "'", "tb_AddressBook");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    tempFile = "ID";
                    break;
                case 1:
                    tempFile = "Name";
                    break;
                case 2:
                    tempFile = "Sex";
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDS_Grid = MyDataClass.getDataSet("Select * from tb_AddressBook", "tb_AddressBook");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
        }

        private void Address_Add_Click(object sender, EventArgs e)
        {
            InfoAddForm.F_Address FrmAddress = new PWMS.InfoAddForm.F_Address();
            FrmAddress.Text = "通讯录添加操作";
            FrmAddress.Tag = 1;
            FrmAddress.ShowDialog();
        }

        private void F_AddressList_Activated(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            ModuleClass.MyModule.Address_ID = "";
            if (dataGridView1.RowCount < 2)
            {
                Address_Amend.Enabled = false;
                Address_Delete.Enabled = false;
            }
            else
            {
                Address_Amend.Enabled = true;
                Address_Delete.Enabled = true;
            }
        }

        private void Address_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Address_Amend_Click(object sender, EventArgs e)
        {
            InfoAddForm.F_Address FrmAddress = new PWMS.InfoAddForm.F_Address();
            FrmAddress.Text = "通讯录修改操作";
            FrmAddress.Tag = 2;
            FrmAddress.ShowDialog();
        }

        private void Address_Delete_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.Address_ID != "")
            {
                if (MessageBox.Show("确定要删除此条信息嘛？", "Delete Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    MyDataClass.getsqlcom("delete from tb_AddressBook where ID='" + ModuleClass.MyModule.Address_ID + "'");
                    MessageBox.Show("删除成功!");
                }

            }
            else
                MessageBox.Show("您未选中有效数据!");
           
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ModuleClass.MyModule.Address_ID = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        }


    }
}