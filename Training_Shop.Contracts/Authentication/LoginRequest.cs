namespace Training_Shop.Contracts.Authentication
{
    public record LoginRequest(
        string Email,
        string Password
        );
}
