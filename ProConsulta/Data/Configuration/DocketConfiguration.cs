using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuration;

public class DocketConfiguration : IEntityTypeConfiguration<Docket>
{
    public void Configure(EntityTypeBuilder<Docket> builder)
    {
        builder.ToTable("Dockets");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Observation).IsRequired().HasColumnType("VARCHAR(200)");
        builder.Property(d => d.DoctorId).IsRequired();
        builder.Property(d => d.PatientId).IsRequired();
        builder.Property(d => d.DateConsult).IsRequired();
        builder.Property(d => d.TimeConsult).IsRequired(false);

        //builder.HasOne(d => d.Doctor)
        //    .WithMany(d => d.Dockets)
        //    .HasForeignKey(d => d.DoctorId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.HasOne(d => d.Patient)
        //    .WithMany(p => p.Dockets)
        //    .HasForeignKey(d => d.PatientId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}