using Authorization.Entities;
using Authorization.Models;
using AutoMapper;

namespace Authorization.Business;
public class UserProfile
    : Profile
{
    public UserProfile()
    {
        this.CreateMap<User, UserModel>()
            .ForMember(target => target.ID, config => config.MapFrom(source => source.ID))
            .ForMember(target => target.Name, config => config.MapFrom(source => source.Name))
            .ForMember(target => target.Email, config => config.MapFrom(source => source.Email))
            .ForMember(target => target.IsAuthenticated, config => config.MapFrom(_ => true))
            .ForMember(target => target.AuthenticationType, config => config.MapFrom(_ => string.Empty))
            ;
        this.CreateMap<UserModel, User>()
            .ForMember(target => target.ID, config => config.MapFrom(source => source.ID))
            .ForMember(target => target.Name, config => config.MapFrom(source => source.Name))
            .ForMember(target => target.Email, config => config.MapFrom(source => source.Email))
            ;
    }
}