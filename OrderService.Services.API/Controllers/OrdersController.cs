using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Models;
using OrderService.Domain.Services;
using OrderService.Services.API.Models;
using OrderService.Services.API.Services;

namespace OrderService.Services.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMessageSender messageSender;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMessageSender messageSender, IMapper mapper)
        {
            this.orderService = orderService;
            this.messageSender = messageSender;
            this.mapper = mapper;
        }

        [HttpGet("{code}")]
        public ActionResult<OrderViewModel> Get(string code)
        {
            var order = orderService.FindOrder(code);
            var orderViewModel = mapper.Map<OrderViewModel>(order);
            return Ok(orderViewModel);
        }

        [HttpPost]
        public ActionResult<OrderViewModel> Post([FromBody]CreateOrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var resultOrder = orderService.CreateOrder(mapper.Map<Order>(order));
                if (resultOrder.IsValid)
                    return Created($"/api/orders/{resultOrder.Model.Code}", mapper.Map<OrderViewModel>(resultOrder.Model));
                else
                    return BadRequest(resultOrder.Errors);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("CreateOrderAsync")]
        public IActionResult CreateOrderAsync([FromBody] CreateOrderViewModel order)
        {
            if(ModelState.IsValid)
            {
                messageSender.PublishOrder(order);
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}
