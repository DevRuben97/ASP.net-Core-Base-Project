using AutoMapper;
using Domain.DTOs.Security;
using Domain.DTOs.Security.Permissions;
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

            //

            #region Permissions


            CreateMap<SystemModule, UserModulesDto>()
                .ForMember(s => s.Description, s => s.MapFrom(t => t.Name))
                .ForMember(s => s.Id, t => t.MapFrom(x => x.Id))
                .ForMember(s => s.Pages, t => t.MapFrom(t => t.SystemPages));

            CreateMap<SystemPage, UserModulePagesDto>()
                .ForMember(s => s.ModuleName, s => s.MapFrom(t => t.Module.Name))
                .ForMember(s => s.ModuleId, s => s.MapFrom(t => t.Module.Id))
                .ForMember(s => s.ModulePage, s => s.MapFrom(t => t.Name))
                .ForMember(s => s.ModulePageUrl, s => s.MapFrom(t => t.Path))
                .ForMember(s => s.ModulePageId, s => s.MapFrom(t => t.Id))
                .ForMember(s=> s.Icon, s=> s.MapFrom(t=> t.Icon))
                .ForMember(s => s.Actions, s => s.MapFrom(t => t.Actions))
                .ForMember(s => s.Childs, s => s.MapFrom(t => t.Childs));


            CreateMap<SystemPageAction, UserModulePageActionDto>()
                .ForMember(s => s.ActionId, s => s.MapFrom(t => t.Id))
                .ForMember(s => s.ActionName, s => s.MapFrom(t => t.Description));
            #endregion
        }
    }
}
