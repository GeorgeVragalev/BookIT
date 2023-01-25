using Backend.Entities.LessonEntities;
using Backend.Entities.UniversityEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class GroupConfiguration
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder
            .HasMany(r => r.Lessons)
            .WithOne(a => a.Group)
            .HasForeignKey(r=>r.GroupId);
        
        builder
            .HasMany(r => r.Students)
            .WithOne(a => a.Group)
            .HasForeignKey(r=>r.GroupId);
    }
}