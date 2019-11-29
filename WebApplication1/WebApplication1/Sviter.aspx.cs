using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Sviter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSB notarkivConnectionString2"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridDisplayFiles();
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


            Label Id = GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;
            TextBox Svit = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            HyperLink Titel = GridView1.Rows[e.RowIndex].FindControl("HyperLink1") as HyperLink;
            String mycon = "Data Source = LAPTOP-86R6N3K7\\SQLEXBOBBEFU; Initial catalog=BSB notarkiv; Integrated Security=True";
            String updatedata = "Update Svitar set Svit='" + Svit.Text + "' where SvitId =" + Convert.ToInt32(Id.Text);
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

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label Id = (Label)row.FindControl("Label1");           
            con.Open();
            SqlCommand cmd = new SqlCommand("delete FROM Svitar where SvitId='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);           
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        private void BindData()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("select SvitId, Svit from Svitar", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["Svit"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBox2")).Text;

            SqlDataSource1.Insert();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void GridDisplayFiles()
        {
            con.Open();
            cmd = new SqlCommand("select*from Svitar", con);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Låtar.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kompositörer.aspx");
        }

        protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SökAllt.aspx");
        }
    }
}