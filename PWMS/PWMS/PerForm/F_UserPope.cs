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
    public partial class F_UserPope : Form
    {
        public F_UserPope()
        {
            InitializeComponent();
        }

        DataClass.MyMeans myDataClass = new PWMS.DataClass.MyMeans();
        private static DataSet myDS;

        private void F_UserPope_Load(object sender, EventArgs e)
        {
            User_ID.Text = ModuleClass.MyModule.User_ID;
            User_Name.Text = ModuleClass.MyModule.User_Name;
            myDS = myDataClass.getDataSet("select PopeName,Pope from tb_UserPope where ID='"+User_ID.Text.Trim()+"'", "tb_UserPope");
            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                
                if (Convert.ToInt32(myDS.Tables[0].Rows[i][1].ToString()) == 1)
                {
                    foreach (Control c in groupBox2.Controls)
                    {
                        if (c.Name.IndexOf(myDS.Tables[0].Rows[i][0].ToString()) > -1)
                        {
                            ((CheckBox)c).Checked = true; 
                        }
                    }
                }
                else
                {
                    foreach (Control c in groupBox2.Controls)
                    {
                        
                        if (c.Name.IndexOf(myDS.Tables[0].Rows[i][0].ToString()) > -1)
                        {
                            ((CheckBox)c).Checked = false;

                        }
                    }
                } 
            }
            
        }

        private void User_All_Click(object sender, EventArgs e)
        {
            if (User_All.Checked)
            {
                foreach (Control C in groupBox2.Controls)
                {
                    ((CheckBox)C).Checked = true;
                }
            }
            else
                F_UserPope_Load(sender, e);
        }

        private void User_Save_Click(object sender, EventArgs e)
        {
            foreach (Control C in groupBox2.Controls)
            {
                string[] str = C.Name.Split(Convert.ToChar("_"));
                if (((CheckBox)C).Checked)
                    myDataClass.getsqlcom("update tb_UserPope set Pope=1 where (ID='" + ModuleClass.MyModule.User_ID + "') and (PopeName='" + str[1].ToString() + "')");
                else
                    myDataClass.getsqlcom("update tb_UserPope set Pope=0 where (ID='" + ModuleClass.MyModule.User_ID + "') and (PopeName='" + str[1].ToString() + "')");
            }
            if(MessageBox.Show("修改权限成功!")==DialogResult.OK)
                this.Close();
        }

        private void User_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
