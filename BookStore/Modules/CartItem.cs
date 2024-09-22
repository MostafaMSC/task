using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Modules
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ShippingCartId { get; set; }  // Foreign Key to ShippingCart
        public int BookId { get; set; }          // Foreign Key to Books
        public int Quantity { get; set; }

        //// Navigation properties
        //[ForeignKey("ShippingCartId")]
        //public virtual ShippingCartModule ShippingCart { get; set; }

        //[ForeignKey("BookId")]
        //public virtual Books Book { get; set; }
    }
}
