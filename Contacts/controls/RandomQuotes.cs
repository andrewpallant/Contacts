using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contacts.controls
{
    [ToolboxData("<{0}:RandomQuotes runat=server></{0}:RandomQuotes>")]
    public class RandomQuotes : Panel
    {
        protected override void RenderContents(HtmlTextWriter output)
        {
            String strOutput = "";
            if (Visible)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Quotes ORDER BY NEWID()", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    strOutput = String.Format(@"<div>{0}</div>", rdr["QuoteText"], CssClass);
                }
            }
            output.Write(strOutput);
        }
    }
}
