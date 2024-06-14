using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfiguration
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.GroupName)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(g => g.CreationDate)
                .IsRequired();

            builder.HasOne(g => g.Schedule)
                .WithMany(s => s.Group)
                .HasForeignKey(g => g.ScheduleId);

            builder.HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);
        }
    }
}
