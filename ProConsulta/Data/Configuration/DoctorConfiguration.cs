using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired(true).HasColumnType("VARCHAR(100)");
            builder.Property(d => d.Document).IsRequired(true).HasColumnType("NVARCHAR(11)");
            builder.HasIndex(d => d.Document).IsUnique();
            builder.Property(d => d.CRM).IsRequired(true).HasColumnType("NVARCHAR(8)");
            builder.HasIndex(d => d.CRM).IsUnique();
            builder.Property(d => d.PhoneNumber).IsRequired(true).HasColumnType("NVARCHAR(11)");
            builder.Property(d => d.SpecialityId).IsRequired(true);

            builder.HasOne(d => d.Speciality)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Dockets)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
