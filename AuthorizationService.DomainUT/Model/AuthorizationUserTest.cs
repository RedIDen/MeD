using AuthorizationService.Domain.Model;

namespace AuthorizationService.DomainUT.Model;

public class AuthorizationUserTest
{
    [TestCase]
    public void Constructor()
    {
        var id = Guid.NewGuid();
        var login = "login";
        var password = new byte[] { 1, 2, 3 };
        var createDateTime = new DateTime(2025, 5, 20, 22, 19, 0);
        var editDateTime = new DateTime(2025, 5, 20, 22, 20, 0);

        var user = new AuthorizationUser(id, login, password, createDateTime, editDateTime);

        Assert.Multiple(() =>
        {
            Assert.That(user.Id, Is.EqualTo(id));
            Assert.That(user.Login, Is.EqualTo(login));
            Assert.That(user.Password, Is.EqualTo(password));
            Assert.That(user.CreateDateTime, Is.EqualTo(createDateTime));
            Assert.That(user.EditDateTime, Is.EqualTo(editDateTime));
        });
    }
}
