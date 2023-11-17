using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectBackend.DTO;

namespace MyProjectBackend.Repositories.Configurations;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.HasIndex(m => new {m.User2Id,m.User1Id}).IsUnique();

        builder.ToTable("Matches");

        builder.Property(m => m.ChatHistory)
            .HasColumnType("VARCHAR(MAX)")
            .IsRequired(false);

        builder.Property(m => m.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(m => m.ChatStart)
            .HasDefaultValueSql("GetDate()");

        builder.HasOne(u => u.User1)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired()
            .HasForeignKey(u => u.User1Id);

        builder.HasOne(u => u.User2)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired()
            .HasForeignKey(u => u.User2Id);

    }
}
