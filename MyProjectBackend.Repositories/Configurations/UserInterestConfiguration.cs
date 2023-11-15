using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectBackend.DTO;

namespace MyProjectBackend.Repositories.Configurations;

public class UserInterestConfiguration : IEntityTypeConfiguration<UserInterest>
{
    public void Configure(EntityTypeBuilder<UserInterest> builder)
    {
        builder.HasNoKey();

        builder.HasKey(pk => new { pk.InterestId, pk.UserId });

        builder.HasOne(i => i.Interest)
               .WithMany(ui => ui.UserInterests)
               .HasForeignKey(i => i.InterestId);

        builder.HasOne(u => u.User)
               .WithMany(ui => ui.UserInterests)
               .HasForeignKey(ui => ui.UserId);
    }
}