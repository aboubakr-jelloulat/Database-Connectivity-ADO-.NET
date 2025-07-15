// ***********  special thanks to Programming Advices   ***************

using System;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string connectionString = "Server=.; Database=ContactsDB; User Id = sa; Password=sa123456";

    static void PrintAllContacts()
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts";

        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader[0];
                string firstName = (string)reader[1];
                string lastName = (string)reader["LastName"];
                string email = reader["Email"].ToString();
                string phone = reader["Phone"].ToString();
                string address = reader["Address"].ToString();
                int    countryID = (int)reader["CountryID"];

                Console.WriteLine($"Contact ID : {contactID}");
                Console.WriteLine($"First Name : {firstName}");
                Console.WriteLine($"Last Name  : {lastName}");
                Console.WriteLine($"Email      : {email}");
                Console.WriteLine($"Phone      : {phone}");
                Console.WriteLine($"Address    : {address}");
                Console.WriteLine($"Country ID : {countryID}");

                Console.WriteLine();

            }

            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    static void PrintAllContactsWithFirstName(string UserName)
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName = @UserName";


        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@UserName", UserName);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                string address = (string)reader["Address"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"Contact ID: {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Country ID: {countryID}");
                Console.WriteLine();
            }

            reader.Close();
            connection.Close();

        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }


    static void PrintAllContactsWithFirstNameAndCountry(string FirstName, int CountryID)
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName = @FirstName and CountryID=@CountryID";


        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@CountryID", CountryID);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                string address = (string)reader["Address"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"Contact ID: {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Country ID: {countryID}");
                Console.WriteLine();
            }

            reader.Close();
            connection.Close();

        }


        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }


    /*
     * 
     *  'abc%'	Starts with "abc"
        '%abc'	Ends with "abc"
        '%abc%'	Contains "abc" anywhere
     * 
     */

    static void SearchContactsStartsWith(string StartsWith)
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName LIKE '' + @StartsWith +'%'";


        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@StartsWith", StartsWith);

        /*
         * 
         * you can use this :
         * 
               string query = "SELECT * FROM Contacts WHERE FirstName LIKE @pattern";
                command.Parameters.AddWithValue("@pattern", StartsWith + "%");
         *
         */

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                string address = (string)reader["Address"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"Contact ID: {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Country ID: {countryID}");
                Console.WriteLine();
            }

            reader.Close();
            connection.Close();

        }


        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }


    static void SearchContactsEndsWith(string EndsWith)
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @EndsWith + ''";


        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@EndsWith", EndsWith);

        /*
         * you can use this :
         * 
                string query = "SELECT * FROM Contacts WHERE FirstName LIKE @pattern";
                command.Parameters.AddWithValue("@pattern", "%" + EndsWith);
         * 
         */

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                string address = (string)reader["Address"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"Contact ID: {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Country ID: {countryID}");
                Console.WriteLine();
            }

            reader.Close();
            connection.Close();

        }


        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }


    static void SearchContactsContains(string Contains)
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @Contains + '%'";


        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Contains", Contains);

        /*
         * you can use this :
         * 
                string query = "SELECT * FROM Contacts WHERE FirstName LIKE @pattern";
                command.Parameters.AddWithValue("@pattern", "%" + Contains + "%");

         * 
         */

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                string address = (string)reader["Address"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"Contact ID: {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Country ID: {countryID}");
                Console.WriteLine();
            }

            reader.Close();
            connection.Close();

        }


        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }



    static string GetFirstName(int ContactID)
    {

        string firstName = string.Empty;

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT FirstName FROM Contacts WHERE ContactID = @ContactID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            // ** ExecuteScalar() : It executes the query and returns only the value of the first column in the first row of the result.

            if (result != null)
            {
                firstName = result.ToString();
            }
            else
            {
                firstName = "No contact found with the given ID";
            }
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        
        return firstName;
    }
    
    
    public struct stContact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CountryID { get; set; }
    }
    static bool FindContactById(int contactId, ref stContact contact)
    {
        bool found = false;

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@ContactID", contactId);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                found = true;
                contact.ID = (int)reader["ContactID"];
                contact.FirstName = reader["FirstName"].ToString();
                contact.LastName = reader["LastName"].ToString();
                contact.Email = reader["Email"].ToString();
                contact.Phone = reader["Phone"].ToString();
                contact.Address = reader["Address"].ToString();
                contact.CountryID = reader["CountryID"].ToString();
            }
            else
            {
                found = false;
            }

            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        return found;
    }


    public static void Main(string[] args)
    {
        //  ************   bascis link   Print all contacts   ***********

        //  PrintAllContacts();


        // ************   Parametrized query   ***********


        //  PrintAllContactsWithFirstName("jane");
        //  PrintAllContactsWithFirstNameAndCountry("jane", 1);



        //  ************** Parameterized Query With "Like"     **********



        //Console.WriteLine("--------Contacts starts with 'j'");

        //SearchContactsStartsWith("j");

        //Console.WriteLine("-------Contacts Ends with 'ne'");
        //SearchContactsEndsWith("ne");

        //Console.WriteLine("-------Contacts Contains with 'ae'");
        //SearchContactsContains("ae");



        // ***************   Retrieve a Single Value (ExecuteScalar) *************


        //Console.WriteLine(GetFirstName(1));

        //Console.ReadKey();



        // *********   Find Single Contact  ****
       
        //stContact contact = new stContact();

        //if (FindContactById(19, ref contact))
        //{
        //    Console.WriteLine($"Contact ID: {contact.ID}");
        //    Console.WriteLine($"Name: {contact.FirstName}  {contact.LastName}");
        //    Console.WriteLine($"Email: {contact.Email}");
        //    Console.WriteLine($"Phone: {contact.Phone}");
        //    Console.WriteLine($"Address: {contact.Address}");
        //    Console.WriteLine($"Country ID: {contact.CountryID}");
        //}
        //else
        //{
        //    Console.WriteLine("Contact not found.");
        //}


    }
}
