namespace OrderService.Services.API.Models
{
    public class OrderViewModel
    { 
        public string CustomerId { get; set; }

        public string Code { get; set; }

        public string Status { get; set; }

        public List<OrderItemViewModel> Items { get; set; }

        public decimal Total { get; set; }
    }
}
