namespace SuperDuperMart.Core.Interfaces
{
    public interface IUser
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
