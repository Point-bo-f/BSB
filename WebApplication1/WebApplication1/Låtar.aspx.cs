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
                    cmd = new SqlCommand("insert into Låtar(Titel) values ('" + fname + "')", con);
                    con.Open();

                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Label1.Text = "File uploaded successfully";
                        con.Close();
                        GridDisplayFiles();
                    }
                    else
                    {
                        Label1.Text = "File failed to upload";
                    }
                }
                else
                {
                    Label1.Text = "Only .doc, .docx and .pdf file is allowed";
                }
            }
            else
            {
                Label1.Text = "Select the file";
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
            }
            else
            {
                Label1.Text = "Nothing is available";
            }

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int LåtId = (int)e.Keys["LåtId"];
            string Titel = (string)e.NewValues["Titel"];
            int KompositörId = (int)e.NewValues["KompositörId"];
            string Kompositör = (string)e.NewValues["Kompositör"];

            GridView1.EditIndex = -1;
            BindData();


        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int LåtId = (int)e.Keys["LåtId"];

            BindData();
        }
        private void BindData()
        {
            SqlCommand cmd = new SqlCommand("select LåtId, Titel, KompositörId, Kompositör from Låtar", con);
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
    }
    }
