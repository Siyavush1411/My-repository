using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfiguration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasBaseType<User>();

            builder.Property(s => s.Login)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Grades)
                .IsRequired();

            builder.HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);
        }
    }
}
