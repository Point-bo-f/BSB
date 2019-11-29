using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Label = System.Web.UI.WebControls.Label;

namespace WebApplication1
{
    public partial class Låtar1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSB notarkivConnectionString2"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public object DataList1 { get; private set; }
        public object Label2 { get; private set; }
        public object ToLower { get; private set; }
        

        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                GridDisplayFiles();
            }
        }

        protected void GridView1_SelectedIndexChanged()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fname = FileUpload1.PostedFile.FileName;                
                string extension = Path.GetExtension(fname);
                int flag = 0;
                switch (extension.ToLower())
                {
                    case ".doc":
                    case ".docx":
                    case ".pdf":
                        flag = 1;
                        break;
                    default:
                        flag = 0;
                        break;
                }
                if (flag == 1)
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Download/" + fname));
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT * FROM Låtar";
                    con.Open();           
                    string Sql = "INSERT INTO Låtar (Titel, KompositörId, SvitId) VALUES (@Titel, @KompositörId, @SvitId)";
                    SqlCommand exeSql = new SqlCommand(Sql, con);                     
                    exeSql.Parameters.AddWithValue("@Titel", fname);
                    exeSql.Parameters.AddWithValue("@KompositörId", txtKomp.Text);
                    exeSql.Parameters.AddWithValue("@SvitId", txtSvit.Text);
                    exeSql.ExecuteNonQuery();                
                    
                    


                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Label4.Text = "File uploaded successfully";
                        con.Close();
                        GridDisplayFiles();
                    }
                    else
                    {
                        Label4.Text = "File failed to upload";
                    }
                    

                }
                else
                {
                    Label4.Text = "Only .doc, .docx and .pdf file is allowed";
                }
            }
            else
            {
                Label4.Text = "Select the file";
            }
        }
        private void GridDisplayFiles()
        {
            con.Open();
            cmd = new SqlCommand("select*from Låtar", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                GridView1.DataSource = dr;
                GridView1.DataBind();
                con.Close();
            }
            else
            {
                //Label1.Text = "Nothing is available";
            }

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }
        
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            TextBox Id = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox SvitId = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox KompositörId = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            HyperLink Titel = GridView1.Rows[e.RowIndex].FindControl("HyperLink1") as HyperLink;
            String mycon = "Data Source = LAPTOP-86R6N3K7\\SQLEXBOBBEFU; Initial catalog=BSB notarkiv; Integrated Security=True";
            String updatedata = "Update Låtar set KompositörId='" + KompositörId.Text + "', SvitId='" + SvitId.Text + "' where LåtId =" + Convert.ToInt32(Id.Text);
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();




        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            Label LåtId = GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;
            String mycon = "Data Source = LAPTOP-86R6N3K7\\SQLEXBOBBEFU; Initial catalog=BSB notarkiv; Integrated Security=True";
            String updatedata = "Delete from Låtar where LåtId=" + LåtId.Text;
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }
        private void BindData()
        {
            SqlCommand cmd = new SqlCommand("select LåtId, Titel, KompositörId, SvitId from Låtar", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Page_Load2(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kompositörer.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sviter.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SökAllt.aspx");
        }
    }
    }
