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
    public partial class Kompositörer1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSB notarkivConnectionString2"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            Label LåtId = GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;
            Label Kompositör = GridView1.Rows[e.RowIndex].FindControl("Label2") as Label;
            HyperLink Titel = GridView1.Rows[e.RowIndex].FindControl("HyperLink1") as HyperLink;
            String mycon = "Data Source = LAPTOP-86R6N3K7\\SQLEXBOBBEFU; Initial catalog=BSB notarkiv; Integrated Security=True";
            String updatedata = "Update Kompositörer set KompositörId ='" + Kompositör + "', Kompositör='" + Kompositör + "'";
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

            Label KompositörId = GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;
            String mycon = "Data Source = LAPTOP-86R6N3K7\\SQLEXBOBBEFU; Initial catalog=BSB notarkiv; Integrated Security=True";
            String updatedata = "Delete from Kompositörer where KompositörId=" + KompositörId.Text;
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
            SqlCommand cmd = new SqlCommand("select KompositörId, Kompositör from Kompositörer", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Kompositörer(Kompositör) values ('"+TextBox2.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Kompositörer.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            TextBox KompositörId = GridView1.FooterRow.FindControl("TextBox3") as TextBox;
            TextBox Kompositör = GridView1.FooterRow.FindControl("TextBox4") as TextBox;
            String query = "insert into Kompositörer(KompositörId, Kompositör) values('" + KompositörId.Text + "','" + Kompositör.Text + "'";
            String mycon = "Data Source = LAPTOP-86R6N3K7\\SQLEXBOBBEFU; Initial catalog=BSB notarkiv; Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        
    }
}