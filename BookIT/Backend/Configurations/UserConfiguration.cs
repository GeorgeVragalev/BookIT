using Backend.Entities.Rooms;
using Backend.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u=> u.TeacherId).IsRequired(false);
        builder.Property(u=> u.StudentId).IsRequired(false);
        
        builder.HasIndex(x => x.TeacherId);
        builder.HasIndex(x => x.StudentId);

        builder.Ignore(u => u.Teacher);
        builder.Ignore(u => u.Student);

        builder
            .HasOne(u => u.Teacher)
            .WithOne(t => t.User)
            .HasForeignKey<User>(u => u.TeacherId);

        builder
            .HasOne(u => u.Student)
            .WithOne(t => t.User)
            .HasForeignKey<User>(u => u.StudentId);
    }
}