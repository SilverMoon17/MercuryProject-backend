using Mapster;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Contracts.Idea;
using MercuryProject.Domain.Idea;
using MercuryProject.Domain.Idea.Dto;

namespace MercuryProject.API.Common.Mapping
{
    public class IdeaMappingConfig : IRegister
    {

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<IdeaResult, IdeaResponse>().Map(dest => dest.Id, src => src.Idea.Id.Value)
                .Map(dest => dest.OwnerId, src => src.Idea.OwnerId)
                .Map(dest => dest, src => src.Idea);
            config.NewConfig<Idea, IdeaDto>().Map(dest => dest, src => src);
        }
    }
}
