namespace CoreApp.Models
{
    public class UserRepository : IUserRepository
    {
        private UserContext context;
        public UserRepository(UserContext _context)
        {
            context = _context;
        }

        IEnumerable<User> IUserRepository.GetUsers()
        {
            return context.Users;
        }
    }
}
