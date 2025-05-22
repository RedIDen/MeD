using Microsoft.EntityFrameworkCore;
using UserService.Domain.Model;

namespace UserService.Persistence.Context;

public class UserDbContext(DbContextOptions<UserDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
}
