using System.Data.SqlClient;

namespace XmlToDatabase
{
    public static class Table
    {
        public static void CreateTable()
        {
            using SqlConnection connection = new(ConnectionStringConfig.BooksDbConnectionString);
            connection.Open();
            string checkTableQuery = "SELECT object_id FROM sys.tables WHERE name = 'Book'";
            using SqlCommand checkCmd = new(checkTableQuery, connection);
            object result = checkCmd.ExecuteScalar();
            if (result == null)
            {
                string createTableQuery = @"CREATE TABLE Book (
                    Id NVARCHAR(10) PRIMARY KEY,
                    Author NVARCHAR(100),
                    Title NVARCHAR(100),
                    Genre NVARCHAR(50),
                    Price DECIMAL(19,2),
                    PublishDate DATE,
                    Description NVARCHAR(MAX)
                )";
                using SqlCommand cmd = new(createTableQuery, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
