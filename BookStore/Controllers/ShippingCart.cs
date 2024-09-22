using BookStore.Data;
using BookStore.Data.Migrations;
using BookStore.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingCartsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ShippingCartsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("getbyid/{shippingid}")]
        public async Task<IActionResult> GetAllCarts(int shippingid)
        {
            var carts = await _db.ShippingCarts.FirstOrDefaultAsync(c => c.Id == shippingid);
            return Ok(carts);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _db.ShippingCarts.Include(c => c.Items).ToListAsync();
            return Ok(carts);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetCartById(string UserId)
        {
            try
            {
                var cart = await _db.ShippingCarts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == UserId);
                if (cart == null)
                {
                    return NotFound("Cart not found.");
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" {ex.Message}");
                return StatusCode(500, "خطا عند احضار معلومات السلة");
            }
        }


       
        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] ShippingCartModule cart)
        {
            if (cart == null)
            {
                return BadRequest("خطا في عناصر السلة");
            }

            _db.ShippingCarts.Add(cart);
            await _db.SaveChangesAsync();

            return Ok(new { message = "تم اضافة السلة " });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] ShippingCartModule cart)
        {
            if (cart == null || id != cart.Id)
            {
                return BadRequest("خطا في عناصر السلة");
            }

            var existingCart = await _db.ShippingCarts.FindAsync(id);
            if (existingCart == null)
            {
                return NotFound("السلة غير موجودة");
            }

            existingCart.UserId = cart.UserId;
            existingCart.DateCreated = cart.DateCreated;

            await _db.SaveChangesAsync();

            return Ok(new { message = "تمت تحديث السلة بنجاح" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _db.ShippingCarts.FindAsync(id);
            if (cart == null)
            {
                return NotFound("السلة غير موجودة");
            }

            _db.ShippingCarts.Remove(cart);
            await _db.SaveChangesAsync();

            return Ok(new { message = "تمت حذف السلة بنجاح" });
        }
    }
}
