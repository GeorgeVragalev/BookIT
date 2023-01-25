﻿using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder
            .HasMany(r => r.Lessons)
            .WithOne(a => a.Subject)
            .HasForeignKey(r=>r.SubjectId);
    }
}