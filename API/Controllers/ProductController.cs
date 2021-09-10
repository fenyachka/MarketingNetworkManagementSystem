using Application.Products;
using Application.Products.DTO;
using Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ProductDto = product }));
        }

    }
}
