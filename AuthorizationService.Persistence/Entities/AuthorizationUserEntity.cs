using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthorizationService.Persistence.Entities;

public class AuthorizationUserEntity
{
    public Guid Id { get; set; }
    public string Login { get; set; } = default!;
    public byte[] Password { get; set; } = [];
    public DateTime CreateDateTime { get; set; }
    public DateTime EditDateTime { get; set; }
}

public class AuthorizationUserConfiguration 
    : IEntityTypeConfiguration<AuthorizationUserEntity>
{
    public void Configure(EntityTypeBuilder<AuthorizationUserEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Login).IsUnique();
        builder.Property(x => x.Login).IsRequired().HasMaxLength(128);
    }
}