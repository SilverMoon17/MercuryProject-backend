using Mapster;
using MapsterMapper;
using MercuryProject.Application.CartItem.Common;
using MercuryProject.Contracts.CartItem;
using MercuryProject.Domain.CartItem.Dto;
using MercuryProject.Domain.Idea.Dto;
using MercuryProject.Domain.ShoppingCart;
using MercuryProject.Domain.ShoppingCart.Dto;

namespace MercuryProject.API.Common.Mapping
{
    public class ShoppingCartMapping : IRegister
    {

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ShoppingCart, ShoppingCartDto>()
                .Map(dest => dest.shoppingCartId, src => src.Id.Value)
                .Map(dest => dest.CartItems, src => src.CartItems)
                .Map(dest => dest.CartState, src => src.CartState)
                .Map(dest => dest.Total, src => src.Total);



        }
    }
}
