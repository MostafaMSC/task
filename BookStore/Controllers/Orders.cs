using BookStore.Data;
using BookStore.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders : ControllerBase
    {
        private readonly ApplicationDbContext _DB;
        private readonly HttpClient _httpClient;

        public Orders(ApplicationDbContext db, HttpClient httpClient)
        {
            _DB = db;
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder([FromBody] OrderModule shippingInfo)
        {
            var shippingCart = await _httpClient.GetFromJsonAsync<ShippingCartModule>($"https://localhost:7161/api/ShippingCarts/getbyid/{shippingInfo.ShippingCartId}");
            if (shippingCart == null)
            {
                return BadRequest("السلة فارغة");
            }

            var cartItems = await _httpClient.GetFromJsonAsync<List<CartItem>>($"https://localhost:7161/api/CartItems/GetByShipID/{shippingCart.Id}");
            if (cartItems == null || !cartItems.Any())
            {
                return BadRequest("لا عناصر بالسلة");
            }

            var orderItems = new List<OrderItem>();
            decimal totalAmount = 0;

            foreach (var item in cartItems)
            {
                var book = await _httpClient.GetFromJsonAsync<Books>($"https://localhost:7161/api/Books/GetSpecificBookById/{item.BookId}");
                if (book == null)
                {
                    return BadRequest($"غير موجود {item.BookId}");
                }

                var orderItem = new OrderItem
                {
                    BookId = item.BookId,
                    Quantity = item.Quantity,
                    UnitPrice = book.Book_Price
                };

                orderItems.Add(orderItem);
                totalAmount += orderItem.Quantity * orderItem.UnitPrice;
            }

           
            var order = new OrderModule
            {
                ShippingCartId = shippingCart.Id,
                OrderDate = DateTime.UtcNow,
                phoneNumber = shippingInfo.phoneNumber,
                TotalAmount = totalAmount,
                Status = "Pending",
                ShippingAddress = shippingInfo.ShippingAddress, 
                OrderItems = orderItems
                
            };

            _DB.OrdersTable.Add(order);

            order.Status = "Completed";
            _DB.ShippingCarts.Update(shippingCart);

            await _DB.SaveChangesAsync();

            return Ok(new { message = "تمت معالجة طلبك بنجاح", orderId = order.Id });
        }
        //[HttpGet("{userid}")]
        //public async Task<IActionResult> GetOrdersByUserId(string userid)
        //{
        //    if (string.IsNullOrEmpty(userid))
        //    {
        //        return BadRequest("User Authontication is required.");
        //    }

        //    var book = await _DB.OrdersTable.FirstOrDefaultAsync(a => a.Book_Title == userid);
        //    if (book == null)
        //    {
        //        return NotFound("Book not found.");
        //    }
        //    return Ok(book);
        //}
    }
    
}
