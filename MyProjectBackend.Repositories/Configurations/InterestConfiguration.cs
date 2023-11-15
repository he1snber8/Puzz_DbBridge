using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectBackend.DTO;

namespace MyProjectBackend.Repositories.Configurations;

public class InterestConfiguration : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .HasMaxLength(75)
            .HasColumnType("varchar")
            .IsRequired();

        builder.HasMany(i => i.UserInterests)
            .WithOne(ui => ui.Interest)
            .HasForeignKey(ui => ui.InterestId); ;
    }
}
