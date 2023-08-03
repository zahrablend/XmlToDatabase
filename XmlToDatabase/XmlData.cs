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
            XmlNodeList dataNodes = xmlDoc.SelectNodes("book");

            using SqlConnection connection = new(ConnectionStringConfig.BooksDbConnectionString);
            connection.Open();

            foreach (XmlNode node in dataNodes)
            {
                int id = Convert.ToInt32(node.SelectSingleNode("id").InnerText);
                string author = node.SelectSingleNode("author").InnerText;
                string title = node.SelectSingleNode("title").InnerText;
                string genre = node.SelectSingleNode("genre").InnerText;
                decimal price = Convert.ToDecimal(node.SelectSingleNode("price").InnerText);
                DateTime publishDate = Convert.ToDateTime(node.SelectSingleNode("publish_date").InnerText);
                string description = node.SelectSingleNode("description").InnerText;

                string insertQuery = @"INSERT INTO Books (Id, Author, Title, Genre, Price, PublishDate, Description)
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
            //XDocument doc = XDocument.Load("books.xml");
            //var books = from b in doc.Descendants("book")
            //            select new Book(
            //                (int?)b.Element("id") ?? 0,
            //                (string?)b.Element("author") ?? string.Empty,
            //                (string?)b.Element("title") ?? string.Empty,
            //                (string?)b.Element("genre") ?? string.Empty,
            //                (decimal?)b.Element("price") ?? 0,
            //                (DateTime?)b.Element("publishDate") ?? DateTime.MinValue,
            //                (string?)b.Element("description") ?? string.Empty);

            //using SqlConnection connection = new(ConnectionStringConfig.BooksDbConnectionString);
            //connection.Open();
            //foreach (var book in dataNodes)
            //{
            //    //if (book.PublishDate < new DateTime(1753, 1, 1) || book.PublishDate > new DateTime(9999, 12, 31))
            //    //{

            //    //    continue;
            //    //}

            //    string insertQuery = @"INSERT INTO Books (Id, Author, Title, Genre, Price, PublishDate, Description)
            //            VALUES (@Id, @Author, @Title, @Genre, @Price, @PublishDate, @Description)";
            //    using SqlCommand command = new(insertQuery, connection);
            //    command.Parameters.AddWithValue("@id", book.Id);
            //    command.Parameters.AddWithValue("@author", book.Author);
            //    command.Parameters.AddWithValue("@title", book.Title);
            //    command.Parameters.AddWithValue("@genre", book.Genre);
            //    command.Parameters.AddWithValue("@price", book.Price);
            //    command.Parameters.AddWithValue("@publish_date", book.PublishDate);
            //    command.Parameters.AddWithValue("@description", book.Description);
            //    command.ExecuteNonQuery();
            //}
            //connection.Close();
        }
    }
}
