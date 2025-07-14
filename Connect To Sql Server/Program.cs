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


    public static void Main(string[] args)
    {
        PrintAllContacts();

       Console.ReadKey();
    }
}
