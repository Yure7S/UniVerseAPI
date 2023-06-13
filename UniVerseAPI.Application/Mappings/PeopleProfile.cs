using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Mappings
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<People, PeopleResponseDTO>();
            CreateMap<PeopleInputDTO, People>();
        }
    }
}
