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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDistributor(Guid id, UpdateDistributorDto dto)
        {
            return HandleResult(await Mediator.Send(new Update.Command { Id=id,UpdateDistributorDto=dto }));
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> DeleteDistributor(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id}));
        }
    }
}
