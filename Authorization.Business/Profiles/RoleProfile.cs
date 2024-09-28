using Authorization.Entities;
using Authorization.Models;
using AutoMapper;

namespace Authorization.Business;
public class RoleProfile
    : Profile
{
    public RoleProfile()
    {
        this.CreateMap<Role, RoleModel>()
            .ForMember(target => target.ID, config => config.MapFrom(source => source.ID))
            .ForMember(target => target.Name, config => config.MapFrom(source => source.Name))
            .ForMember(target => target.Description, config => config.MapFrom(source => source.Description))
            ;
        this.CreateMap<RoleModel, Role>()
            .ForMember(target => target.ID, config => config.MapFrom(source => source.ID))
            .ForMember(target => target.Name, config => config.MapFrom(source => source.Name))
            .ForMember(target => target.Description, config => config.MapFrom(source => source.Description))
            .ForMember(target => target.UserRoles, config => config.Ignore())
            ;
    }
}