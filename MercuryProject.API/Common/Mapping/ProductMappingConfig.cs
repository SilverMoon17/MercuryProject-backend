﻿using Mapster;
using MercuryProject.Application.Product.Common;
using MercuryProject.Contracts.Product;
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

            config.NewConfig<ProductResult, ProductResponse>().Map(dest => dest.Id, src => src.Product.Id.Value)
                .Map(dest => dest, src => src.Product);
            config.NewConfig<Product, ProductDto>()
                .Map(dest => dest.productId, src => src.Id.Value)
                .Map(dest => dest, src => src);
        }
    }
}
