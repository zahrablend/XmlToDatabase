namespace XmlToDatabase
{
    public class Book
    {
        public string? Id { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Description { get; set; }

        public Book(string id, string author, string title, string genre, decimal price, DateTime publishDate, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            Genre = genre;
            Price = price;
            PublishDate = publishDate;
            Description = description;
        }
    }
}
