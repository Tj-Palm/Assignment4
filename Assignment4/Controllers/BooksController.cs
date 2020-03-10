using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment1;

namespace Assignment4.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> books = new List<Book>()
        {
            new Book("Title1", "Author1", 250, "asdasdasdasdf"),
            new Book("Title2", "Author2", 20, "asdfghasdfghj"),
            new Book("Title", "Author3", 200, "qweqweqweqwer"),
            new Book("Title", "Author4", 250, "qwertyqwertyu"),

        };

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET: api/Books/5
        [HttpGet("{Isbn13}")]
        public Book Get(string Isbn13)
        {
            return books.Find(i => i.Isbn13 == Isbn13);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut("{Isbn13}")]
        public void Put(string Isbn13, [FromBody] Book value)
        {
            Book book = Get(Isbn13);
            if (book != null)
            {
                book.Title = value.Title;
                book.Author = value.Author;
                book.Page = value.Page;
                book.Isbn13 = value.Isbn13;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{Isbn13}")]
        public void Delete(string Isbn13)
        {
            Book book = Get(Isbn13);
            books.Remove(book);
        }
    }
}
