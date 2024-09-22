using Microsoft.AspNetCore.Identity;

namespace BookStore.Modules
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ShippingCartModule> ShippingCarts { get; set; } = new List<ShippingCartModule>();

    }
}
