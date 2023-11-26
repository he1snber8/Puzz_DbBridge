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
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.Property(u => u.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(u => u.Password)   
            .HasColumnType("varbinary")
            .HasMaxLength(35)
            .IsRequired()
            .HasConversion(
            p => p.HashData(),
            p => p);

        builder.Property(u => u.Email)
            .HasMaxLength(50)
            .HasColumnType("varchar")
            .IsRequired();
            
        builder.Property(c => c.RegistrationDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
