using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contacts
{
    public partial class Edit : System.Web.UI.Page
    {
        public Int32 ContactID
        {
            set { ViewState["ContactID"] = value; }
            get { return (Int32)(ViewState["ContactID"] ?? -1); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((String)Session["Command"]??"CREATE").Equals("CREATE"))
                {
                    btnSave.Text = "Create";
                }

                ContactID = Int32.Parse((String)Session["Argument"] ?? "-1");

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
                else
                {
                    // Treat as New
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtEmail.Text = "";
                    txtTwitter.Text = "";
                }
            }
        }

        /// <summary>
        /// Save Contact Record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            if (ContactID > -1)
            {
                contact = Contact.getByID(ContactID);
            }

            contact.Name = txtName.Text;
            contact.Address = txtAddress.Text;
            contact.City = txtCity.Text;
            contact.State = txtState.Text;
            contact.Zip = txtZip.Text;
            contact.Email = txtEmail.Text;
            contact.Twitter = txtTwitter.Text;
            contact.Save();

            // Assume Saved - Should Really Check for return
            Response.Redirect("~/Default.aspx");
        }
    }
}