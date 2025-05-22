using AuthorizationService.Application.Commands;
using AuthorizationService.Application.Handlers;
using AuthorizationService.Application.Services;
using AuthorizationService.Domain.Model;
using AuthorizationService.Domain.Repositories;
using Moq;

namespace AuthorizationService.ApplicationUT.Handlers;

public class LoginUserHandlerTest
{
    [Test]
    public async Task HandleAsync_ValidCredentials_ReturnsToken()
    {
        var password = "secret123";
        var hashed = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new AuthorizationUser(Guid.NewGuid(), "user", System.Text.Encoding.UTF8.GetBytes(hashed));

        var repo = new Mock<IAuthorizationUserRepository>();
        repo.Setup(x => x.GetByLoginAsync("user", default)).ReturnsAsync(user);

        var tokenService = new Mock<ITokenService>();
        tokenService.Setup(x => x.Generate(user)).Returns("mocked_token");

        var handler = new LoginUserHandler(repo.Object, tokenService.Object);

        var token = await handler.HandleAsync(new LoginUserCommand { Login = "user", Password = password });

        Assert.That(token, Is.EqualTo("mocked_token"));
    }

    [Test]
    public void HandleAsync_InvalidCredentials_ThrowsInvalidOperationException()
    {
        var correctPassword = "abc123";
        var wrongPassword = "wrong_password";
        var hashed = BCrypt.Net.BCrypt.HashPassword(correctPassword);
        var user = new AuthorizationUser(Guid.NewGuid(), "user", System.Text.Encoding.UTF8.GetBytes(hashed));

        var repo = new Mock<IAuthorizationUserRepository>();
        repo.Setup(x => x.GetByLoginAsync("user", default)).ReturnsAsync(user);

        var tokenService = new Mock<ITokenService>();
        var handler = new LoginUserHandler(repo.Object, tokenService.Object);

        var cmd = new LoginUserCommand { Login = "user", Password = wrongPassword };

        Assert.ThrowsAsync<InvalidOperationException>(() => handler.HandleAsync(cmd));
    }
}
