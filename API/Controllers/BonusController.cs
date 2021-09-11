using Application.Bonus;
using Application.Bonus.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BonusController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateBonus(DateParamsDto dto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { DateParamsDto = dto }));
        }

    }
}
