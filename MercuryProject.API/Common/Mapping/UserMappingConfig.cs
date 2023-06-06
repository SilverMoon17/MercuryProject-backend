using Mapster;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Application.User.Commands;
using MercuryProject.Application.User.Common;
using MercuryProject.Contracts.Idea;
using MercuryProject.Domain.Idea.Dto;
using MercuryProject.Domain.User;
using MercuryProject.Domain.User.Dto;

namespace MercuryProject.API.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserResult, UpdateUserInfoCommand>().Map(dest => dest, src => src.User);
            config.NewConfig<UserResult, UserDto>()
                .Map(dest => dest.FullName, src => src.User.Fullname)
                .Map(dest => dest, src => src.User);
        }
    }
}
