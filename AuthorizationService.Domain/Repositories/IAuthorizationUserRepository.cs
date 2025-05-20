using AuthorizationService.Domain.Model;

namespace AuthorizationService.Domain.Repositories;

public interface IAuthorizationUserRepository
{
    Task<AuthorizationUser?> GetByLoginAsync(string login, CancellationToken cancellationToken = default);
    Task<AuthorizationUser?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(AuthorizationUser user, CancellationToken cancellationToken = default);
}

