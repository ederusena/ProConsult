using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Document = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Document = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    CRM = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    TimeConsult = table.Column<TimeSpan>(type: "time", nullable: true),
                    DateConsult = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dockets_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dockets_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a4167cf-a029-4b46-b224-c0d656a2f8bf", null, "Atendente", "ATENDENTE" },
                    { "bf745e70-7397-4e14-bd88-4225b96d6c58", null, "Medico", "MEDICO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa628865-0c61-45d4-bfca-5ad269cd22ee", 0, "bb5f7445-1881-4b99-8ed7-d31fb540a1b2", "Waitress", "proconsulta@hotmail.com.br", true, false, null, "Pro Consulta", "PROCONSULTA@HOTMAIL.COM", "PROCONSULTA@HOTMAIL.COM", "AQAAAAIAAYagAAAAEPgyfr+qT8G06GnbFSNThyszQp00ZTEZ6+OY6dW9WMqMlZ3V7oTabIx7INALPrK0pQ==", null, false, "8ad582ea-37d6-499c-a5e3-ff0b7dd94ec5", false, "proconsulta@hotmail.com.br" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Especialidade que cuida do coração", "Cardiologia" },
                    { 2, "Especialidade que trata doenças do sistema nervoso", "Neurologia" },
                    { 3, "Especialidade que cuida da pele, cabelos e unhas", "Dermatologia" },
                    { 4, "Especialidade médica dedicada à saúde das crianças", "Pediatria" },
                    { 5, "Especialidade que cuida da saúde do sistema reprodutor feminino", "Ginecologia" },
                    { 6, "Especialidade que trata lesões e deformidades dos ossos e músculos", "Ortopedia" },
                    { 7, "Especialidade que cuida da saúde dos olhos", "Oftalmologia" },
                    { 8, "Especialidade que trata doenças mentais", "Psiquiatria" },
                    { 9, "Especialidade que trata doenças relacionadas ao sistema endócrino", "Endocrinologia" },
                    { 10, "Especialidade que cuida do sistema digestivo", "Gastroenterologia" },
                    { 11, "Especialidade que cuida dos rins e do sistema urinário", "Nefrologia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1a4167cf-a029-4b46-b224-c0d656a2f8bf", "fa628865-0c61-45d4-bfca-5ad269cd22ee" });

            migrationBuilder.CreateIndex(
                name: "IX_Dockets_DoctorId",
                table: "Dockets",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dockets_PatientId",
                table: "Dockets",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CRM",
                table: "Doctors",
                column: "CRM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Document",
                table: "Doctors",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityId",
                table: "Doctors",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Document",
                table: "Patients",
                column: "Document",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dockets");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf745e70-7397-4e14-bd88-4225b96d6c58");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a4167cf-a029-4b46-b224-c0d656a2f8bf", "fa628865-0c61-45d4-bfca-5ad269cd22ee" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a4167cf-a029-4b46-b224-c0d656a2f8bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa628865-0c61-45d4-bfca-5ad269cd22ee");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
