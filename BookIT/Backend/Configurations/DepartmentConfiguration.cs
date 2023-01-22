using Backend.Entities.UniversityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .HasMany(d => d.Teachers)
            .WithOne(t => t.Department)
            .HasForeignKey(d => d.DepartmentId);
    }
}