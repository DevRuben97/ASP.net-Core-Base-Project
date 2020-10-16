using AutoMapper;
using Domain.DTOs.Security;
using Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MapProfiles
{
   public class SecurityProfile: Profile
    {
        public SecurityProfile()
        {
            CreateMap<User, UserDto>();
            //
            CreateMap<UserDto, User>();
        }
    }
}
