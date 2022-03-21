using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Services;
using OrderService.Services.API.Models;

namespace OrderService.Services.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet("{code}")]
        public ActionResult<OrderViewModel> Get(string code)
        {
            var order = orderService.FindOrder(code);
            var orderViewModel = mapper.Map<OrderViewModel>(order);
            return Ok(orderViewModel);
        }
    }
}
