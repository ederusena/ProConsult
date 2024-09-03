using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired(true).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Document).IsRequired(true).HasColumnType("NVARCHAR(11)");
            builder.HasIndex(p => p.Document).IsUnique();
            builder.Property(p => p.Email).IsRequired(true).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.PhoneNumber).IsRequired().HasColumnType("NVARCHAR(11)");
            builder.Property(p => p.BirthDate).IsRequired();
            builder.HasMany(d => d.Dockets)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
