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
    public partial class F_ManFile : Form
    {
        public F_ManFile()
        {
            InitializeComponent();
        }

        DataClass.MyMeans myMeansManFile = new PWMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleManFile = new PWMS.ModuleClass.MyModule();
        public static DataSet MyDS_Grid;
        public static string tem_Field = "";
        public static string tem_Value = "";
        public static string tem_ID = "";
        public static int hold_n = 0;
        public static string Part_ID = "";  //存储数据表的ID信息

        //显示“职工基本信息”表中的指定记录
        public string Grid_Inof(DataGridView DGrid)    
        {
            if (DGrid.RowCount > 1) 
            {
                S_0.Text = DGrid[0, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_1.Text = DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_2.Text = Convert.ToString(DGrid[2, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_3.Text = Convert.ToString(DGrid[3, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_4.Text = Convert.ToString(DGrid[4, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_5.Text = DGrid[5, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_6.Text = DGrid[6, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_7.Text = DGrid[7, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_8.Text = DGrid[8, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_9.Text = DGrid[9, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_10.Text =Convert.ToString(DGrid[10, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_11.Text = Convert.ToString(DGrid[11, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_12.Text = DGrid[12, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_13.Text = DGrid[13, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_14.Text = DGrid[14, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_15.Text = DGrid[15, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_16.Text = DGrid[16, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_17.Text = DGrid[17, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_18.Text = DGrid[18, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_19.Text = DGrid[19, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_20.Text = DGrid[20, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_21.Text = Convert.ToString(DGrid[21, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_22.Text = DGrid[22, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_23.Text = DGrid[23, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_24.Text = DGrid[24, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_25.Text = Convert.ToString(DGrid[25, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_26.Text = DGrid[26, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_27.Text = Convert.ToString(DGrid[27, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_28.Text = Convert.ToString(DGrid[28, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_29.Text = Convert.ToString(DGrid[29, DGrid.CurrentCell.RowIndex].Value).Trim();
                
                tem_ID = S_0.Text.Trim();  
                return DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString(); 
            }
            else
            {
                //使用MyMeans公共类中的Clear_Control()方法清空指定控件集中的相应控件
                MyModuleManFile.Clear_Control(tabControl1.TabPages[0].Controls); 
                tem_ID = "";
                return "";
            }
        }

        //按条件显示“职工基本信息”表的内容
        public void Condition_Lookup(string C_Value)    
        {
            MyDS_Grid = myMeansManFile.getDataSet("Select * from tb_Stuffbusic where " + tem_Field + "='" + tem_Value + "'", "tb_Stuffbusic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            textBox1.Text = Grid_Inof(dataGridView1);  //显示职工信息表的当前记录            
        }

        private void F_ManFile_Load(object sender, EventArgs e)
        {
            
            //用dataGridView1控件显示职工的名称
            MyDS_Grid = myMeansManFile.getDataSet(DataClass.MyMeans.AllSql, "tb_Stuffbusic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 80;

            for (int i = 2; i < dataGridView1.ColumnCount; i++)  //隐藏dataGridView1控件中不需要的列字段
            {
                dataGridView1.Columns[i].Visible = false;
            }
            /*MyModuleManFile.MaskedTextBox_Format(S_3);  //指定MaskedTextBox控件的格式
            MyModuleManFile.MaskedTextBox_Format(S_10);
            MyModuleManFile.MaskedTextBox_Format(S_21);
            MyModuleManFile.MaskedTextBox_Format(S_27);
            MyModuleManFile.MaskedTextBox_Format(S_28);*/

            MyModuleManFile.CoPassData(S_2, "tb_Folk");  //向“民族类别”列表框中添加信息
            MyModuleManFile.CoPassData(S_5, "tb_Kultur");  //向"文化程度”列表框中添加信息
            MyModuleManFile.CoPassData(S_8, "tb_Visage");  //向"正治面貌”列表框中添加信息
            MyModuleManFile.CoPassData(S_12, "tb_EmployeeGenre");  //向"职工类别”列表框中添加信息
            MyModuleManFile.CoPassData(S_13, "tb_Business");  //向"职务类别”列表框中添加信息
            MyModuleManFile.CoPassData(S_14, "tb_Laborage");  //向"工资类别”列表框中添加信息
            MyModuleManFile.CoPassData(S_15, "tb_Branch");  //向"部门类别”列表框中添加信息
            MyModuleManFile.CoPassData(S_16, "tb_Duthcall");  //向"职称类别”列表框中添加信息
            MyModuleManFile.CityInfo(S_23, "select distinct beaware from tb_City", 0);

            //S_23.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  //使S_BeAware控件具有查询功能
            //S_23.AutoCompleteSource = AutoCompleteSource.ListItems;

            textBox1.Text = Grid_Inof(dataGridView1);  //显示职工信息表的首记录
            DataClass.MyMeans.AllSql = "Select * from tb_Stuffbusic";

        }

        //实现条件查询下拉框的内容
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    MyModuleManFile.CityInfo(comboBox2, "select distinct StuffName from tb_Stuffbusic", 0);
                    tem_Field = "StuffName";
                    break;
                case 1:
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("男");
                    comboBox2.Items.Add("女");
                    tem_Field="Sex";
                    break;
                case 2:
                    MyModuleManFile.CoPassData(comboBox2, "tb_Folk");
                    tem_Field = "Folk";
                    break;
                case 3:
                    MyModuleManFile.CoPassData(comboBox2, "tb_Kultur");
                    tem_Field = "Kultur";
                    break;
                case 4:
                    MyModuleManFile.CoPassData(comboBox2, "tb_Visage");
                    tem_Field = "Visage";
                    break;
                case 5:
                    MyModuleManFile.CoPassData(comboBox2, "tb_EmployeeGenre");
                    tem_Field = "Employee";
                    break;
                case 6:
                    MyModuleManFile.CoPassData(comboBox2, "tb_Business");
                    tem_Field = "Business";
                    break;
                case 7:
                    MyModuleManFile.CoPassData(comboBox2, "tb_Branch");
                    tem_Field = "Branch";
                    break;
                case 8:
                    MyModuleManFile.CoPassData(comboBox2, "tb_Duthcall");
                    tem_Field = "Duthcall";
                    break;
                case 9:
                    MyModuleManFile.CoPassData(comboBox2, "tb_Laborage");
                    tem_Field = "Laborage";
                    break;
                default:
                    break;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            tem_Value = comboBox2.SelectedItem.ToString();
            Condition_Lookup(tem_Value);
        }

        private void Sut_Add_Click(object sender, EventArgs e)
        {
            MyModuleManFile.Clear_Control(tabControl1.TabPages[0].Controls);
            S_0.Text = MyModuleManFile.GetAutocoding("tb_Stuffbusic", "ID");
            hold_n = 1;
            Sut_Amend.Enabled = false;
            Sut_Delete.Enabled = false;
            Sut_Cancel.Enabled = true;
            Sut_Save.Enabled = true;
        }

        private void Sut_Amend_Click(object sender, EventArgs e)
        {
            hold_n = 2;
            Sut_Add.Enabled = false;
            Sut_Delete.Enabled = false;
            Sut_Cancel.Enabled = true;
            Sut_Save.Enabled = true;
        }

        private void Sut_Cancel_Click(object sender, EventArgs e)
        {
            hold_n = 0;
            Sut_Add.Enabled = true;
            Sut_Amend.Enabled = true;
            Sut_Delete.Enabled = true;
            if (tem_Field == "")
                button1_Click(sender, e);
            else
                Condition_Lookup(tem_Value);
            Sut_Cancel.Enabled = false;
            Sut_Save.Enabled = false;
        }

        private void Sut_Save_Click(object sender, EventArgs e)
        {
            DateTime time3 = Convert.ToDateTime(S_3.Text);
            DateTime time10 = Convert.ToDateTime(S_10.Text);
            DateTime time21 = Convert.ToDateTime(S_21.Text);
            DateTime time27 = Convert.ToDateTime(S_27.Text);
            DateTime time28 = Convert.ToDateTime(S_28.Text);
            if (hold_n == 1)
            {
                string Addstr = "insert into tb_Stuffbusic values('" + S_0.Text.Trim() + "','" + S_1.Text.Trim() +
                    "','" + S_2.Text.Trim() + "','" + time3 + "','" + S_4.Text.Trim() + "','" + S_5.Text.Trim() +
                    "','" + S_6.Text.Trim() + "','" + S_7.Text.Trim() + "','" + S_8.Text.Trim() + "','" + S_9.Text.Trim() +
                    "','" + time10 + "','" + S_11.Text.Trim() + "','" + S_12.Text.Trim() + "','" + S_13.Text.Trim() + 
                    "','" + S_14.Text.Trim() + "','" + S_15.Text.Trim() + "','" + S_16.Text.Trim() + "','" + S_17.Text.Trim() +
                    "','" + S_18.Text.Trim() + "','" + S_19.Text.Trim() + "','" + S_20.Text.Trim() + "','" + time21 +
                    "','" + S_22.Text.Trim() + "','" + S_23.Text.Trim() + "','" + S_24.Text.Trim() + "','" + S_25.Text.Trim() +
                    "','" + S_26.Text.Trim() + "','" + time27 + "','" + time28 + "','" + S_29.Text.Trim() + "')";
                myMeansManFile.getsqlcom(Addstr);
                hold_n = 0;
                MessageBox.Show("添加成功");
                Sut_Amend.Enabled = true;
                Sut_Delete.Enabled = true;
                Sut_Cancel.Enabled = false;
                Sut_Save.Enabled = false;
            }
            if (hold_n == 2)
            {
                string Addstr = "update tb_Stuffbusic set StuffName='"+ S_1.Text.Trim() +
                    "',Folk='" + S_2.Text.Trim() + "',Birthday='" + time3 + "',Age='" + S_4.Text.Trim() + "',Kultur='" + S_5.Text.Trim() +
                    "',Marriage='" + S_6.Text.Trim() + "',Sex='" + S_7.Text.Trim() + "',Visage='" + S_8.Text.Trim() + "',IDCard='" + S_9.Text.Trim() +
                    "',workdate='" + time10 + "',WorkLength='" + S_11.Text.Trim() + "',Employee='" + S_12.Text.Trim() + "',Business='" + S_13.Text.Trim() +
                    "',Laborage='" + S_14.Text.Trim() + "',Branch='" + S_15.Text.Trim() + "',Duthcall='" + S_16.Text.Trim() + "',Phone='" + S_17.Text.Trim() +
                    "',Handset='" + S_18.Text.Trim() + "',School='" + S_19.Text.Trim() + "',Speciality='" + S_20.Text.Trim() + "',GraduateDate='" + time21 +
                    "',Address='" + S_22.Text.Trim() + "',BeAware='" + S_23.Text.Trim() + "',City='" + S_24.Text.Trim() + "',M_Pay='" + S_25.Text.Trim() +
                    "',Bank='" + S_26.Text.Trim() + "',Pact_B='" + time27 + "',Pact_E='" + time28 + "',Pact_Y='" + S_29.Text.Trim() + "' where ID='" + S_0.Text.Trim() + "'";
                myMeansManFile.getsqlcom(Addstr);
                hold_n = 0;
                MessageBox.Show("修改成功");
                Sut_Add.Enabled = true;
                Sut_Delete.Enabled = true;
                Sut_Cancel.Enabled = false;
                Sut_Save.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDS_Grid = myMeansManFile.getDataSet(DataClass.MyMeans.AllSql, "tb_Stuffbusic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            
            textBox1.Text = Grid_Inof(dataGridView1);
        }

        private void Sut_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 2) //判断dataGridView1控件中是否有记录
            {
                MessageBox.Show("数据表为空，不可以删除。");
                return;
            }
            myMeansManFile.getsqlcom("Delete tb_Stuffbusic where ID='" + S_0.Text.Trim() + "'");
            Sut_Cancel_Click(sender, e);  
        }

        private void S_23_SelectedIndexChanged(object sender, EventArgs e)
        {
            S_24.Items.Clear();
            MyModuleManFile.CityInfo(S_24, "select beaware,city from tb_City where beaware='" + S_23.Text.Trim() + "'", 1);
        }


    }
}
