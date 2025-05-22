using AuthorizationService.Domain.Model;

namespace AuthorizationService.Application.Services;

public interface ITokenService
{
    string Generate(AuthorizationUser user);
}
