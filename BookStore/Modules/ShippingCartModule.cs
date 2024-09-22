using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Modules
{
    public class ShippingCartModule
    {
        public int Id { get; set; }

        public string UserId { get; set; } // Identity User

        public DateTime DateCreated { get; set; }

        // Collection of CartItems
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
