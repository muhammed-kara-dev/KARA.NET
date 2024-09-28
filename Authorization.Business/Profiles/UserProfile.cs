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
            ;
        this.CreateMap<UserModel, User>()
            .ForMember(target => target.ID, config => config.MapFrom(source => source.ID))
            .ForMember(target => target.Name, config => config.MapFrom(source => source.Name))
            .ForMember(target => target.Email, config => config.MapFrom(source => source.Email))
            ;
    }
}