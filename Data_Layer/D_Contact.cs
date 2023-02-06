using ContactEntity;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Data_Layer
{
    public class D_Contact
    {
        readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);

        public List<E_Contact> ContactsRecord(string search)
        {
            SqlDataReader readRows;
            SqlCommand cmd = new SqlCommand("sp_searchContact", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@search", search);
            readRows = cmd.ExecuteReader();

            List<E_Contact> record = new List<E_Contact>();
            while (readRows.Read())
            {
                E_Contact contact = new();

                contact.ContactCode = readRows.GetString("ContactCode");
                contact.FirstName = readRows.GetString("FirstName");
                contact.LastName = readRows.GetString("LastName");
                contact.Birthdate = readRows.GetDateTime("BirthDate");
                contact.Address = readRows.GetString("Address");
                contact.Gender = readRows.GetString("Gender");
                contact.CivilStatus = readRows.GetString("CivilStatus");
                contact.Movil = readRows.GetString("Movil");
                contact.Email = readRows.GetString("Email");
                
                record.Add(contact);
             }

            readRows.Close();
            conn.Close();
            return record;

        }


        public void insertContact(E_Contact c)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", c.Birthdate);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@CivilStatus", c.CivilStatus);
                cmd.Parameters.AddWithValue("@Movil", c.Movil);
                cmd.Parameters.AddWithValue("@Email", c.Email);

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void updateContact(E_Contact c)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_updateContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@ContactCode", c.ContactCode);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", c.Birthdate);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@CivilStatus", c.CivilStatus);
                cmd.Parameters.AddWithValue("@Movil", c.Movil);
                cmd.Parameters.AddWithValue("@Email", c.Email);

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteContact(E_Contact c)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_deleteContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@ContactCode", c.ContactCode);

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}