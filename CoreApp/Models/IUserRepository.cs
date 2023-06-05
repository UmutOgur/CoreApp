namespace CoreApp.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
