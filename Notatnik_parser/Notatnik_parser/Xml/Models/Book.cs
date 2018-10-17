namespace Notatnik_parser.Xml.Models
{
    public class Book
    {
        public int Pages { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Author[] Authors { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
    }
}
