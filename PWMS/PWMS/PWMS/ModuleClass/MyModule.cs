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
                if (FrmName == "人事资料查询")
                {
                    PerForm.F_Find FrmFind = new PWMS.PerForm.F_Find();
                    FrmFind.Text = "人事资料查询";
                    FrmFind.ShowDialog();
                    FrmFind.Dispose();
                }
                if (FrmName == "人事资料统计")
                {
                    PerForm.F_Stat FrmSat = new PWMS.PerForm.F_Stat();
                    FrmSat.Text = "人事资料统计";
                    FrmSat.ShowDialog();
                    FrmSat.Dispose();
                }
                if (FrmName == "员工合同提示")
                {
                    InfoAddForm.F_ClewSet FrmClewSet = new PWMS.InfoAddForm.F_ClewSet();
                    FrmClewSet.Text = "员工合同提示";
                    FrmClewSet.ShowDialog();
                    FrmClewSet.Dispose();
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
                if (FrmName == "清空数据库")
                {
                    PerForm.F_ClearData FrmClearData = new PWMS.PerForm.F_ClearData();
                    FrmClearData.Text = "清空数据库";
                    FrmClearData.ShowDialog();
                    FrmClearData.Dispose();
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
                /*if (FrmName == "计算器")
                {
                    System.Diagnostics.Process.Start("calc.exe");
                }
                if (FrmName == "记事本")
                {
                    System.Diagnostics.Process.Start("notepad.exe");
                }*/                
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
    }
}
