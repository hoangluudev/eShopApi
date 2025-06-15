using AutoMapper;
using eShopApi.Models.Entities;
using eShopApi.Dtos.Responses.User;
using eShopApi.Dtos.Requests.User;

namespace eShopApi.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entity -> ResponseDto
            CreateMap<User, UserSignUpResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            // RequestDto -> Entity
            CreateMap<UserSignUpRequestDto, User>();
        }
    }
}