using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfiguration
{
    internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.LessonName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(l => l.Schedule)
                .WithOne(s => s.Lesson)
                .HasForeignKey<Lesson>(l => l.ScheduleId);
        }
    }
}
