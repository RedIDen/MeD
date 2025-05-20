using AuthorizationService.Domain.Model;
using AuthorizationService.Persistence.Entities;
using Core.Mapping;

namespace AuthorizationService.Persistence.Mappers;

public class AuthorizationUserMapper 
    : IMapper<AuthorizationUser, AuthorizationUserEntity>
{
    public AuthorizationUser? ConvertFrom(AuthorizationUserEntity? item)
    {
        return item is null ? null : new AuthorizationUser(item.Id, item.Login, item.Password, item.CreateDateTime, item.EditDateTime);
    }

    public AuthorizationUserEntity? ConvertTo(AuthorizationUser? item)
    {
        return item is null ? null : new AuthorizationUserEntity()
        {
            Id = item.Id,
            Login = item.Login,
            Password = item.Password,
            CreateDateTime = item.CreateDateTime,
            EditDateTime = item.EditDateTime,
        };
    }
}
