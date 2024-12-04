using System.Security.Claims;
using BackendUygulama.DataAccess;
using BackendUygulama.Models;
using BackendUygulama.Models.ReturnModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendUygulama.Controller;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private UserDAO userDao;
    private IConfiguration configuration;

    public UsersController(UserDAO userDAO, IConfiguration configuration)
    {
        this.userDao = userDAO;
        this.configuration = configuration;
    }
    [HttpGet]
    public ActionResult<List<User>> GetUsers()
    {
        var mail = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        bool auth = userDao.IsAuthorized(mail);
        if (auth)
        {
            var result = userDao.GetUsers();
            var response = Response<List<User>>.Success(result);
            return Ok(response);
        }
        return Unauthorized("Unauthorized");
    }

    [HttpGet("{id}")]
    public ActionResult<RUser> GetUser(int id)
    {
        try
        {
            User? result = userDao.GetUser(id);
            if (result != null)
            {
                var rUser = new RUser(result);
                var response = Response<RUser>.Success(rUser);
                return Ok(response);
            }
            else
            {
                var response = Response<RUser>.Fail("Kullanıcı bulunamadı"); //ToDo: Mesajlar hardcode edilmeyecek
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
            var newUser = userDao.Add(user);
            return newUser;
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
            User? updatedUser = userDao.Update(user, id);
            if(updatedUser != null)
            {
                var response = Response<User>.Success(updatedUser);
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
        User? user = userDao.DeleteUser(id);
        if (user != null)
        {
            return Ok(Response<User>.Success(user));
        }
        return BadRequest(Response<User>.Fail("Kullanıcı Bulunamadı"));
    }

    [HttpPost("checkUser")]
    [AllowAnonymous]
    public ActionResult<string> CheckUser(User user)
    {
        var result = userDao.CheckUser(user);
        if (result != null)
        {
            var  stringToken =
                Security.CreateToken(user, configuration); //Sonraki sorguların atılmasında kullanılacak token
            return Ok(Response<UserToken>.Success(
                new UserToken(result, stringToken)));

        }

        return BadRequest(Response<string>.Fail("Kullanıcı bulunamadı ya da şifre yanlış"));
    }
}