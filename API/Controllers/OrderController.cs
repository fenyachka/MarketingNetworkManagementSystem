using Application.Orders;
using Application.Orders.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class OrderController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct(OrderDto order)
        {
            return HandleResult(await Mediator.Send(new Create.Command { OrderDto=order }));
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetDistributors([FromQuery] OrderParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }

    }
}
