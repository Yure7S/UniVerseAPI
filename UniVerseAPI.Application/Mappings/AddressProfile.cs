using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Mappings
{
    internal class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressEntity, AddressResponseDTO>();
            CreateMap<AddressEntity, AddressEntity>();
        }
    }
}
