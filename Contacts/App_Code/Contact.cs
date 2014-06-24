using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Contacts
{
    [Serializable]
    public class Contact
    {
        public Int32 ContactID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Email { get; set; }
        public String Twitter { get; set; }
        public List<ContactPhone> PhoneNumbers { get; set; }

        public Contact()
        {
            PhoneNumbers = new List<ContactPhone>();
        }

        public Contact(SqlDataReader row, Boolean retrievePhoneNumbers)
        {
            PopulateContact(row, retrievePhoneNumbers);
        }

        public Contact(SqlDataReader row)
        {
            PopulateContact(row, true);
        }

        public void PopulateContact(SqlDataReader row, Boolean retrievePhoneNumbers)
        {
            ContactID = (Int32)row["ContactID"];
            Name = (String)row["Name"];
            Address = (String)row["Address"];
            City = (String)row["City"];
            State = (String)row["State"];
            Zip = (String)row["Zip"];
            Email = (String)row["Email"];
            Twitter = (String)row["Twitter"];

            if (retrievePhoneNumbers)
            {
                PhoneNumbers = ContactPhone.GetPhoneNumbersByContactID(ContactID);
            }
        }

        public static Contact getByID(Int32 id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM Contacts WHERE ContactID={0}", id), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                return new Contact(reader);
            }

            if (conn.State > 0)
            {
                conn.Close();
            }

            reader.Close();
            reader.Dispose();
            conn.Dispose();

            return new Contact();
        }

        public static List<Contact> getAll()
        {
            List<Contact> contactCollection = new List<Contact>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Contacts", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                contactCollection.Add(new Contact(reader, false));
            }

            if (conn.State > 0)
            {
                conn.Close();
            }

            reader.Close();
            reader.Dispose();
            conn.Dispose();

            return contactCollection;
        }

        public void Delete()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            String sql = String.Format("DELETE FROM Contacts OUTPUT DELETED.* WHERE ContactID={0}", ContactID);

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            if (conn.State > 0)
            {
                conn.Close();
            }

            conn.Dispose();
        }

        public void Save()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            String sql = "";
            if (ContactID>0)
            {
                sql = "UPDATE Contacts SET Name=@Name, Address=@Address, City=@City, State=@State, Zip=@Zip, Email=@Email, Twitter=@Twitter OUTPUT INSERTED.* WHERE ContactID=@ContactID";
            }
            else
            {
                sql = "INSERT INTO Contacts (Name, Address, City, State, Zip, Email, Twitter) OUTPUT INSERTED.* VALUES (@Name, @Address, @City, @State, @Zip, @Email, @Twitter)";
            }

            SqlCommand cmd = new SqlCommand(sql, conn);
            if (ContactID > 0) cmd.Parameters.AddWithValue("@ContactID", ContactID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Zip", Zip);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Twitter", Twitter);

            cmd.ExecuteNonQuery();

            if (conn.State> 0 )
            {
                conn.Close();
            }

            conn.Dispose();
        }
    }

    
}
