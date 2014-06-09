using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contacts
{
    public partial class View : System.Web.UI.Page
    {
        public Int32 ContactID
        {
            set { ViewState["ContactID"] = value; }
            get { return (Int32)(ViewState["ContactID"] ?? -1); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ContactID = Int32.Parse((String)Session["Argument"] ?? "-1");

            // Should Not, Cannot Continue - Lost Session or User Jumped a Step!
            if (ContactID < 0) Response.Redirect("~/Default.aspx");

            btnDelete.Visible = false;
            lnkEdit.Visible = false;
            if (((String)Session["Command"]).ToLower().Equals("delete"))
            {
                subtitle.InnerHtml = "Are you sure you want to delete this?";
                btnDelete.Visible = true;
            }
            else
            {
                lnkEdit.Visible = true;
            }

            if (ContactID > -1)
            {
                // Look Up Contact
                Contact contact = Contact.getByID(ContactID);
                txtName.Text = contact.Name;
                txtAddress.Text = contact.Address;
                txtCity.Text = contact.City;
                txtState.Text = contact.State;
                txtZip.Text = contact.Zip;
                txtEmail.Text = contact.Email;
                txtTwitter.Text = contact.Twitter;
            }
        }

        /// <summary>
        /// Delete Contact Record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Contact contact = Contact.getByID(ContactID);
            contact.Delete();

            // Assume Deleted - Should Really Check for return
            Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// Edit Contact Record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            Session["Command"] = "Edit";
            Session["Argument"] = ContactID.ToString();
            Response.Redirect("edit.aspx");
        }
    }
}