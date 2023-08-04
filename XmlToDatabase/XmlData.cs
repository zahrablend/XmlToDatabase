using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;

namespace XmlToDatabase
{
    public static class XmlData
    {
        public static void LoadXmlData()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("books.xml");
            XmlNodeList? dataNodes = xmlDoc.SelectNodes("catalog/book");
            if (dataNodes != null)
            {
                using SqlConnection connection = new(ConnectionStringConfig.BooksDbConnectionString);
                connection.Open();

                foreach (XmlNode node in dataNodes)
                {
                    string id = node.Attributes.Item(0).Value;
                    string author = node.SelectSingleNode("author").InnerText;
                    string title = node.SelectSingleNode("title").InnerText;
                    string genre = node.SelectSingleNode("genre").InnerText;
                    decimal price = Convert.ToDecimal(node.SelectSingleNode("price").InnerText);
                    DateTime publishDate = Convert.ToDateTime(node.SelectSingleNode("publish_date").InnerText);
                    string description = node.SelectSingleNode("description").InnerText;

                    string insertQuery = @"INSERT INTO dbo.Book (Id, Author, Title, Genre, Price, PublishDate, Description)
                        VALUES (@Id, @Author, @Title, @Genre, @Price, @PublishDate, @Description)";
                    using SqlCommand command = new(insertQuery, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Author", author);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Genre", genre);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@PublishDate", publishDate);
                    command.Parameters.AddWithValue("@Description", description);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
    }
}
