namespace BookStore.Modules
{
    public class OrderModule
    {
        public int Id { get; set; }
        public int ShippingCartId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } 
        public string ShippingAddress { get; set; } 
        public int phoneNumber { get; set; } 

        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
