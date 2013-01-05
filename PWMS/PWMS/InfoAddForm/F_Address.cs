using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWMS.InfoAddForm
{
    public partial class F_Address : Form
    {
        public F_Address()
        {
            InitializeComponent();
        }

        PerForm.F_AddressList FrmAL = new PWMS.PerForm.F_AddressList();
        DataClass.MyMeans myDataClass = new PWMS.DataClass.MyMeans();
        ModuleClass.MyModule myMM = new PWMS.ModuleClass.MyModule();
        private static string Address_ID = "";
        private static DataSet MyDS;

        private void F_Address_Load(object sender, EventArgs e)
        {
            if ((int)this.Tag == 1)
            {
                Address_ID = myMM.GetAutocoding("tb_AddressBook", "ID");
            }
            else if ((int)this.Tag == 2)
            {
                if (ModuleClass.MyModule.Address_ID == "")
                {
                    MessageBox.Show("您未选中数据!");
                    this.Close();
                }
                else
                {
                    MyDS = myDataClass.getDataSet("select Name,Sex,Phone,Handset,WorkPhone,QQ,E_Mail from tb_AddressBook where ID='" + ModuleClass.MyModule.Address_ID + "'", "tb_AddressBook");
                    Address_ID = ModuleClass.MyModule.Address_ID;
                    Address_1.Text = MyDS.Tables[0].Rows[0][0].ToString();
                    Address_2.Text = MyDS.Tables[0].Rows[0][1].ToString();
                    Address_3.Text = MyDS.Tables[0].Rows[0][2].ToString();
                    Address_7.Text = MyDS.Tables[0].Rows[0][3].ToString();
                    Address_5.Text = MyDS.Tables[0].Rows[0][4].ToString();
                    Address_4.Text = MyDS.Tables[0].Rows[0][5].ToString();
                    Address_6.Text = MyDS.Tables[0].Rows[0][6].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Address_1.Text != "")
            {
                if ((int)this.Tag == 1)
                {
                    string AddStr = "insert into tb_AddressBook values('" + Address_ID + "','" + Address_1.Text + "','" + Address_2.Text +
                        "','" + Address_3.Text + "','" + Address_4.Text + "','" + Address_5.Text + "','" + Address_6.Text + "','" + Address_7.Text + "')";
                    myDataClass.getsqlcom(AddStr);
                    MessageBox.Show("添加成功！");
                }
                else if ((int)this.Tag == 2)
                {
                    string AddStr = "update tb_AddressBook set Name='" + Address_1.Text + "',Sex='" + Address_2.Text + "',Phone='" + Address_3.Text +
                        "',QQ='" + Address_4.Text + "',WorkPhone='" + Address_5.Text + "',E_Mail='" + Address_6.Text + "',Handset='" + Address_7.Text + "' where ID='" + Address_ID + "'";
                    myDataClass.getsqlcom(AddStr);
                    MessageBox.Show("修改成功！");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请将信息填写完整！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
