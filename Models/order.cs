namespace bookstore_communication_system.Models
{
    public class order
    {
        public int Id { get; set; }
        public List<Book>? Books { get; set; }
        public int Book { get; set; }
        public int Quantity { get; set; }   
        public decimal? Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
