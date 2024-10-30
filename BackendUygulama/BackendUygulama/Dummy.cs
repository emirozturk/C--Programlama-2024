using BackendUygulama.Models;

namespace BackendUygulama;

public class Dummy
{
    public static List<User> users = new List<User>()
    {
        new User
        {
            Id = 1, Mail = "emirozturk@trakya.edu.tr", Password = "12345678", Username = "emirozturk",
            Name = "Emir Öztürk", Role = 0
        },
        new User
        {
            Id = 22, Mail = "ferhatyenilmez@trakya.edu.tr", Password = "12345678", Username = "D@sTrOyEr_*22*",
            Name = "Ferhat Yenilmez", Role = 1
        },
        new User
        {
            Id = 1, Mail = "ilkercelebi@trakya.edu.tr", Password = "12345678", Username = "ilkercelebi",
            Name = "İlker Çelebi", Role = 1
        },
        new User
        {
            Id = 1, Mail = "moustafamoustafa@trakya.edu.tr", Password = "12345678", Username = "Moustafa**2",
            Name = "Moustafa Moustafa", Role = 1
        },
        new User
        {
            Id = 1, Mail = "semreerol@trakya.edu.tr", Password = "12345678", Username = "m3",
            Name = "Selman Emre Erol", Role = 1
        },
    };

}