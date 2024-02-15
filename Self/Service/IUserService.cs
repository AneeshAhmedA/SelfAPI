using Self.Entity;

namespace Self.Service
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User GetUser(int userId);
        void EditUser(User user); 
        void DeleteUser(int userId);
        User ValidateUser(string email, string password);
        User GetUserById(int userId);
    }
}
