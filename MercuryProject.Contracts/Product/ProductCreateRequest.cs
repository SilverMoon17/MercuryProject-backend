namespace MercuryProject.Contracts.Product
{
    public record ProductCreateRequest(
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string Category,
        string IconUrl);
}
