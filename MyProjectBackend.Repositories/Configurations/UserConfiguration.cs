using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectBackend.DTO;
using MyProjectBackend.Facade;

namespace MyProjectBackend.Repositories.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.Property(u => u.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasColumnType("varbinary(MAX)")
            .HasConversion(
            p => p.HashData(),
            p => p);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar");
            
        builder.Property(c => c.RegistrationDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");
    }
}
