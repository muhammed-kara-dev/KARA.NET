using AutoMapper;
using KPM.Entities;
using KPM.Models;

namespace KPM.Business;
public class PasswordProfile
    : Profile
{
    public PasswordProfile()
    {
        this.CreateMap<Password, PasswordModel>()
            .ForMember(target => target.ID, config => config.MapFrom(source => source.ID))
            .ForMember(target => target.Name, config => config.MapFrom(source => source.Name))
            ;
        this.CreateMap<PasswordModel, Password>()
            .ForMember(target => target.ID, config => config.Ignore())
            .ForMember(target => target.Name, config => config.MapFrom(source => source.Name))
            .ForMember(target => target.Value, config => config.Ignore())
            ;
    }
}