namespace MercuryProject.Contracts.CartItem
{
    public record CartItemResponse
    (
        Guid Id,
        Domain.Product.Product Product
    );
}
