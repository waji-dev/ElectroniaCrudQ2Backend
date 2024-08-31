using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ElectroniaCrudQ2Backend.Models.Entities;
using ElectroniaCrudQ2Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectroniaCrudQ2Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
   
    public class BooksController : ControllerBase
    {
        // GET: api/<BooksController>

        private readonly ApplicationDbContext _context;
       
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
          
        }
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _context.Books;
        }
        //// GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Book book = null;
            if (id == null)
            {
                return NotFound();
            }

            book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> Post([Bind("Title,Author,Price")]Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return Ok(string.Format("Book {0} has been added successfully", book.BookId.ToString()));
            }
            return BadRequest(book);
        }


        //// DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return Ok(string.Format("Book {0} deleted successfully", book.BookId.ToString()));
        }
    }
}
