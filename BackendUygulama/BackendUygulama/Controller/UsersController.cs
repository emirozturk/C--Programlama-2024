using BackendUygulama.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendUygulama.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<User>> GetUsers()
    {
        var result = Dummy.users;
        var response = Response<List<User>>.Success(result);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        try
        {
            var result = Dummy.users.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                var response = Response<User>.Success(result);
                return Ok(response);
            }
            else
            {
                var response = Response<User>.Fail("Kullanıcı bulunamadı"); //ToDo: Mesajlar hardcode edilmeyecek
                return NotFound(response);
            }
        }
        catch (Exception e)
        {
            return BadRequest(Response<User>.Fail(e.Message));
        }
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        try
        {
            user.Id = 55;
            Dummy.users.Add(user);
            return user;
        }
        catch (Exception e)
        {
            return BadRequest(Response<User>.Fail(e.Message));
        }
    }
    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(User user, int id)
    {
        try
        {
            //ToDo: Daha kısa hali var. Sınavdan sonra değiştirilecek.
            var result = Dummy.users.FirstOrDefault(x => x.Id==id);
            if (result != null)
            {
                result.Id = user.Id;
                result.Name = user.Name;
                result.Mail = user.Mail;
                result.Password = user.Password;
                result.Role = user.Role;
                
                var response = Response<User>.Success(result);
                return Ok(response);
            }
            else
            {
                var response = Response<User>.Fail("Kullanıcı bulunamadı"); //ToDo: Mesajlar hardcode edilmeyecek
                return NotFound(response);
            }
        }
        catch (Exception e)
        {
            return BadRequest(Response<User>.Fail(e.Message));
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<User> DeleteUser(int id)
    {
        var user = Dummy.users.FirstOrDefault(x => x.Id == id);
        Dummy.users.Remove(user);
        return Ok(Response<User>.Success(user));
    }
}