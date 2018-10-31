using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User_Defined_Table_Type_test.Properties;

namespace User_Defined_Table_Type_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void goBtn_Click(object sender, EventArgs e)
        {

            // Datatable vullen
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            int nRows;
            int.TryParse(textBox1.Text, out nRows);
            DataRow row;
            for (int i = 0; i < nRows; i++)
            {
                row = dt.NewRow();
                row["ID"] = i;
                row["Name"] = "item " + i.ToString();
                dt.Rows.Add(row);
            }


            // Inserten. Ben benieuwd naar execution plans als ik hem eerst met 10 en daarna met 100 rijen insert.
            using (SqlConnection conn = new SqlConnection("Server=LOCALHOST;Database=UDTTest;Trusted_Connection=True;"))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[InsertUDT]";
                SqlParameter param = cmd.Parameters.AddWithValue("@param", dt);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
    }
}
}
