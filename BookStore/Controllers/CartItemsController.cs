using BookStore.Data;
using BookStore.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CartItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var items = await _db.CartItems
               .ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemById(int id)
        {
            var item = await _db.CartItems
                .FirstOrDefaultAsync(ci => ci.Id == id);

            if (item == null)
            {
                return NotFound("السلة غير موجودة");
            }
            return Ok(item);
        }
        [HttpGet("GetByShipID/{shippingCartId}")]
        public async Task<IActionResult> GetCartItemByShippingId(int shippingCartId)
        {
            var items = await _db.CartItems
        .Where(ci => ci.ShippingCartId == shippingCartId)
        .ToListAsync();

            if (items == null)
            {
                return NotFound("عناصر السلة غير موجودة");
            }
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] CartItem cartItem)
        {
            if (cartItem == null)
            {
                return BadRequest("خطا في عناصر السلة");
            }

            var shippingCartExists = await _db.ShippingCarts.AnyAsync(sc => sc.Id == cartItem.ShippingCartId);
            var bookExists = await _db.BooksTable.AnyAsync(b => b.Id == cartItem.BookId);

            if (!shippingCartExists || !bookExists)
            {
                return BadRequest("Iخطا في معلومات السلة او معلومات الكتاب");
            }

            await _db.CartItems.AddAsync(cartItem);
            await _db.SaveChangesAsync();

            return Ok(new { message = "تم اضافة السلة بنجاح" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, [FromBody] CartItem cartItem)
        {
            if (cartItem == null || id != cartItem.Id)
            {
                return BadRequest("خطا في معلومات السلة");
            }

            var existingItem = await _db.CartItems.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound("السلة غير موجودة");
            }

            existingItem.Quantity = cartItem.Quantity;
            existingItem.BookId = cartItem.BookId;
            existingItem.ShippingCartId = cartItem.ShippingCartId;

            await _db.SaveChangesAsync();

            return Ok(new { message = "تمت تحديث السلة بنجاح" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var item = await _db.CartItems.FindAsync(id);
            if (item == null)
            {
                return NotFound("السلة غير موجودة");
            }

            _db.CartItems.Remove(item);
            await _db.SaveChangesAsync();

            return Ok(new { message = "تمت تحديث السلة بنجاح" });
        }

        [HttpDelete("ByBookId/{id}")]
        public async Task<IActionResult> DeleteCartItemByBookId(int id)
        {
            var item = await _db.CartItems.FirstOrDefaultAsync(a=>a.BookId == id);
            if (item == null)
            {
                return NotFound("السلة غير موجودة");
            }

            _db.CartItems.Remove(item);
            await _db.SaveChangesAsync();

            return Ok(new { message = "تمت حذف السلة بنجاح" });
        }
    }
}
