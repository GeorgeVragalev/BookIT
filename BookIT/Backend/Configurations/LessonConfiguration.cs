using Backend.Entities.LessonEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class LessonConfiguration
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(s => s.Name).IsRequired(false);
        builder.Property(s => s.TeacherId).IsRequired(false);
        builder.Property(s => s.GroupId).IsRequired(false);
        builder.Property(s => s.SubjectId).IsRequired(false);
        builder.Property(s => s.RoomId).IsRequired(false);

        builder
            .HasOne(r => r.Room)
            .WithMany(a => a.Lessons)
            .HasForeignKey(r => r.RoomId);

        builder
            .HasOne(r => r.Teacher)
            .WithMany(a => a.Lessons)
            .HasForeignKey(r => r.TeacherId);

        builder
            .HasOne(r => r.Group)
            .WithMany(a => a.Lessons)
            .HasForeignKey(r => r.GroupId);

        builder
            .HasOne(r => r.TimePeriod)
            .WithMany(a => a.Lessons)
            .HasForeignKey(r => r.TimePeriodId);

        builder
            .HasOne(r => r.Subject)
            .WithMany(a => a.Lessons)
            .HasForeignKey(r => r.SubjectId);
    }
}