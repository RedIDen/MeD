using System.Text;

namespace AuthorizationService.Domain.Model;

public class AuthorizationUser
{
    public AuthorizationUser(Guid id, string login, byte[] password,
        DateTime? createDateTime = null, DateTime? editDateTime = null)
    {
        Id = id;
        Login = login;
        Password = password ?? [];
        CreateDateTime = createDateTime ?? DateTime.UtcNow;
        EditDateTime = editDateTime ?? CreateDateTime;
    }

    public Guid Id { get; }
    public string Login { get; }
    public byte[] Password { get; }

    public DateTime CreateDateTime { get; }
    public DateTime EditDateTime { get; }

    public static AuthorizationUser Create(Guid id, string login, string rawPassword)
    {
        var hashed = BCrypt.Net.BCrypt.HashPassword(rawPassword);
        return new AuthorizationUser(id, login, Encoding.UTF8.GetBytes(hashed));
    }

    public bool VerifyPassword(string inputPassword)
    {
        var stored = Encoding.UTF8.GetString(Password);
        return BCrypt.Net.BCrypt.Verify(inputPassword, stored);
    }
}
