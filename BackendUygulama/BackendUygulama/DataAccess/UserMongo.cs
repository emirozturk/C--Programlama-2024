using BackendUygulama.Models;

namespace BackendUygulama.DataAccess;

public class UserMongo : IUserDAO
{
    public List<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public User? GetUser(int id)
    {
        throw new NotImplementedException();
    }

    public User Add(User user)
    {
        throw new NotImplementedException();
    }

    public User? Update(User user, int id)
    {
        throw new NotImplementedException();
    }

    public User? DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public User? CheckUser(User user)
    {
        throw new NotImplementedException();
    }

    public bool IsAuthorized(string? mail)
    {
        throw new NotImplementedException();
    }
}