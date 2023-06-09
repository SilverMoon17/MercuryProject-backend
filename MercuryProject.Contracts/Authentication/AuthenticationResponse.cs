namespace MercuryProject.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string Role,
        string Username,
        string Fullname,
        string Email,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime,
        string Token);
}
