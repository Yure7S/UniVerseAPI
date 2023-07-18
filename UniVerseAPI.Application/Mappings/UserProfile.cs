using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.Common;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Mappings
{
    internal class UsserProfile : Profile
    {
        public UsserProfile()
        {
            CreateMap<LoginOrUserInputDTO, User>();
            CreateMap<LoginOrUserInputDTO, User>();
        }
    }
}
