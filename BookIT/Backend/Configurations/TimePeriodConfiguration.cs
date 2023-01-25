using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class TimePeriodConfiguration : IEntityTypeConfiguration<TimePeriod>
{
    public void Configure(EntityTypeBuilder<TimePeriod> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .HasMany(r => r.Lessons)
            .WithOne(a => a.TimePeriod)
            .HasForeignKey(r=>r.TimePeriodId);
    }
}