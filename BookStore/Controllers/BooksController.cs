using BookStore.Data;
using BookStore.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _DB;

        public BooksController(ApplicationDbContext db)
        {
            _DB = db;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Books newBook)
        {
            if (newBook == null)
            {
                return BadRequest("خطا في معلومات الكتاب");
            }

            if (string.IsNullOrWhiteSpace(newBook.Book_Title) ||
                string.IsNullOrWhiteSpace(newBook.Book_Author) ||
                newBook.Book_Price <= 0)
            {
                return BadRequest("خطا في معلومات الكتاب");
            }

            await _DB.BooksTable.AddAsync(newBook);
            await _DB.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSpecificBookById), new { id = newBook.Id }, newBook);
        }




        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _DB.BooksTable.ToListAsync();
            return Ok(books);
        }

        [HttpGet("GetSpecificBook/{title}")]
        public async Task<IActionResult> GetSpecificBook(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("العنوان مطلوب");
            }

            var book = await _DB.BooksTable.FirstOrDefaultAsync(a => a.Book_Title == title);
            if (book == null)
            {
                return NotFound("الكتاب غير موجود");
            }
            return Ok(book);
        }
        [HttpGet("GetSpecificBookById/{id}")]
        public async Task<IActionResult> GetSpecificBookById(int id)
        {


            var book = await _DB.BooksTable.FirstOrDefaultAsync(a => a.Id == id);
            if (book == null)
            {
                return NotFound("الكتاب غير موجود");
            }
            return Ok(book);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Books BookToUpdate)
        {
            if (BookToUpdate == null)
            {
                return BadRequest("معلومات خاطئة");
            }

            var book = await _DB.BooksTable.FirstOrDefaultAsync(a => a.Id == BookToUpdate.Id);
            if (book == null)
            {
                return NotFound("الكتاب غير موجود");
            }

            book.Book_Title = BookToUpdate.Book_Title;
            book.Book_Author = BookToUpdate.Book_Author;
            book.Book_Price = BookToUpdate.Book_Price;
            book.Book_Genre = BookToUpdate.Book_Genre;
            book.Availablity_State = BookToUpdate.Availablity_State;

            await _DB.SaveChangesAsync();
            return Ok("تمت تعديل الكتاب بنجاح");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecificBook(int id)
        {
            var book = await _DB.BooksTable.FirstOrDefaultAsync(a => a.Id == id);
            if (book == null)
            {
                return NotFound("الكتاب غير موجود.");
            }

            _DB.BooksTable.Remove(book);
            await _DB.SaveChangesAsync();
            return Ok("تمت حذف الكتاب بنجاح");
        }
    }
}
