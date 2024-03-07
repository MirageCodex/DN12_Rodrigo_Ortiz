// See https://aka.ms/new-console-template for more information
using DataAccess.Example.Entities;

const string mysqlConnectionString = "server=localhost;port=3306;database=sqltesting;user=root;password=asdf1234;Charset=utf8;";
Console.WriteLine("Hello, World!");
var allUsers = GetUsers();
var usertwo = GetUserById(2);
var userone = GetUserById(1);
var companyResult = CreateCompany("HP", "MX", "admin@hp.com", "user@hp.com");

static List<User> GetUsers()
{
    List<User> users = new List<User>();

    MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);

    connection.Open();

    try
    {
        MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetAllUsers", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            User user = new User()
            {
                Id = (int)reader["iduser"],
                Username = reader["username"] as String,
                Email = reader["email"] as String,
                CompanyId = (int)reader["idcompany"]


            };

            users.Add(user);
        }
    }
    finally
    {
        connection.Close();
    }

    

    

    return users;

}

static User GetUserById( int userID)
{
    User user = null;

    MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);

    connection.Open();

    try
    {
        MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetUserById", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("_id", userID);

        var reader = command.ExecuteReader();

        if (reader.Read())
        {
             user = new User()
            {
                Id = (int)reader["iduser"],
                Username = reader["username"] as String,
                Email = reader["email"] as String,
                CompanyId = (int)reader["idcompany"]


            };

        }
    }
    finally
    {
        connection.Close();
    }
    return user;

}

static CompanyCreationResult CreateCompany(string companyName, string companyLocation, string adminEmail, string employeeEmail)
{
    CompanyCreationResult result = null;

    MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);

    connection.Open();

    try
    {
        MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("CreateCompany", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("_companyName", companyName);
        command.Parameters.AddWithValue("_location", companyLocation);
        command.Parameters.AddWithValue("_adminEmail", adminEmail);
        command.Parameters.AddWithValue("_userEmail", employeeEmail);

        var companyIdParameter = command.Parameters.Add("_idcompany", System.Data.DbType.Int32);
        companyIdParameter.Direction = System.Data.ParameterDirection.Output;
        var adminIdParameter = command.Parameters.Add("_idadmin", System.Data.DbType.Int32);
        adminIdParameter.Direction = System.Data.ParameterDirection.Output;
        var userIdParameter = command.Parameters.Add("_iduser", System.Data.DbType.Int32);
        userIdParameter.Direction = System.Data.ParameterDirection.Output;

        command.ExecuteNonQuery();

        result = new CompanyCreationResult
        {
            CompanyId = (int)companyIdParameter.Value,
            AdminId = (int)adminIdParameter.Value,
            UserId = (int)userIdParameter.Value,
        };
    }
    finally
    {
        connection.Close();
    }
    return result;

}