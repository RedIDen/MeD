using Microsoft.EntityFrameworkCore;
using UserService.Domain.Model;
using UserService.Domain.Repositories;
using UserService.Persistence.Context;

namespace UserService.Persistence.Repositories;

public class UserRepository(UserDbContext context) 
    : IUserRepository
{
    private readonly UserDbContext _context = context;

    public async Task<User?> GetByLoginAsync(string login, CancellationToken ct) =>
        await _context.Users.SingleOrDefaultAsync(u => u.Login == login, ct);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct) =>
        await _context.Users.SingleOrDefaultAsync(u => u.Email == email, ct);

    public async Task AddAsync(User user, CancellationToken ct)
    {
        await _context.Users.AddAsync(user, ct);
        await _context.SaveChangesAsync(ct);
    }
}
