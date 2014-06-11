using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contacts
{
    public partial class ContactListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Contact> contacts = Contact.getAll();
                gvMain.DataSource = contacts;
                gvMain.DataBind();

                gvMain.UseAccessibleHeader = true;
                if (contacts.Count > 0)
                {
                    gvMain.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvMain.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
        }

        protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["Command"] = e.CommandName;
            Session["Argument"] = e.CommandArgument;

            if (e.CommandName.ToLower().Equals("edit"))
            {
                Response.Redirect("~/Edit.aspx");
            }
            else
            {
                Response.Redirect("~/View.aspx");
            }
        }
    }
}