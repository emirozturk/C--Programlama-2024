using BackendUygulama.Models;

namespace BackendUygulama.DataAccess;

public interface IUserDAO
{
    List<User> GetUsers();
    User? GetUser(int id);
    User Add(User user);
    User? Update(User user, int id);
    User? DeleteUser(int id);
    User? CheckUser(User user);
    bool IsAuthorized(string? mail);
}