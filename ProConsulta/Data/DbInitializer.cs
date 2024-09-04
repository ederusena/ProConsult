using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole()
                    {
                        Id = "1a4167cf-a029-4b46-b224-c0d656a2f8bf",
                        Name = "Atendente",
                        NormalizedName = "ATENDENTE"
                    },
                    new IdentityRole()
                    {
                        Id = "bf745e70-7397-4e14-bd88-4225b96d6c58",
                        Name = "Medico",
                        NormalizedName = "MEDICO"
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();
            _modelBuilder.Entity<Waitress>().HasData
            (
                new Waitress
                {
                    Id = "fa628865-0c61-45d4-bfca-5ad269cd22ee",
                    Name = "Pro Consulta",
                    Email = "proconsulta@hotmail.com.br",
                    EmailConfirmed = true,
                    UserName = "proconsulta@hotmail.com.br",
                    NormalizedEmail = "PROCONSULTA@HOTMAIL.COM",
                    NormalizedUserName = "PROCONSULTA@HOTMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
             );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    RoleId = "1a4167cf-a029-4b46-b224-c0d656a2f8bf",
                    UserId = "fa628865-0c61-45d4-bfca-5ad269cd22ee"
                }
            );

            _modelBuilder.Entity<Speciality>().HasData
           (
               new Speciality { Id = 1, Name = "Cardiologia", Description = "Especialidade que cuida do coração" },
               new Speciality { Id = 2, Name = "Neurologia", Description = "Especialidade que trata doenças do sistema nervoso" },
                new Speciality { Id = 3, Name = "Dermatologia", Description = "Especialidade que cuida da pele, cabelos e unhas" },
                new Speciality { Id = 4, Name = "Pediatria", Description = "Especialidade médica dedicada à saúde das crianças" },
                new Speciality { Id = 5, Name = "Ginecologia", Description = "Especialidade que cuida da saúde do sistema reprodutor feminino" },
                new Speciality { Id = 6, Name = "Ortopedia", Description = "Especialidade que trata lesões e deformidades dos ossos e músculos" },
                new Speciality { Id = 7, Name = "Oftalmologia", Description = "Especialidade que cuida da saúde dos olhos" },
                new Speciality { Id = 8, Name = "Psiquiatria", Description = "Especialidade que trata doenças mentais" },
                new Speciality { Id = 9, Name = "Endocrinologia", Description = "Especialidade que trata doenças relacionadas ao sistema endócrino" },
                new Speciality { Id = 10, Name = "Gastroenterologia", Description = "Especialidade que cuida do sistema digestivo" },
                new Speciality { Id = 11, Name = "Nefrologia", Description = "Especialidade que cuida dos rins e do sistema urinário" }

           );
        }
    }
}
