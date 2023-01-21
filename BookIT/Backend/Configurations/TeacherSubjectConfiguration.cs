using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class TeacherSubjectConfiguration : IEntityTypeConfiguration<TeacherSubject>
{
    public void Configure(EntityTypeBuilder<TeacherSubject> builder)
    {
        builder.HasKey(sc => new { sc.SubjectId, sc.TeacherId });

        builder
            .HasOne(sc => sc.Teacher)
            .WithMany(s => s.TeacherSubjects)
            .HasForeignKey(sc => sc.TeacherId);


        builder
            .HasOne(sc => sc.Subject)
            .WithMany(s => s.TeacherSubjects)
            .HasForeignKey(sc => sc.SubjectId);
    }
}