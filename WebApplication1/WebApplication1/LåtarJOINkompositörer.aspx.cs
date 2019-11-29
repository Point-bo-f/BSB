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
    public partial class LåtarJOINkompositörer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-86R6N3K7\\SQLEXBOBBEFU;Initial Catalog=BSB notarkiv;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adpt;
        
       

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }
       

        public void DisplayValue()
        {
            //con.Open();
            //adpt = new SqlDataAdapter("select*from Kompositörer", con);
            //dt = new DataTable();
            //adpt.Fill(dt);
            //GridView1.DataSource = dt;
            //con.Close();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            SearchData(TextBox1.Text);

        }
        public void SearchData(String search)
        {
            //con.Open();
            //string query = "select*from Kompositörer where Kompositör like '%" + search + "%'";
            //adpt = new SqlDataAdapter(query, con);
            //dt = new DataTable();
            //adpt.Fill(dt);
            //GridView1.DataSource = dt;
            //con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Titel = TextBox1.Text;
            string Kompositör = TextBox2.Text;
            string Filter = "";
            

            if (Titel != "") { Filter = Filter + "Titel like '%" + Titel + "%' and "; }
            if (Kompositör != "") { Filter = Filter + "Kompositör like '%" + Kompositör + "%' and "; }

            if (Filter.Length > 0)
            {
                string FinalFilter = Filter.Remove(Filter.Length - 4, 3);
                SqlDataSource1.FilterExpression = FinalFilter;
            }
            else
            {
                GridView1.DataBind();
            }
            
        }
    }
    
}

     

    



 

