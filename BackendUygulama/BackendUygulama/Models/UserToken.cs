namespace BackendUygulama.Models;

public class UserToken
{
    public User User { get; set; }
    public string Token { get; set; }

    public UserToken(User user, string token)
    {
        User = user;
        Token = token;
    }
}