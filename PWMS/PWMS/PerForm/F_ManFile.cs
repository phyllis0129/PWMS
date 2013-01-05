using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

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
        public static byte[] imgBytesIn;  //用来存储图片的二进制数
        public static int Ima_n = 0;  //判断是否对图片进行了操作
        public static string Part_ID = "";  //存储数据表的ID信息

        public void ShowData_Image(byte[] DI, PictureBox Ima)  //显示数据库图片
        {
            byte[] buffer = DI;
            MemoryStream ms = new MemoryStream(buffer);
            Ima.Image = Image.FromStream(ms);
        }

        //显示“职工基本信息”表中的指定记录
        public string Grid_Inof(DataGridView DGrid)    
        {
            byte[] pic;
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

                try
                {
                    //将数据库中的图片存入到字节数组中
                    pic = (byte[])(MyDS_Grid.Tables[0].Rows[DGrid.CurrentCell.RowIndex][30]);
                    MemoryStream ms = new MemoryStream(pic);			//将字节数组存入到二进制流中
                    S_Photo.Image = Image.FromStream(ms);   //二进制流Image控件中显示
                }
                catch { S_Photo.Image = null; } //当出现错误时，将Image控件清空
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

        public void Read_Image(OpenFileDialog openF, PictureBox MyImage)   //将图片转换为字节数组
        {
            openF.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";   //指定OpenFileDialog控件打开的文件格式
            if (openF.ShowDialog(this) == DialogResult.OK)  //如果打开了图片文件
            {
                try
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);  //将图片文件存入到PictureBox控件中
                    string strimg = openF.FileName.ToString();  //记录图片的所在路径
                    FileStream fs = new FileStream(strimg, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
                    BinaryReader br = new BinaryReader(fs);
                    imgBytesIn = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    S_Photo.Image = null;
                }
            }
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
            Img_Clear.Enabled = true;   
            Img_Save.Enabled = true;
        }

        private void Sut_Amend_Click(object sender, EventArgs e)
        {
            hold_n = 2;
            Sut_Add.Enabled = false;
            Sut_Delete.Enabled = false;
            Sut_Cancel.Enabled = true;
            Sut_Save.Enabled = true;
            Img_Clear.Enabled = true;
            Img_Save.Enabled = true;
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
            Img_Clear.Enabled = false;
            Img_Save.Enabled = false;
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
                if (Ima_n > 0)  //如果图片标识大于0
                {
                    //通过MyModule公共类中r的SaveImage()方法将图片存入数据库中
                    MyModuleManFile.SaveImage(S_0.Text.Trim(), imgBytesIn);
                }

                hold_n = 0;
                MessageBox.Show("添加成功");
                Sut_Amend.Enabled = true;
                Sut_Delete.Enabled = true;
                Sut_Cancel.Enabled = false;
                Sut_Save.Enabled = false;
                Img_Clear.Enabled = false;
                Img_Save.Enabled = false;
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
                if (Ima_n > 0)  //如果图片标识大于0
                {
                    //通过MyModule公共类中r的SaveImage()方法将图片存入数据库中
                    MyModuleManFile.SaveImage(S_0.Text.Trim(), imgBytesIn);
                }

                hold_n = 0;
                MessageBox.Show("修改成功");
                Sut_Add.Enabled = true;
                Sut_Delete.Enabled = true;
                Sut_Cancel.Enabled = false;
                Sut_Save.Enabled = false;
                Img_Clear.Enabled = false;
                Img_Save.Enabled = false;
            }
            button1_Click(sender, e);
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
            if (MessageBox.Show("确定要删除此条信息吗?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                myMeansManFile.getsqlcom("Delete tb_Stuffbusic where ID='" + S_0.Text.Trim() + "'");
                MessageBox.Show("删除成功!");
            }
            Sut_Cancel_Click(sender, e);  
        }

        private void S_23_SelectedIndexChanged(object sender, EventArgs e)
        {
            S_24.Items.Clear();
            MyModuleManFile.CityInfo(S_24, "select beaware,city from tb_City where beaware='" + S_23.Text.Trim() + "'", 1);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Grid_Inof(dataGridView1);
        }

        private void Sub_Table_Click(object sender, EventArgs e)
        {
            object Nothing = System.Reflection.Missing.Value;
            object missing = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordApp.Visible = true;

            //设置文档宽度
            wordApp.Selection.PageSetup.LeftMargin = wordApp.CentimetersToPoints(float.Parse("2"));
            wordApp.ActiveWindow.ActivePane.HorizontalPercentScrolled = 11;
            wordApp.Selection.PageSetup.RightMargin = wordApp.CentimetersToPoints(float.Parse("2"));

            Object start = Type.Missing;
            Object end = Type.Missing;

            PictureBox pp = new PictureBox();   //新建一个PictureBox控件
            int p1 = 0;
            for (int i = 0; i < MyDS_Grid.Tables[0].Rows.Count; i++)
            {
                try
                {
                    byte[] pic = (byte[])(MyDS_Grid.Tables[0].Rows[i][30]); //将数据库中的图片转换成二进制流
                    MemoryStream ms = new MemoryStream(pic);			//将字节数组存入到二进制流中
                    pp.Image = Image.FromStream(ms);   //二进制流Image控件中显示
                    pp.Image.Save(@"C:\22.bmp");    //将图片存入到指定的路径
                }
                catch
                {
                    p1 = 1;
                }
                object rng = Type.Missing;
                string strInfo = "职工基本信息表" + "(" + MyDS_Grid.Tables[0].Rows[i][1].ToString() + ")";
                start = 0;
                end = 0;
                wordDoc.Range(ref start, ref end).InsertBefore(strInfo);    //插入文本
                wordDoc.Range(ref start, ref end).Font.Name = "Verdana";    //设置字体
                wordDoc.Range(ref start, ref end).Font.Size = 20;   //设置字体大小
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中

                start = strInfo.Length;
                end = strInfo.Length;
                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车

                object missingValue = Type.Missing;
                object location = strInfo.Length; //如果location超过已有字符的长度将会出错。一定要比"明细表"串多一个字符
                Microsoft.Office.Interop.Word.Range rng2 = wordDoc.Range(ref location, ref location);
                Microsoft.Office.Interop.Word.Table tab = wordDoc.Tables.Add(rng2, 14, 6, ref missingValue, ref missingValue);

                tab.Rows.HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAtLeast;
                tab.Rows.Height = wordApp.CentimetersToPoints(float.Parse("0.8"));
                tab.Range.Font.Size = 10;
                tab.Range.Font.Name = "宋体";

                //设置表格样式
                tab.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                tab.Borders.InsideLineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
                tab.Borders.InsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;
                wordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐

                //第5行显示
                tab.Cell(1, 5).Merge(tab.Cell(5, 6));
                //第6行显示
                tab.Cell(6, 5).Merge(tab.Cell(6, 6));
                //第9行显示
                tab.Cell(9, 4).Merge(tab.Cell(9, 6));
                //第12行显示
                tab.Cell(12, 2).Merge(tab.Cell(12, 6));
                //第13行显示
                tab.Cell(13, 2).Merge(tab.Cell(13, 6));
                //第14行显示
                tab.Cell(14, 2).Merge(tab.Cell(14, 6));

                //第1行赋值
                tab.Cell(1, 1).Range.Text = "职工编号：";
                tab.Cell(1, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][0].ToString();
                tab.Cell(1, 3).Range.Text = "职工姓名：";
                tab.Cell(1, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][1].ToString();

                //插入图片

                if (p1 == 0)
                {
                    string FileName = @"C:\22.bmp";//图片所在路径
                    object LinkToFile = false;
                    object SaveWithDocument = true;
                    object Anchor = tab.Cell(1, 5).Range;    //指定图片插入的区域
                    //将图片插入到单元格中
                    tab.Cell(1, 5).Range.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                }
                p1 = 0;

                //第2行赋值
                tab.Cell(2, 1).Range.Text = "民族类别：";
                tab.Cell(2, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][2].ToString();
                tab.Cell(2, 3).Range.Text = "出生日期：";
                try
                {
                    tab.Cell(2, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][3]).ToShortDateString());
                }
                catch { tab.Cell(2, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][3]);
                //第3行赋值
                tab.Cell(3, 1).Range.Text = "年龄：";
                tab.Cell(3, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][4]);
                tab.Cell(3, 3).Range.Text = "文化程度：";
                tab.Cell(3, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][5].ToString();
                //第4行赋值
                tab.Cell(4, 1).Range.Text = "婚姻：";
                tab.Cell(4, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][6].ToString();
                tab.Cell(4, 3).Range.Text = "性别：";
                tab.Cell(4, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][7].ToString();
                //第5行赋值
                tab.Cell(5, 1).Range.Text = "政治面貌：";
                tab.Cell(5, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][8].ToString();
                tab.Cell(5, 3).Range.Text = "单位工作时间：";
                try
                {
                    tab.Cell(5, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[0][10]).ToShortDateString());
                }
                catch { tab.Cell(5, 4).Range.Text = ""; }
                //第6行赋值
                tab.Cell(6, 1).Range.Text = "籍贯：";
                tab.Cell(6, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][23].ToString();
                tab.Cell(6, 3).Range.Text = MyDS_Grid.Tables[0].Rows[i][24].ToString();
                tab.Cell(6, 4).Range.Text = "身份证：";
                tab.Cell(6, 5).Range.Text = MyDS_Grid.Tables[0].Rows[i][9].ToString();
                //第7行赋值
                tab.Cell(7, 1).Range.Text = "工龄：";
                tab.Cell(7, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][11]);
                tab.Cell(7, 3).Range.Text = "职工类别：";
                tab.Cell(7, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][12].ToString();
                tab.Cell(7, 5).Range.Text = "职务类别：";
                tab.Cell(7, 6).Range.Text = MyDS_Grid.Tables[0].Rows[i][13].ToString();
                //第8行赋值
                tab.Cell(8, 1).Range.Text = "工资类别：";
                tab.Cell(8, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][14].ToString();
                tab.Cell(8, 3).Range.Text = "部门类别：";
                tab.Cell(8, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][15].ToString();
                tab.Cell(8, 5).Range.Text = "职称类别：";
                tab.Cell(8, 6).Range.Text = MyDS_Grid.Tables[0].Rows[i][16].ToString();
                //第9行赋值
                tab.Cell(9, 1).Range.Text = "月工资：";
                tab.Cell(9, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][25]);
                tab.Cell(9, 3).Range.Text = "银行账号：";
                tab.Cell(9, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][26].ToString();
                //第10行赋值
                tab.Cell(10, 1).Range.Text = "合同起始日期：";
                try
                {
                    tab.Cell(10, 2).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][27]).ToShortDateString());
                }
                catch { tab.Cell(10, 2).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][28]);
                tab.Cell(10, 3).Range.Text = "合同结束日期：";
                try
                {
                    tab.Cell(10, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][28]).ToShortDateString());
                }
                catch { tab.Cell(10, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][29]);
                tab.Cell(10, 5).Range.Text = "合同年限：";
                tab.Cell(10, 6).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][29]);
                //第11行赋值
                tab.Cell(11, 1).Range.Text = "电话：";
                tab.Cell(11, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][17].ToString();
                tab.Cell(11, 3).Range.Text = "手机：";
                tab.Cell(11, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][18].ToString();
                tab.Cell(11, 5).Range.Text = "毕业时间：";
                try
                {
                    tab.Cell(11, 6).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][21]).ToShortDateString());
                }
                catch { tab.Cell(11, 6).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][21]);
                //第12行赋值
                tab.Cell(12, 1).Range.Text = "毕业学校：";
                tab.Cell(12, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][19].ToString();
                //第13行赋值
                tab.Cell(13, 1).Range.Text = "主修专业：";
                tab.Cell(13, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][20].ToString();
                //第14行赋值
                tab.Cell(14, 1).Range.Text = "家庭地址：";
                tab.Cell(14, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][22].ToString();

                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中
            }
        }

        private void Img_Save_Click(object sender, EventArgs e)
        {
            Read_Image(openFileDialog1, S_Photo);
            Ima_n = 1;
        }

        private void Img_Clear_Click(object sender, EventArgs e)
        {
            S_Photo.Image = null;
            imgBytesIn = new byte[65536];
            Ima_n = 2;
        }

    }
}
