using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryTaskAsp
{
    public partial class Book : System.Web.UI.Page
    {
        void AllBooks()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("AllBooks", con1);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            GridView1.DataSource=ds;
            GridView1.DataBind();
            con1.Close();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string author = TextBox2.Text;
            string publication = TextBox3.Text;
            DateTime year;
            if (DateTime.TryParse(TextBox4.Text, out year))
            {
                // Check if the date is within the allowed range for SQL Server datetime data type
                if (year >= new DateTime(1753, 1, 1) && year <= new DateTime(9999, 12, 31))
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("InsertBook", con1);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    //(@name VARCHAR(255),@author VARCHAR(255),@publication VARCHAR(255),@year date)
                    cmd1.Parameters.AddWithValue("@name", name);
                    cmd1.Parameters.AddWithValue("@author", author);
                    cmd1.Parameters.AddWithValue("@publication", publication);
                    cmd1.Parameters.AddWithValue("@year", year);

                    int result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Record Inserted";
                        TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = "";
                        AllBooks();

                    }
                }
           }
          
           
         
        }
    }
}