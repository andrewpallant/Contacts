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
            SqlCommand cmd = new SqlCommand("SELECT * FROM ContactPhones WHERE ContactID=@ContactID", conn);
            cmd.Parameters.AddWithValue("@ContactID", contactID);

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
                sql = "DELETE FROM ContactPhones WHERE ContactPhoneID=@ContactPhoneID";
            }

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ContactPhoneID", ContactPhoneId);
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
                sql = "UPDATE ContactPhones SET PhoneNumber=@PhoneNumber, ContactID=@ContactID, Type=@Type OUTPUT INSERTED.* WHERE ContactPhoneID=@ContactPhoneID";
            }
            else
            {
                sql = "INSERT INTO ContactPhones (PhoneNumber, ContactID, Type ) OUTPUT INSERTED.* VALUES (@PhoneNumber, @ContactID, @Type)";
            }

            SqlCommand cmd = new SqlCommand(sql, conn);
            if (ContactPhoneId > 0) cmd.Parameters.AddWithValue("@ContactPhoneId",ContactPhoneId);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@ContactID", ContactID);
            cmd.Parameters.AddWithValue("@Type", Type);

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