using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectBackend.DTO;

namespace MyProjectBackend.Repositories.Configurations;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.HasIndex(m => new {m.Id,m.User2Id,m.User1Id}).IsUnique();

        builder.ToTable("Matches");

        builder.Property(m => m.ChatHistory)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(m => m.IsActive)
            .HasDefaultValue(true);

        builder.Property(m => m.EndDate)
            .HasColumnType("datetime");

        builder.Property(m => m.StartDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
