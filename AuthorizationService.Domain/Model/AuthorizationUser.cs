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

    public bool VerifyPassword(byte[] inputPassword)
    {
        return Password.SequenceEqual(inputPassword); // TODO: rework
    }
}
