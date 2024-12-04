namespace BackendUygulama.Models.ReturnModels;

public class RUser
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public RUser(User user)
    {
        Id = user.Id;
        Username = user.Username;
    }
}