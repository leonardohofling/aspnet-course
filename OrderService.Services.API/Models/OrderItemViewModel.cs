namespace OrderService.Services.API.Models
{
    public class OrderItemViewModel
    {
        public String ProductId { get; set; }

        public String ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}