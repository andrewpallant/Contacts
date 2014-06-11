using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contacts.controls
{
    public partial class ctlPhoneNumbers : System.Web.UI.UserControl
    {
        public Int32 ContactID
        {
            set;
            get;
        }

        public List<ContactPhone> SaveContactPhone
        {
            set { ViewState["SaveContactPhone"] = value; }
            get { return (List<ContactPhone>)ViewState["SaveContactPhone"] ?? new List<ContactPhone>(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Visible && !IsPostBack)
            {
                SaveContactPhone = ContactPhone.GetPhoneNumbersByContactID(ContactID);
                BuildPhoneList();
            }
        }

        protected void gvPhone_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhone.EditIndex = e.NewEditIndex;
            BuildPhoneList();
        }

        protected void gvPhone_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (gvPhone.EditIndex > 0)
            {
                List<ContactPhone> phoneNumbers = SaveContactPhone;
                if (phoneNumbers[gvPhone.EditIndex].ContactPhoneId == 0)
                {
                    phoneNumbers.RemoveAt(gvPhone.EditIndex);
                    SaveContactPhone = phoneNumbers;
                }
            }
            gvPhone.EditIndex = -1;

            BuildPhoneList();
        }

        protected void gvPhone_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            gvPhone.EditIndex = -1;

            ContactPhone phone = ContactPhone.getPhoneByID(Int32.Parse(e.Keys[0].ToString()));
            phone.PhoneNumber = (String)e.NewValues[0];
            phone.ContactID = ContactID;
            phone.Save();

            SaveContactPhone = ContactPhone.GetPhoneNumbersByContactID(ContactID);
            BuildPhoneList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<ContactPhone> contactPhones = SaveContactPhone;
            contactPhones.Add(new ContactPhone());
            SaveContactPhone = contactPhones;

            BuildPhoneList();

            gvPhone.EditIndex = gvPhone.Rows.Count - 1;

            BuildPhoneList();
        }

        protected void gvPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gvPhone.EditIndex = -1;

            ContactPhone phone = ContactPhone.getPhoneByID(Int32.Parse(e.Keys[0].ToString()));
            phone.Delete();

            SaveContactPhone = ContactPhone.GetPhoneNumbersByContactID(ContactID);
            BuildPhoneList();
        }

        private void BuildPhoneList()
        {
            gvPhone.DataSource = SaveContactPhone;
            gvPhone.DataBind();

            gvPhone.UseAccessibleHeader = true;
            if (SaveContactPhone.Count > 0)
            {
                gvPhone.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvPhone.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}