using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfiguration
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasBaseType<User>();

            builder.Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
