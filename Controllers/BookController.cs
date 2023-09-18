using bookstore_communication_system.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookstore_communication_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> _books { get; set; } = new List<Book>();
        
        // GET: api/book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _books;
        }

       // GET api/bookController/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            try
            {
                return _books.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
            return _books.FirstOrDefault(b => b.Id == id);

        }

       // POST api/bookController
        [HttpPost]
        public void Post( [FromBody] Book value)
        {
            if (string.IsNullOrEmpty(value?.Title))
            {
                _books.Add(value);
            }
            var maxId = 0;
            if (_books.Count > 0)
            {
                maxId = _books.Max(x => x.Id);
            }
            value.Id = maxId + 1;
            _books.Add(value);
            
        }

        // PUT api/bookController/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            var item = _books.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                // Update *all* of the item's properties
                item.Title = value.Title;
                item.Author = value.Author;
                item.Price = value.Price;
                item.QuantityInStock = value.QuantityInStock;
            }
        }
        // DELETE api/bookController/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _books.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _books.Remove(item);
            }
        }
    }
}
