using AuthorizationService.Application.Commands;
using AuthorizationService.Application.Handlers;
using AuthorizationService.Domain.Model;
using AuthorizationService.Domain.Repositories;
using Moq;

namespace AuthorizationService.ApplicationUT.Handlers;

public class RegisterUserHandlerTest
{
    [Test]
    public async Task HandleAsync_UserNotExist_Register()
    {
        var repo = new Mock<IAuthorizationUserRepository>();
        repo.Setup(x => x.GetByLoginAsync(It.IsAny<string>(), default))
            .ReturnsAsync((AuthorizationUser?)null);

        var handler = new RegisterUserHandler(repo.Object);
        var command = new RegisterUserCommand { Login = "test", Password = [1, 2, 3] };

        var result = await handler.HandleAsync(command);

        Assert.That(result, Is.Not.EqualTo(Guid.Empty));
        repo.Verify(x => x.CreateAsync(It.IsAny<AuthorizationUser>(), default), Times.Once);
    }

    [Test]
    public void HandleAsync_UserExists_ThrowsInvalidOperationException()
    {
        var existingUser = new AuthorizationUser(Guid.NewGuid(), "test", [1, 2, 3]);
        var repo = new Mock<IAuthorizationUserRepository>();
        repo.Setup(x => x.GetByLoginAsync("test", default)).ReturnsAsync(existingUser);

        var handler = new RegisterUserHandler(repo.Object);
        var command = new RegisterUserCommand { Login = "test", Password = [1, 2, 3] };

        Assert.ThrowsAsync<InvalidOperationException>(() => handler.HandleAsync(command));
    }
}