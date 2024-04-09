using AutoMapper;
using GymManager.Core.MembershipType;
using GymManager.MembershipTypes.Dto;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}
