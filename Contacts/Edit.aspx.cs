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

        public Contact SaveContact
        {
            set { ViewState["SaveContact"] = value; }
            get { return (Contact)ViewState["SaveContact"]; }
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
                    SaveContact = contact;
                    txtName.ValueText = contact.Name;
                    txtAddress.Text = contact.Address;
                    txtCity.Text = contact.City;
                    txtState.Text = contact.State;
                    txtZip.Text = contact.Zip;
                    txtEmail.Text = contact.Email;
                    txtTwitter.Text = contact.Twitter;

                    ctlPhoneNumbers1.ContactID = contact.ContactID;
                }
                else
                {
                    // Treat as New
                    txtName.ValueText = "";
                    txtAddress.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtEmail.Text = "";
                    txtTwitter.Text = "";
                }
            }
            else{
                ctlPhoneNumbers1.ContactID = SaveContact.ContactID;
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
                contact = SaveContact;
            }

            contact.Name = txtName.ValueText;
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