using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserService.Persistence.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Login { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public DateTime CreateDateTime { get; set; }
    public DateTime EditDateTime { get; set; }
}

public class UserConfiguration
    : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Login).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.CreateDateTime).IsRequired();
        builder.Property(u => u.EditDateTime).IsRequired();
        builder.HasIndex(u => u.Login).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
    }
}
