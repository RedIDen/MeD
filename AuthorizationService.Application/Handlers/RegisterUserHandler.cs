using AuthorizationService.Application.Commands;
using AuthorizationService.Domain.Model;
using AuthorizationService.Domain.Repositories;

namespace AuthorizationService.Application.Handlers;

public class RegisterUserHandler(IAuthorizationUserRepository repository)
{
    private readonly IAuthorizationUserRepository _repository = repository;

    public async Task<Guid> HandleAsync(RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByLoginAsync(command.Login, cancellationToken);
        if (existing is not null)
            throw new InvalidOperationException("User already exists.");

        var user = new AuthorizationUser(Guid.NewGuid(), command.Login, command.Password);
        await _repository.CreateAsync(user, cancellationToken);
        return user.Id;
    }
}
