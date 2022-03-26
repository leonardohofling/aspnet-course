using System.ComponentModel.DataAnnotations;

namespace OrderService.Services.API.Models
{
    public class CreateOrderViewModel
    {
        [Required]
        public string CustomerId { get; set; }

        [MinLength(1)]
        public List<CreateOrderItemViewModel> Items { get; set; }
    }
}
