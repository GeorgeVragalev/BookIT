using Backend.Entities.Rooms;
using Backend.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .HasOne(r => r.Room)
            .WithMany(a => a.Facilities)
            .HasForeignKey(r=>r.RoomId);
    }
}