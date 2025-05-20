using AuthorizationService.Domain.Model;
using AuthorizationService.Domain.Repositories;
using AuthorizationService.Persistence.Context;
using AuthorizationService.Persistence.Entities;
using Core.Mapping;
using System.Data.Entity;

namespace AuthorizationService.Persistence.Repositories;

public class AuthorizationUserRepository(AuthorizationDbContext context,
    IMapper<AuthorizationUser, AuthorizationUserEntity> mapper) 
    : IAuthorizationUserRepository
{
    private readonly AuthorizationDbContext _context = context;
    private readonly IMapper<AuthorizationUser, AuthorizationUserEntity> _mapper = mapper;

    public async Task<AuthorizationUser?> GetByLoginAsync(string login, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(x => x.Login == login, cancellationToken);
        return _mapper.ConvertFrom(entity);
    }

    public async Task<AuthorizationUser?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Users.FindAsync([id], cancellationToken);
        return _mapper.ConvertFrom(entity);
    }

    public async Task CreateAsync(AuthorizationUser user, CancellationToken cancellationToken = default)
    {
        _context.Users.Add(_mapper.ConvertTo(user));
        await _context.SaveChangesAsync(cancellationToken);
    }
}
