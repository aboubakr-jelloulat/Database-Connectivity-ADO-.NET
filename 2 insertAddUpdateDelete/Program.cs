// ***********  special thanks to Programming Advices   ***************

using System;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string connectionString = "Server=.; Database=ContactsDB; User Id = sa; Password=sa123456";

    public struct stContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
    }



    static void AddNewContact(stContact newContact)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = @"Insert into Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                        Values  (@FirstName, @LastName, @Email, @Phone,@Address, @CountryID)";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
        command.Parameters.AddWithValue("@LastName", newContact.LastName);
        command.Parameters.AddWithValue("@Email", newContact.Email);
        command.Parameters.AddWithValue("@Phone", newContact.Phone);
        command.Parameters.AddWithValue("@Address", newContact.Address);
        command.Parameters.AddWithValue("@CountryID", newContact.CountryID);


        try
        {
            connection.Open();

            // We use ExecuteNonQuery() to run commands that change the database and to check if the command was successful.

            int rowAffected = command.ExecuteNonQuery();

            // It returns an integer that tells you the number of rows affected by the SQL command.

            if (rowAffected > 0)
                Console.WriteLine("Record insert successfly.");
            else
                Console.WriteLine("Record insertion faild.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);

        }

        connection.Close();
  
    }
    public static void Main(string[] args)
    {
        //  *********** insert / Add   Data *************


        // create a new contact

        /*
        stContact Contact = new stContact
        {
            FirstName = "Aboubakr",
            LastName = "Jelloulat",
            Email = "abubakerjelloulat@gmail.com",
            Phone = "+212 767667227",
            Address = "Tetouan shore",
            CountryID = 1

        };

        AddNewContact(Contact);

        */











        Console.ReadKey();

    }

}
