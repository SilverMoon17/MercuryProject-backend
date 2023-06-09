using Mapster;
using MercuryProject.Application.CartItem.Common;
using MercuryProject.Contracts.CartItem;
using MercuryProject.Domain.CartItem;
using MercuryProject.Domain.CartItem.Dto;
using MercuryProject.Domain.Idea.Dto;

namespace MercuryProject.API.Common.Mapping
{
    public class CartItemMappingConfig : IRegister
    {
        /*public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CartItemResult, CartItemResponse>()
                .Map(dest => dest.Id, src => src.CartItem.Id.Value)
                .ConstructUsing(src => Product.Create(
                    src.CartItem.Product.UserId,
                    src.CartItem.Product.Name,
                    src.CartItem.Product.Description,
                    src.CartItem.Product.Price,
                    src.CartItem.Product.Stock,
                    src.CartItem.Product.Category,
                    src.CartItem.Product.IconUrl))
                .Map(dest => dest.Product, src => src.CartItem.Product);
        }*/

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CartItemResult, CartItemResponse>()
                .ConstructUsing(src => new CartItemResponse(
                    src.CartItem.Id.Value,
                    src.CartItem.Product))
                .Map(dest => dest.Product, src => src.CartItem.Product);

            config.NewConfig<CartItem, CartItemDto>()
                .Map(dest => dest.CartItemId, src => src.Id.Value)
                .Map(dest => dest.Product, src => src.Product)
                .Map(dest => dest, src => src);
        }
    }
}
