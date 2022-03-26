using System.ComponentModel.DataAnnotations;

namespace OrderService.Services.API.Models
{
    public class CreateOrderItemViewModel
    {
        [Required]
        public String ProductId { get; set; }

        [Range(1, 9999)]
        public int Quantity { get; set; }
    }
}