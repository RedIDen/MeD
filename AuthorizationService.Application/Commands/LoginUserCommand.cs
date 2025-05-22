namespace AuthorizationService.Application.Commands;

public class LoginUserCommand
{
    public string Login { get; init; } = default!;
    public string Password { get; init; } = default!;
}
