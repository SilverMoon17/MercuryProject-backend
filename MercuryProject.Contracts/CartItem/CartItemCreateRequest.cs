namespace MercuryProject.Contracts.CartItem
{
    public record CartItemCreateRequest(
        Guid ProductId,
        int Quantity
    );
}
