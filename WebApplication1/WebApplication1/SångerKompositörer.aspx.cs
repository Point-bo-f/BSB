using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SångerKompositörer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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