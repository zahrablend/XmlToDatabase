using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToDatabase
{
    public static class Database
    {
        public static void CreateDatabase()
        {
            using SqlConnection connection = new(ConnectionStringConfig.MasterConnectionString);
            connection.Open();
            string checkDatabaseQuery = "SELECT database_id FROM sys.databases WHERE Name = 'BooksDb'";
            using SqlCommand cmd = new(checkDatabaseQuery, connection);
            object result = cmd.ExecuteScalar();
            if (result == null)
            {
                string createDatabaseQuery = "CREATE DATABASE BooksDb";
                using SqlCommand createCommand = new(createDatabaseQuery, connection);
                createCommand.ExecuteNonQuery();
            }
            connection.Close();

        }
    }
}
