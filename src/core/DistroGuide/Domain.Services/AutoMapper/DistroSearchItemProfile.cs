using AutoMapper;
using DistroGuide.Domain.Model.Entities;
using DistroGuide.Domain.Services.Dto;

namespace DistroGuide.Domain.Services.AutoMapper
{
    public class DistroSearchItemProfile : Profile
    {
        public DistroSearchItemProfile()
        {
            CreateMap<Distro, DistroSearchItemDto>()
                .ForMember(d => d.B, map => map.MapFrom(f => f.BasedOn))
                .ForMember(d => d.I, map => map.MapFrom(f => f.Id))
                .ForMember(d => d.N, map => map.MapFrom(f => f.Name))
                .ForMember(d => d.P, map => map.MapFrom(f => f.IconUrl));
        }
    }
}
