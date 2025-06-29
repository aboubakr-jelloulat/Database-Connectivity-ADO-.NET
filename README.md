# SQL Server Database Operations with C# and ADO.NET

![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![ADO.NET](https://img.shields.io/badge/ADO.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)

A comprehensive learning repository demonstrating database operations using C# and ADO.NET with SQL Server. This project covers essential CRUD operations and advanced database handling techniques.

## 📋 Repository Description

This repository serves as a practical learning resource for developers who want to master database operations using C# and ADO.NET with SQL Server. It provides hands-on examples of connecting to databases, performing CRUD operations, and implementing best practices for data access in .NET applications.

##  What You'll Learn

- 🔌 **Database Connection Management** - Secure connection handling
- 📊 **Data Retrieval** - Efficient data querying and result processing
- ➕ **Data Insertion** - Adding new records to database tables
- ✏️ **Data Updates** - Modifying existing database records
- 🗑️ **Data Deletion** - Removing records from database tables
- 📝 **Prepared Statements** - SQL injection prevention with parameterized queries
- 🛡️ **Error Handling** - Comprehensive exception management

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/aboubakr-jelloulat/Database-Connectivity-ADO-.NET.git
   ```

2. **Open in Visual Studio**
   - Open the solution file (.sln) in Visual Studio
   - Build the project (Ctrl+Shift+B)

3. **Run the examples**
   - Execute the sample programs to see database operations in action

## 💡 Usage Examples

### Database Connection
```csharp
using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    // Perform database operations
}
```

### Data Retrieval
```csharp
string query = "SELECT Id, Name, Email FROM Users WHERE Age > @age";
using (SqlCommand command = new SqlCommand(query, connection))
{
    command.Parameters.AddWithValue("@age", 18);
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            // Process data
        }
    }
}
```

### Data Insertion
```csharp
string insertQuery = "INSERT INTO Users (Name, Email, Age) VALUES (@name, @email, @age)";
using (SqlCommand command = new SqlCommand(insertQuery, connection))
{
    command.Parameters.AddWithValue("@name", "John Doe");
    command.Parameters.AddWithValue("@email", "john@example.com");
    command.Parameters.AddWithValue("@age", 25);
    int rowsAffected = command.ExecuteNonQuery();
}
```

## 📚 Learning Modules

1. **Module 1: Database Connection Fundamentals**
   - Connection string configuration
   - Opening and closing connections
   - Connection pooling concepts

2. **Module 2: Data Retrieval Operations**
   - SELECT statements with SqlCommand
   - Using SqlDataReader for data retrieval
   - Handling different data types

3. **Module 3: Data Modification Operations**
   - INSERT operations with parameters
   - UPDATE statements for data modification
   - DELETE operations for data removal

4. **Module 4: Advanced Database Operations**
   - Stored procedures execution
   - Transaction management
   - Bulk operations

5. **Module 5: Best Practices & Security**
   - SQL injection prevention
   - Error handling strategies
   - Performance optimization techniques

## 🔧 Configuration Examples

**Connection String:**
```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Server=localhost;Database=YourDB;Trusted_Connection=true;" />
</connectionStrings>
```

## 🧪 Testing

Run the unit tests to ensure all database operations work correctly:

```bash
dotnet test
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


## 📞 Support

If you have any questions or need help with this repository:

- Create an issue in the GitHub repository
- Check the documentation in the `docs/` folder
- Review the example code in the `src/Examples/` directory

---

**Happy Learning! 🚀**

*This repository is designed for educational purposes to help developers master database operations with C# and ADO.NET.*
