using AutoMapper;
using AutoSAAS.models;
using AutoSAAS.Dtos;

namespace AutoSAAS.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForDataDto>();
            CreateMap<UserForDataDto, User>();
            CreateMap<UserGroupForTransmitionDto, UserGroup>();
            CreateMap<UserGroup, UserGroupForTransmitionDto>();
        }
    }
}