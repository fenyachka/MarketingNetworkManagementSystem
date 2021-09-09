using Application.Distributors.DTO;
using Application.Helpers;
using AutoMapper;
using Domain.Entities.Distributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Distributor, DistributorToReturnDto>()
                .ForMember(x => x.AddressDetails, y => y.MapFrom(z => z.AddressInfo.AddressDetails))
                .ForMember(x => x.ContactDetails, y => y.MapFrom(z => z.ContactInfo.ContactDetails))
                .ForMember(x => x.PrivateNumber, y => y.MapFrom(z => z.DocumentInfo.PrivateNumber))
                .ForMember(x => x.PictureUrl, y => y.MapFrom<DistributorUrlResolver>());

            CreateMap<CreateDistributorDto, Distributor>()
                .ForMember(x => x.Id, y => y.MapFrom(z => Guid.NewGuid()));
            CreateMap<AddressInfoDto, AddressInfo>();
            CreateMap<DocumentInfoDto, DocumentInfo>();
            CreateMap<ContactInfoDto, ContactInfo>();

            CreateMap<UpdateDistributorDto, Distributor>();
        }

     
    }
}
