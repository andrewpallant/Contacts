using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Contacts
{
    [Serializable]
    public class ContactPhone
    {
        public Int32 ContactPhoneId { get; set; }
        public String PhoneNumber { get; set; }
        public Int32 ContactID { get; set; }
        public Int32 Type { get; set; }

        public ContactPhone()
        {
        }

        public ContactPhone(SqlDataReader row)
        {
            ContactPhoneId = (Int32)row["ContactPhoneID"];
            PhoneNumber = (String)row["PhoneNumber"];
            ContactID = (Int32)row["ContactID"];
            Type = (Int32)row["Type"];
        }

        public static List<ContactPhone> GetPhoneNumbersByContactID(Int32 contactID)
        {
            List <ContactPhone> numbers = new List<ContactPhone>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM ContactPhones WHERE ContactID={0}", contactID), conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                numbers.Add(new ContactPhone(reader));
            }

            if (conn.State > 0)
            {
                conn.Close();
            }

            reader.Close();
            reader.Dispose();
            conn.Dispose();

            return numbers;
        }

        public void Delete()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            String sql = "";
            if (ContactPhoneId > 0)
            {
                sql = String.Format("DELETE FROM ContactPhones WHERE ContactPhoneID={0}", ContactPhoneId);
            }

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
            if (ContactPhoneId > 0)
            {
                sql = String.Format("UPDATE ContactPhones SET PhoneNumber='{1}', ContactID='{2}', Type='{3}' OUTPUT INSERTED.* WHERE ContactPhoneID={0}", ContactPhoneId, PhoneNumber, ContactID, Type);
            }
            else
            {
                sql = String.Format("INSERT INTO ContactPhones (PhoneNumber, ContactID, Type ) OUTPUT INSERTED.* VALUES ('{0}', '{1}', '{2}')", PhoneNumber, ContactID, Type);
            }

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            if (conn.State > 0)
            {
                conn.Close();
            }

            conn.Dispose();
        }

        public static ContactPhone getPhoneByID(Int32 contactPhoneID)
        {
            ContactPhone phone = new ContactPhone();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(String.Format("SELECT top 1 * FROM ContactPhones WHERE contactPhoneID={0}", contactPhoneID), conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                phone = new ContactPhone(reader);
            }

            return phone;
        }
    }


}