using BackendUygulama.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendUygulama.DataAccess;

public class UserDAO : IUserDAO
{
    ScrumboarddbContext _context;

    public UserDAO(ScrumboarddbContext context)
    {
        _context = context;
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }
    
    public User? GetUser(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public User Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User? Update(User user, int id)
    {
        _context.Users.Update(user);
        return user;
    }

    public User? DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            return user;
        }
        return null;
    }

    public User? CheckUser(User user)
    {
        var result = _context.Users.FirstOrDefault(x => x.Id == user.Id && x.Password == user.Password);
        return result;
    }

    public bool IsAuthorized(string? mail)
    {
        var user = _context.Users.FirstOrDefault(u => u.Mail == mail);
        return user is { Role: 0 };
    }
}