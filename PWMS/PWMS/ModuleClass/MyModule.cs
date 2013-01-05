using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PWMS.ModuleClass
{
    class MyModule
    {
        DataClass.MyMeans MyDataClass = new PWMS.DataClass.MyMeans();
        public static string ADDs = "";
        public static string FindValue = "";
        public static string Address_ID = "";
        public static string User_ID = "";
        public static string User_Name = "";


        public void Show_Form(string FrmName, int n)   //在主窗体中各级菜单调用各个窗口
        {                                              
            #region //一级菜单窗口调用
            if (n == 1)
            {
                if (FrmName == "人事档案管理")
                {
                    PerForm.F_ManFile FrmManFile = new PWMS.PerForm.F_ManFile();
                    FrmManFile.Text = "人事档案管理";
                    FrmManFile.ShowDialog();
                    FrmManFile.Dispose();
                }
                if (FrmName == "人事资料统计")
                {
                    PerForm.F_Stat FrmSat = new PWMS.PerForm.F_Stat();
                    FrmSat.Text = "人事资料统计";
                    FrmSat.ShowDialog();
                    FrmSat.Dispose();
                }
                if (FrmName == "日常记事")
                {
                    PerForm.F_WordPad FrmWordPad = new PWMS.PerForm.F_WordPad();
                    FrmWordPad.Text = "日常记事";
                    FrmWordPad.ShowDialog();
                    FrmWordPad.Dispose();
                }
                if (FrmName == "通讯录")
                {
                    PerForm.F_AddressList FrmAddressList = new PWMS.PerForm.F_AddressList();
                    FrmAddressList.Text = "通讯录";
                    FrmAddressList.ShowDialog();
                    FrmAddressList.Dispose();
                }
                if (FrmName == "备份/还原数据库")
                {
                    PerForm.F_HaveBack FrmHaveBack = new PWMS.PerForm.F_HaveBack();
                    FrmHaveBack.Text = "备份/还原数据库";
                    FrmHaveBack.ShowDialog();
                    FrmHaveBack.Dispose();
                }
                if (FrmName == "用户设置")
                {
                    PerForm.F_User FrmUser = new PWMS.PerForm.F_User();
                    FrmUser.Text = "用户设置";
                    FrmUser.ShowDialog();
                    FrmUser.Dispose();
                }
                if (FrmName == "重新登录")
                {
                    F_Login FrmLogin = new F_Login();
                    FrmLogin.Tag = 2;
                    FrmLogin.ShowDialog();
                    FrmLogin.Dispose();
                }
                if (FrmName == "计算器")
                {
                    System.Diagnostics.Process.Start("calc.exe");
                }
                if (FrmName == "记事本")
                {
                    System.Diagnostics.Process.Start("notepad.exe");
                }
                if (FrmName == "系统帮助")
                {
                    System.Diagnostics.Process.Start("readme.doc");
                }     
            }
            #endregion

            #region   //二级菜单栏窗口调用
            else if (n == 2)
            {
                string FrmStr = "";
                switch (FrmName)
                {
                    case "民族类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_Folk";
                        DataClass.MyMeans.Mean_Table = "tb_Folk";
                        DataClass.MyMeans.Mean_Field = "FolkName";
                        FrmStr = FrmName;
                        break;
                    case "职工类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_EmployeeGenre";
                        DataClass.MyMeans.Mean_Table = "tb_EmployeeGenre";
                        DataClass.MyMeans.Mean_Field = "EmployeeGenreName";
                        FrmStr = FrmName;
                        break;
                    case "文化程度设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_Kultur";
                        DataClass.MyMeans.Mean_Table = "tb_Kultur";
                        DataClass.MyMeans.Mean_Field = "KulturName";
                        FrmStr = FrmName;
                        break;
                    case "政治面貌设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_Visage";
                        DataClass.MyMeans.Mean_Table = "tb_Visage";
                        DataClass.MyMeans.Mean_Field = "VisageName";
                        FrmStr = FrmName;
                        break;
                    case "部门类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_Branch";
                        DataClass.MyMeans.Mean_Table = "tb_Branch";
                        DataClass.MyMeans.Mean_Field = "BranchName";
                        FrmStr = FrmName;
                        break;
                    case "工资类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_Laborage";
                        DataClass.MyMeans.Mean_Table = "tb_Laborage";
                        DataClass.MyMeans.Mean_Field = "LaborageName";
                        FrmStr = FrmName;
                        break;
                    case "职务类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_Business";
                        DataClass.MyMeans.Mean_Table = "tb_Business";
                        DataClass.MyMeans.Mean_Field = "BusinessName";
                        FrmStr = FrmName;
                        break;
                    case "职称类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_Duthcall";
                        DataClass.MyMeans.Mean_Table = "tb_Duthcall";
                        DataClass.MyMeans.Mean_Field = "DuthcallName";
                        FrmStr = FrmName;
                        break;
                    case "奖惩类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_RPKind";
                        DataClass.MyMeans.Mean_Table = "tb_RPKind";
                        DataClass.MyMeans.Mean_Field = "RPKindName";
                        FrmStr = FrmName;
                        break;
                    case "记事本类别设置":
                        DataClass.MyMeans.Mean_SQL = "select * from tb_WordPad";
                        DataClass.MyMeans.Mean_Table = "tb_WordPad";
                        DataClass.MyMeans.Mean_Field = "WordPadName";
                        FrmStr = FrmName;
                        break;
                    default:
                        break;
                }
                InfoAddForm.F_Basic FrmBasic = new PWMS.InfoAddForm.F_Basic();
                FrmBasic.Text = FrmStr;
                FrmBasic.ShowDialog();
                FrmBasic.Dispose();
            }
            #endregion
        }

        public void CoPassData(ComboBox cobox, string TableName)     //向comboBox控件传递数据表中的数据
        {
            cobox.Items.Clear();
            DataClass.MyMeans MyDataClsaa = new PWMS.DataClass.MyMeans();
            SqlDataReader MyDR = MyDataClsaa.getcom("select * from " + TableName);
            if (MyDR.HasRows)
            {
                while (MyDR.Read())
                {
                    if (MyDR[1].ToString() != "" && MyDR[1].ToString() != null)
                        cobox.Items.Add(MyDR[1].ToString());
                }
            }
        }

        public void CityInfo(ComboBox cobox, string SQLstr, int n)   //向comboBox控件传递各省市的名称
        {
            cobox.Items.Clear();
           // DataClass.MyMeans MyDataClsaa = new PWMS.DataClass.MyMeans();
            SqlDataReader MyDR = MyDataClass.getcom(SQLstr);
            if (MyDR.HasRows)
            {
                while (MyDR.Read())
                {
                    if (MyDR[n].ToString() != "" && MyDR[n].ToString() != null)
                        cobox.Items.Add(MyDR[n].ToString());
                }
            }
        }

        public string Date_Format(string NDate)   //将日期转换成指定的格式
        {
            string sm, sd;
            int y, m, d;
            
            try
            {
                y = Convert.ToDateTime(NDate).Year;
                m = Convert.ToDateTime(NDate).Month;
                d = Convert.ToDateTime(NDate).Day;
            }
            catch
            {
                return "";
            }
            if (y == 1900)
                return "";
            if (m < 10)
                sm = "0" + Convert.ToString(m);
            else
                sm = Convert.ToString(m);
            if (d < 10)
                sd = "0" + Convert.ToString(d);
            else
                sd = Convert.ToString(d);
            return Convert.ToString(y) + "-" + sm + "-" + sd;
        }

        public string Time_Format(string NDate)   //将时间转换成指定的格式
        {
            string sh, sm, se;
            int hh, mm, ss;
            try
            {
                hh = Convert.ToDateTime(NDate).Hour;
                mm = Convert.ToDateTime(NDate).Minute;
                ss = Convert.ToDateTime(NDate).Second;

            }
            catch
            {
                return "";
            }
            sh = Convert.ToString(hh);
            if (sh.Length < 2)
                sh = "0" + sh;
            sm = Convert.ToString(mm);
            if (sm.Length < 2)
                sm = "0" + sm;
            se = Convert.ToString(ss);
            if (se.Length < 2)
                se = "0" + se;
            return sh + sm + se;
        }

        public void MaskedTextBox_Format(MaskedTextBox MTBox)   //设置MaskedTextBox控件的格式
        {
            MTBox.Mask = "0000-00-00";
            MTBox.ValidatingType = typeof(System.DateTime);
        }

        public void Clear_Control(Control.ControlCollection Con)   //清空可视化控件中的信息
        {
            foreach (Control C in Con)
            {
                if (C.GetType().Name == "TextBox")
                    if (((TextBox)C).Visible == true)
                        ((TextBox)C).Clear();
                if (C.GetType().Name == "MaskedTextBox")
                    if (((MaskedTextBox)C).Visible == true)
                        ((MaskedTextBox)C).Clear();
                if (C.GetType().Name == "ComboBox")
                    if (((ComboBox)C).Visible == true)
                        ((ComboBox)C).Text = "";
            }
        }

        public string GetAutocoding(string TableName, string ID)
        {
            SqlDataReader myDr = MyDataClass.getcom("select max(" + ID + ") NID from " + TableName);
            int Num = 0;
            if (myDr.HasRows)
            {
                myDr.Read();
                if (myDr[0].ToString() == "")
                    return "0001";
                Num = Convert.ToInt32(myDr[0].ToString());
                ++Num;
                string s = string.Format("{0:0000}", Num);
                return s;
            }
            else
                return "0001";
        }

        public void ADD_Pope(string ID, int n)
        {
            DataSet DSet;
            DSet = MyDataClass.getDataSet("select PopeName from tb_PopeModel", "tb_PopeModel");
            for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
            {
                MyDataClass.getsqlcom("insert into tb_UserPope (ID,PopeName,Pope) values('" + ID + "','" + Convert.ToString(DSet.Tables[0].Rows[i][0]) + "'," + n + ")");
            }
        }

        public void GetMenu(TreeView tv, MenuStrip ms)
        {
            for (int i = 0; i < ms.Items.Count; i++)
            {
                TreeNode newNode1 = tv.Nodes.Add(ms.Items[i].Text);
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)ms.Items[i];
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                        TreeNode newNode2=newNode1.Nodes.Add(newmenu.DropDownItems[j].Text);
                        ToolStripDropDownItem newmenu1 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        if (newmenu1.HasDropDownItems && newmenu1.DropDownItems.Count > 0)
                            for (int p = 0; p < newmenu1.DropDownItems.Count; p++)
                                newNode2.Nodes.Add(newmenu1.DropDownItems[p].Text);
                    }

            }
        }

        /*public void MainMenuF(MenuStrip MenuS)      //设置主窗体菜单不可用
        {
            string Men = "";
            for (int i = 0; i < MenuS.Items.Count; i++)
            {
                Men = ((ToolStripDropDownItem)MenuS.Items[i]).Name;
                if (Men.IndexOf("Menu") == -1)
                    ((ToolStripDropDownItem)MenuS.Items[i]).Enabled = false;
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                        Men = newmenu.DropDownItems[j].Name;
                        if (Men.IndexOf("Menu") == -1)
                            newmenu.DropDownItems[j].Enabled = false;
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                                newmenu2.DropDownItems[p].Enabled = false;
                    }
            }

        }*/

        public void MainPope(MenuStrip MenuS, String UName)//根据用户权限设置主窗体菜单
        {
            string Str = "";
            string MenuName = "";
            DataSet DSet = MyDataClass.getDataSet("select ID from tb_Login where Name='" + UName + "'", "tb_Login");    //获取当前登录用户的信息
            string UID = Convert.ToString(DSet.Tables[0].Rows[0][0]);   //获取当前用户编号
            DSet = MyDataClass.getDataSet("select ID,PopeName,Pope from tb_UserPope where ID='" + UID + "'", "tb_UserPope");    //获取当前用户的权限信息
            bool bo = true;
            for (int k = 0; k < DSet.Tables[0].Rows.Count; k++) //遍历当前用户的权限名称
            {
                Str = Convert.ToString(DSet.Tables[0].Rows[k][1]);  //获取权限名称
                if (Convert.ToInt32(DSet.Tables[0].Rows[k][2]) == 1)    //判断权限是否可用
                    bo = true;
                else
                    bo = false;
                for (int i = 0; i < MenuS.Items.Count; i++) //遍历菜单栏中的一级菜单项
                {
                    ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];  //记录当前菜单项下的所有信息
                    if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)    //如果当前菜单项有子级菜单项
                        for (int j = 0; j < newmenu.DropDownItems.Count; j++)    //遍历二级菜单项
                        {
                            MenuName = newmenu.DropDownItems[j].Name;   //获取当前菜单项的名称
                            if (MenuName.IndexOf(Str) > -1) //如果包含权限名称
                                newmenu.DropDownItems[j].Enabled = bo;  //根据权限设置可用状态
                            ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];   //记录当前菜单项的所有信息
                            if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)  //如果当前菜单项有子级菜单项
                                for (int p = 0; p < newmenu2.DropDownItems.Count; p++)  //遍历三级菜单项
                                {
                                    MenuName = newmenu2.DropDownItems[p].Name;  //获取当前菜单项的名称
                                    if (MenuName.IndexOf(Str) > -1) //如果包含权限名称
                                        newmenu2.DropDownItems[p].Enabled = bo;  //根据权限设置可用状态
                                }
                        }
                }
            }
        }

        public void TreeMenuF(MenuStrip MenuS, TreeNodeMouseClickEventArgs e)//用TreeView控件调用StatusStrip控件下各菜单的单击事件
        {
            string Men = "";
            for (int i = 0; i < MenuS.Items.Count; i++) //遍历MenuStrip控件中主菜单项
            {
                Men = ((ToolStripDropDownItem)MenuS.Items[i]).Name; //获取主菜单项的名称
                if (Men.IndexOf("Menu") == -1)  //如果MenuStrip控件的菜单项没有子菜单
                {
                    if (((ToolStripDropDownItem)MenuS.Items[i]).Text == e.Node.Text)    //当节点名称与菜单项名称相等时
                        if (((ToolStripDropDownItem)MenuS.Items[i]).Enabled == false)   //判断当前菜单项是否可用
                        {
                            MessageBox.Show("当前用户无权限调用" + "\"" + e.Node.Text + "\"" + "窗体");
                            break;
                        }
                        else
                            Show_Form(((ToolStripDropDownItem)MenuS.Items[i]).Text.Trim(), 1);  //调用相应的窗体
                }
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)    //遍历二级菜单项
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                        Men = newmenu.DropDownItems[j].Name;    //获取二级菜单项的名称
                        if (Men.IndexOf("Menu") == -1)
                        {
                            if ((newmenu.DropDownItems[j]).Text == e.Node.Text)
                                if ((newmenu.DropDownItems[j]).Enabled == false)
                                {
                                    MessageBox.Show("当前用户无权限调用" + "\"" + e.Node.Text + "\"" + "窗体");
                                    break;
                                }
                                else
                                    Show_Form((newmenu.DropDownItems[j]).Text.Trim(), 1);
                        }
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)  //遍历三级菜单项
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                            {
                                if ((newmenu2.DropDownItems[p]).Text == e.Node.Text)
                                    if ((newmenu2.DropDownItems[p]).Enabled == false)
                                    {
                                        MessageBox.Show("当前用户无权限调用" + "\"" + e.Node.Text + "\"" + "窗体");
                                        break;
                                    }
                                    else
                                        if ((newmenu2.DropDownItems[p]).Text.Trim() == "员工生日提示" || (newmenu2.DropDownItems[p]).Text.Trim() == "员工合同提示")
                                            Show_Form((newmenu2.DropDownItems[p]).Text.Trim(), 1);
                                        else
                                            Show_Form((newmenu2.DropDownItems[p]).Text.Trim(), 2);
                            }
                    }
            }

        }

        public void SaveImage(string MID, byte[] p)
        {
            MyDataClass.con_open();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Stuffbusic Set Photo=@Photo where ID=" + MID);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), DataClass.MyMeans.My_con);
            cmd.Parameters.Add("@Photo", SqlDbType.Binary).Value = p;
            cmd.ExecuteNonQuery();
            DataClass.MyMeans.My_con.Close();
        }
    }
}
