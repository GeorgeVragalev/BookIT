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
        builder.Property(u=> u.Teacher).IsRequired(false);
        
        builder.HasIndex(x => x.TeacherId);

        builder.Ignore(u => u.Teacher);

        builder
            .HasOne(u => u.Teacher)
            .WithOne(t => t.User)
            .HasForeignKey<User>(u => u.TeacherId);
    }
}