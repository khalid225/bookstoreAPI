namespace bookstore_communication_system.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
    }
}
