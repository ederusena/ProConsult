using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuration;

public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
{
    public void Configure(EntityTypeBuilder<Speciality> builder)
    {
        builder.ToTable("Specialities");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasColumnType("VARCHAR(100)");
        builder.Property(s => s.Description).IsRequired(false).HasColumnType("VARCHAR(200)");

        builder.HasMany(s => s.Doctors)
            .WithOne(d => d.Speciality)
            .OnDelete(DeleteBehavior.Restrict);
    }
}