using Core.Mapping;
using UserService.Domain.Model;
using UserService.Persistence.Entities;

namespace UserService.Persistence.Mappers
{
    public class UserMapper 
        : IMapper<User, UserEntity>
    {
        public User? ConvertFrom(UserEntity? item)
        {
            return item is null 
                ? null 
                : new User(item.Id, item.Login, item.Name, item.Email, item.PasswordHash, item.CreateDateTime, item.EditDateTime);
        }

        public UserEntity? ConvertTo(User? item)
        {
            return item is null
                ? null
                : new UserEntity()
                {
                    Id = item.Id,
                    Login = item.Login,
                    Name = item.Name,
                    Email = item.Email,
                    PasswordHash = item.PasswordHash,
                    CreateDateTime = item.CreateDateTime,
                    EditDateTime = item.EditDateTime
                };
        }
    }
}
