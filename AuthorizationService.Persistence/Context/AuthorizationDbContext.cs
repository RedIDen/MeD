using AuthorizationService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Persistence.Context;

public class AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) 
    : DbContext(options)
{
    public DbSet<AuthorizationUserEntity> Users => Set<AuthorizationUserEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorizationDbContext).Assembly);
    }
}