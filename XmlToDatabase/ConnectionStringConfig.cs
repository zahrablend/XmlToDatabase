namespace XmlToDatabase
{
    public static class ConnectionStringConfig
    {
        public static string MasterConnectionString => "Data Source=(local);Initial Catalog=master;Integrated Security=True";
        public static string BooksDbConnectionString => "Data Source=(local);Initial Catalog=BooksDb;Integrated Security=True";
    }
}
