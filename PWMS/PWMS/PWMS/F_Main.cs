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
        //private int childFormNumber = 0;
        ModuleClass.MyModule mymodule = new PWMS.ModuleClass.MyModule();//实例化一个MyModule对象

        public F_Main()
        {
            InitializeComponent();
            
        }

        /*private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }*/

        #region //实现各个窗口的调用
           #region //实现一级窗口的调用
        private void 人事资料查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 人事档案管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(),1);
        }

        private void 人事资料统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 日常记事ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 通讯录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 备份还原数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 清空数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 用户设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 系统退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
           #endregion
           #region   //实现工具栏窗口的调用
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton11_Click_1(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
           #endregion
           #region    //实现二级菜单的窗口调用
        private void 民族类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 职工类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 文化程度设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 政治面貌设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 部门类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 工资类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 职务类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 职称类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 奖惩类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 记事本类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mymodule.Show_Form(sender.ToString().Trim(), 2);
        }
           #endregion
        #endregion

        private void F_Main_Load(object sender, EventArgs e)
        {
            F_Login FrmLogin = new F_Login();   //声时登录窗体，进行调用
            FrmLogin.Tag = 1;   //将登录窗体的Tag属性设为1，表示调用的是登录窗体
            FrmLogin.ShowDialog();
            FrmLogin.Dispose();
            statusStrip1.Items[2].Text = DataClass.MyMeans.Login_Name;
            /*if (DataClass.MyMeans.Login_n == 1)
            {
                
            }*/
        }

        

    }
}
