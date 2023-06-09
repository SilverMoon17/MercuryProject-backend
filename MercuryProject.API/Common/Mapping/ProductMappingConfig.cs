using Mapster;
using MercuryProject.Application.Product.Commands.Create;
using MercuryProject.Application.Product.Common;
using MercuryProject.Contracts.Product;
using MercuryProject.Domain.Idea.Dto;
using MercuryProject.Domain.Product;
using MercuryProject.Domain.Product.Dto;

namespace MercuryProject.API.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<ProductResult, ProductResponse>().Map(dest => dest.Id, src => src.Product.Id.Value)
            //    .Map(dest => dest.UserId, src => src.Product.UserId)
            //    .Map(dest => dest, src => src.Product);

            config.NewConfig<ProductCreateRequest, ProductCreateCommand>()
                .Map(dest => dest.Files, src => src.Files != null ? src.Files.ToList() : new List<IFormFile>());


            config.NewConfig<ProductResult, ProductResponse>().Map(dest => dest.Id, src => src.Product.Id.Value)
                .Map(dest => dest, src => src.Product);
            config.NewConfig<Product, ProductDto>()
                .Map(dest => dest.productId, src => src.Id.Value)
                .Map(dest => dest, src => src);
        }
    }
}
