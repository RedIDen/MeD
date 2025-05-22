namespace UserService.Domain.Model;

public class User
{
    public User(Guid id, string login, string name, string email, string passwordHash,
        DateTime? createDateTime = null, DateTime? editDateTime = null)
    {
        Id = id;
        Login = login;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreateDateTime = createDateTime ?? DateTime.UtcNow;
        EditDateTime = editDateTime ?? CreateDateTime;
    }

    public Guid Id { get; private set; }
    public string Login { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public DateTime CreateDateTime { get; private set; }
    public DateTime EditDateTime { get; private set; }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }
}
