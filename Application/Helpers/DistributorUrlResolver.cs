using Application.Distributors.DTO;
using AutoMapper;
using Domain.Entities.Distributors;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class DistributorUrlResolver : IValueResolver<Distributor, DistributorToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public DistributorUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Distributor source, DistributorToReturnDto destination, string destMember, ResolutionContext context)
        {
            var photo = source.Photo;
            if (photo != null)
            {
                return _config["ApiUrl"] + photo.PictureUrl;
            }
            return _config["ApiUrl"] + "images/placeholder.png";
        }
    }
}
