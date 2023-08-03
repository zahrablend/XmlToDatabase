namespace XmlToDatabase
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Database.CreateDatabase();
            Table.CreateTable();
            XmlData.LoadXmlData();
        }
    }
}