using Mapster;
using MercuryProject.Application.Authentication.Common;
using MercuryProject.Contracts.Authentication;

namespace MercuryProject.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            //    .Map(dest => dest, src => src.User);
            config.NewConfig<AuthenticationResult, AuthenticationResponse>().Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest, src => src.User);
        }
    }
}
