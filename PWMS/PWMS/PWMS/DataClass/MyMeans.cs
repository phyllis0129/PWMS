using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PWMS.DataClass
{
    class MyMeans
    {
        public static string Login_ID = "";
        public static string Login_Name = "";
        public static string Mean_SQL = "", Mean_Table = "", Mean_Field = "";
        public static SqlConnection My_con;
        public static string sqlConn1 = "server =PC3_02;Integrated Security=SSPI;database = db_PWMS";
        public static int Login_n = 0;
        public static string AllSql = "Select * from tb_Stuffbusic";




        public static SqlConnection getcon()
        {
            My_con = new SqlConnection(sqlConn1);
            My_con.Open();
            return My_con;
        }

        public void con_close()
        {
            if (My_con.State == ConnectionState.Open)
            {
                My_con.Close();
                My_con.Dispose();
            }
        }

        public SqlDataReader getcom(string SQLstr)
        {
            getcon();
            SqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            SqlDataReader My_read = My_com.ExecuteReader();
            return My_read;
        }

        public void getsqlcom(string SQLstr)
        {
            getcon();
            SqlCommand SQLcom = new SqlCommand(SQLstr, My_con);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();
            con_close();
        }

        public DataSet getDataSet(string SQLstr, string tableName)
        {
            getcon();
            SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet, tableName);
            con_close();
            return My_DataSet;
        }

    }
}
