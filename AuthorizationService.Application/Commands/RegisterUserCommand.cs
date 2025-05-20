namespace AuthorizationService.Application.Commands;

public class RegisterUserCommand
{
    public string Login { get; init; } = default!;
    public byte[] Password { get; init; } = default!;
}

