using Self.Database;
using Self.Entity;
using Self.Service;

namespace HungryHUB.Service
{
    public class UserService : IUserService
    {
        private readonly MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            try
            {
                _context.Users1.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUser(int userId)
        {
            User user = _context.Users1.Find(userId);
            if (user != null)
            {
                _context.Users1.Remove(user);
                _context.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            _context.Users1.Update(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users1.ToList();
        }

        public User GetUser(int userId)
        {
            return _context.Users1.Find(userId);
        }

        public User ValidateUser(string email, string password)
        {
            return _context.Users1.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
        public User GetUserById(int userId)
        {
            return _context.Users1.Find(userId);
        }
    }
}
