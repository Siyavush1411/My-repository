using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfiguration
{
    internal class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Question)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(q => q.CorrectAnswer)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(q => q.WrongAnswer1)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(q => q.WrongAnswer2)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(q => q.WrongAnswer3)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
