using AuthorizationService.Domain.Model;

namespace AuthorizationService.DomainUT.Model;

public class AuthorizationUserTest
{
    [Test]
    public void VerifyPassword()
    {
        var id = Guid.NewGuid();
        var login = "test";
        var plainPassword = "my_secret";
        var hashed = BCrypt.Net.BCrypt.HashPassword(plainPassword);
        var user = new AuthorizationUser(id, login, System.Text.Encoding.UTF8.GetBytes(hashed));

        Assert.Multiple(() =>
        {
            Assert.That(user.VerifyPassword("my_secret"), Is.True);
            Assert.That(user.VerifyPassword("wrong_password"), Is.False);
        });
    }

    [Test]
    public void Create()
    {
        var id = Guid.NewGuid();
        var user = AuthorizationUser.Create(id, "test", "pass123");

        Assert.Multiple(() =>
        {
            Assert.That(user.VerifyPassword("pass123"), Is.True);
            Assert.That(user.VerifyPassword("wrong"), Is.False);
        });
    }
}
