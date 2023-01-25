using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(t => t.Quote).IsRequired(false);
        builder.Property(t => t.AboutMe).IsRequired(false);

        builder
            .HasOne(t => t.User)
            .WithOne(s => s.Teacher)
            .HasForeignKey<Teacher>(s=>s.UserId);
        
        builder
            .HasOne(t => t.Department)
            .WithMany(s => s.Teachers)
            .HasForeignKey(s => s.DepartmentId);
        
        builder
            .HasMany(r => r.Lessons)
            .WithOne(a => a.Teacher)
            .HasForeignKey(r=>r.TeacherId);
        
        builder
            .HasMany(t => t.Subjects)
            .WithMany(s => s.Teachers);
    }
}