using System.Diagnostics;
using BackendUygulama.Controller;
using BackendUygulama.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace BirimTesti;

public class Tests
{
    private Mock<IUserDAO> _userDaoMock;
    private Mock<IConfiguration> _configurationMock;
    UsersController _controller;
    [SetUp]
    public void Setup()
    {
        _userDaoMock = new Mock<IUserDAO>();
        _configurationMock = new Mock<IConfiguration>();
        _controller = new UsersController(_userDaoMock.Object, _configurationMock.Object);

        var httpContext = new DefaultHttpContext();
        httpContext.User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(
            [
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, "test@example.com")
            ]
        ));
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };
    }

    [Test]
    public void StresTesi()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var users = _controller.GetUsers();
        var gecenSure = sw.ElapsedMilliseconds;
        sw.Stop();
        Assert.LessOrEqual(gecenSure, 1000);
    }
    [Test]
    public void GetUsers_WhenUserIsNotAuthorized_ReturnsUnauthorized()
    {
        // Arrange
        _userDaoMock.Setup(dao => dao.IsAuthorized("test@example.com")).Returns(false);
        // Act
        var result = _controller.GetUsers();

        // Assert
        Assert.IsInstanceOf<UnauthorizedObjectResult>(result.Result);
    }
}