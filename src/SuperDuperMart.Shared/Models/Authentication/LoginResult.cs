namespace SuperDuperMart.Shared.Models.Authentication
{
    public record LoginResult
    {
        public bool Success { get; init; }
        public string? Token { get; init; }
    }
}
