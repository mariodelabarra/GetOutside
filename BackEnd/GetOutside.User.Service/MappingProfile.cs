using AutoMapper;
using GetOutside.User.Domain.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetOutside.User.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateIn, Domain.User>(MemberList.Source);
        }
    }
}
