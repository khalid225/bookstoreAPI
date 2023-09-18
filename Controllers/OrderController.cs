using Microsoft.AspNetCore.Mvc;
using bookstore_communication_system.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookstore_communication_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private List<order> _orders = new List<order>();
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", QuantityInStock = 10, Price = 19.99M },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", QuantityInStock = 15, Price = 24.99M },
            // Add more books here...
        };


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<order> Get()
        {
            return _orders;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public order Get(int id)
        {
            var BookOrder = _orders.FirstOrDefault(o => o.Id == id);

            if (BookOrder == null)
            {
                NotFound(); // Return a 404 Not Found if the order is not found.
            }
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] List<int> bookIds)
        {
            // Checks if any of the selected books are out of stock.
            foreach (var bookId in bookIds)
            {
                var book = _books.FirstOrDefault(b => b.Id == bookId);
                if (book == null || book.QuantityInStock <= 0)
                {
                    BadRequest("One or more selected books are out of stock.");
                }
            }

            // Create a new order based on the book IDs and calculate the total price.
            var BookOrder = new order
            {
                Id = _orders.Count + 1,
                Books = _books.Where(b => bookIds.Contains(b.Id)).ToList(),
                TotalPrice = _books.Where(b => bookIds.Contains(b.Id)).Sum(b => b.Price),
                OrderDate = DateTime.Now
            };

            //Adds the created order to the list of orders.
            _orders.Add(BookOrder);

            // Update book stock (subtract ordered quantities from stock).
            foreach (var bookId in bookIds)
            {
                var book = _books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.QuantityInStock--;
                }
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
