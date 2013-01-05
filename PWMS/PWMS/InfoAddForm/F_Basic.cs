using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWMS.InfoAddForm
{
    public partial class F_Basic : Form
    {
        public F_Basic()
        {
            InitializeComponent();
        }

        DataClass.MyMeans myDataClass = new PWMS.DataClass.MyMeans();
        ModuleClass.MyModule myModule = new PWMS.ModuleClass.MyModule();
        //private static DataSet myDS;
        //private static string Basic_SQL = DataClass.MyMeans.Mean_SQL;
        //private static string Basic_Table = DataClass.MyMeans.Mean_Table;

        private void F_Basic_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataSet myDS = myDataClass.getDataSet(DataClass.MyMeans.Mean_SQL, DataClass.MyMeans.Mean_Table);
            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                listBox1.Items.Add(myDS.Tables[0].Rows[i][1].ToString());
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DataSet myDR = myDataClass.getDataSet("select * from " + DataClass.MyMeans.Mean_Table.Trim() + " where " + DataClass.MyMeans.Mean_Field.Trim() + "='" + listBox1.SelectedItem.ToString().Trim() + "'", DataClass.MyMeans.Mean_Table.Trim());
                myDataClass.getsqlcom("update " + DataClass.MyMeans.Mean_Table.Trim() + " set " + DataClass.MyMeans.Mean_Field.Trim() + "='" + textBox1.Text.Trim() + "' where ID='" + myDR.Tables[0].Rows[0][0].ToString() + "'");
                listBox1.Items[listBox1.SelectedIndex] = textBox1.Text;
            }
            button4_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet myDR = myDataClass.getDataSet("select * from " + DataClass.MyMeans.Mean_Table.Trim() + " where " + DataClass.MyMeans.Mean_Field.Trim() + "='" + listBox1.SelectedItem.ToString().Trim() + "'", DataClass.MyMeans.Mean_Table.Trim());
            myDataClass.getsqlcom("delete from " + DataClass.MyMeans.Mean_Table.Trim() + " where ID='" + myDR.Tables[0].Rows[0][0].ToString() + "'");
            listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
            listBox1.SelectedIndex = -1;
            button4_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag=true;
            foreach (string s in listBox1.Items)
                if (s == textBox1.Text.Trim())
                    flag = false;
            if (flag)
            {
                myDataClass.getsqlcom("insert into " + DataClass.MyMeans.Mean_Table + " values ('" + textBox1.Text.Trim() + "')");
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
