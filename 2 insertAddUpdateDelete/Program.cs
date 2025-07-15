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

    static void AddNewContactAndGetID(stContact newContact)
    {


        SqlConnection connection = new SqlConnection(connectionString);

        string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                             VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                             SELECT SCOPE_IDENTITY();";

        // SCOPE_IDENTITY() is a SQL Server function that returns the last identity value (auto-increment ID) inserted into a table in the current session and scope

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
            object result = command.ExecuteScalar();
            // "Execute the query and get the first value of the first row of the result."

            if (result != null && int.TryParse(result.ToString(), out int insertedID))
            {
                Console.WriteLine($"Newly inserted ID: {insertedID}");
            }
            else
            {
                Console.WriteLine("Failed to retrieve the inserted ID.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }


    static void UpdateContact(int ContactID, stContact ContactInfo)
    {


        SqlConnection connection = new SqlConnection(connectionString);

        string query = @"Update  Contacts  
                            set FirstName = @FirstName, 
                                LastName = @LastName, 
                                Email = @Email, 
                                Phone = @Phone, 
                                Address = @Address, 
                                CountryID = @CountryID
                                where ContactID = @ContactID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@ContactID", ContactID);
        command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
        command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
        command.Parameters.AddWithValue("@Email", ContactInfo.Email);
        command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
        command.Parameters.AddWithValue("@Address", ContactInfo.Address);
        command.Parameters.AddWithValue("@CountryID", ContactInfo.CountryID);

        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Record Updated successfully.");
            }
            else
            {
                Console.WriteLine("Record Upadate failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }


    static void DeleteContact(int ContactID)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = @"Delete Contacts 
                                where ContactID = @ContactID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Record Deleted successfully.");
            }
            else
            {
                Console.WriteLine("Record Delete failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }

    static void DeleteContactWithInStatement(string ContactIDs)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = @"Delete Contacts 
                                where ContactID in (" + ContactIDs + ")";
        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Records Deleted successfully.");
            }
            else
            {
                Console.WriteLine("Records Delete failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
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





        // ***********  Retrieve Auto number after inserting/adding data *************



        /*
        stContact Contact = new stContact
        {
            FirstName = "Sander",
            LastName = "Bos",
            Email = "sander@gmail.com",
            Phone = "1234567890",
            Address = "javastreet, Amsterdamm Netherlands",
            CountryID = 1
        };

        AddNewContactAndGetID(Contact);

        */




        //  ***********  Update data  *************



        /*
        stContact ContactInfo = new stContact
        {
            FirstName = "Jone",
            LastName = "Matioe",
            Email = "jane@gmail.com",
            Phone = "000000000",
            Address = "foot Street, usa",
            CountryID = 1
        };

        UpdateContact(1, ContactInfo);


        */




        // ***********  Delete data  *************


        // DeleteContact(5);


        // delete with in stetment


        DeleteContactWithInStatement("2008, 6, 7");




        Console.ReadKey();

    }

}
