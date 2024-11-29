namespace SuperDuperMart.Shared.DTOs
{
    public record LoginResponse(bool Succeeded, string Token, IEnumerable<string> Errors);
}
