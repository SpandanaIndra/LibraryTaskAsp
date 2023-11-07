using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace LibraryTaskAsp
{
    public partial class Student : System.Web.UI.Page
    {
        void GetAllStudents()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("AllStudents", con1);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind the GridView here
            GetAllStudents();
            }
            Label1.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpPostedFile uploadedFile1 = image.PostedFile;
            HttpPostedFile uploadedFile2 = vedio.PostedFile;

            string name = TextBox1.Text;
            string classs=TextBox2.Text;
            byte[] imageData = image.FileBytes;
            string imageName = image.FileName;
            byte[] videoData = vedio.FileBytes;
            string videoName = vedio.FileName;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("InsertStudent", con1);
            cmd1.CommandType = CommandType.StoredProcedure;

            //@name,@class,@photo,@video
            cmd1.Parameters.AddWithValue("@name", name);
            cmd1.Parameters.AddWithValue("@class", classs);
            cmd1.Parameters.AddWithValue("@photo", imageData);
            cmd1.Parameters.AddWithValue("@video", videoData);
           
            int result = cmd1.ExecuteNonQuery();
            if (result == 1)
            {
                Label1.Visible = true;
                Label1.Text = "Record Inserted";
                TextBox1.Text = TextBox2.Text = "";
                uploadedFile1 = null;
                uploadedFile2 = null;
                GetAllStudents();

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Record Not Inserted";
                

            }

            con1.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the unique identifier of the record to delete.
            int recordId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("DeleteStudent", con1);
            cmd1.CommandType = CommandType.StoredProcedure;

            //@name,@class,@photo,@video
            cmd1.Parameters.AddWithValue("@id", recordId);
            cmd1.ExecuteNonQuery();
            GetAllStudents();


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetAllStudents(); // Rebind the GridView to show it in edit mode
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve the data from the edited row and update your data source.
            int recordId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
              TextBox updatedName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxName");

            TextBox updatedClass = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxClass");
            FileUpload updatedImage = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUploadImage");
            FileUpload updatedVedio = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUploadvedio");

           string name = updatedName.Text;
            string classs =updatedClass.Text;
            byte[] imageData = updatedImage.FileBytes;
            byte[] videoData = updatedVedio.FileBytes;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("UpdateStudent", con1);
            cmd1.CommandType = CommandType.StoredProcedure;

            //@name,@class,@photo,@video
            cmd1.Parameters.AddWithValue("@id", recordId);

            cmd1.Parameters.AddWithValue("@name",name );
            cmd1.Parameters.AddWithValue("@class", classs);
            cmd1.Parameters.AddWithValue("@photo", imageData);
            cmd1.Parameters.AddWithValue("@video", videoData);
            cmd1.ExecuteNonQuery();

            // Update the data source with the new value.
           
            GridView1.EditIndex = -1; // Exit edit mode
            GetAllStudents();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpPostedFile uploadedFile1 = image.PostedFile;
            HttpPostedFile uploadedFile2 = vedio.PostedFile;

            TextBox1.Text = TextBox2.Text = "";
            uploadedFile1 = null;
            uploadedFile2 = null;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetAllStudents();
        }
    }
}