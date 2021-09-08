using Application.Distributors;
using Application.Distributors.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class DistributorController:BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<DistributorToReturnDto>>> GetDistributors([FromQuery] DistributorParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDistributor(CreateDistributorDto dto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { CreateDistributorDto = dto }));
        }
    }
}
