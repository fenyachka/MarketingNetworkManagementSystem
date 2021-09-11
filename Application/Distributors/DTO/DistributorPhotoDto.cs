using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.DTO
{
    public class DistributorPhotoDto
    {
        public IFormFile Photo { get; set; }
    }
}
