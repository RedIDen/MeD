using AuthorizationService.Application.Commands;
using AuthorizationService.Application.Services;
using AuthorizationService.Domain.Repositories;

namespace AuthorizationService.Application.Handlers;

public class LoginUserHandler(
    IAuthorizationUserRepository repository,
    ITokenService tokenService)
{
    public async Task<string> HandleAsync(LoginUserCommand command, CancellationToken ct = default)
    {
        var user = await repository.GetByLoginAsync(command.Login, ct)
            ?? throw new InvalidOperationException("Invalid login or password");

        if (!user.VerifyPassword(command.Password))
            throw new InvalidOperationException("Invalid login or password");

        return tokenService.Generate(user);
    }
}
