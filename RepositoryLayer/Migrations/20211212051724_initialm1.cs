using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class initialm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "EnrollDate", "FirstName", "LastName", "ModifiedAt" },
                values: new object[] { 1L, new DateTime(2021, 12, 12, 10, 47, 22, 437, DateTimeKind.Local).AddTicks(3495), "Shiv@gmail.com", new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shiv", "Aanand", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "EnrollDate", "FirstName", "LastName", "ModifiedAt" },
                values: new object[] { 2L, new DateTime(2021, 12, 12, 10, 47, 22, 444, DateTimeKind.Local).AddTicks(4447), "Latika@gmail.com", new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latika", "Aanand", null });

            migrationBuilder.CreateIndex(
                name: "IX_Students_EmailAddress",
                table: "Students",
                column: "EmailAddress",
                unique: true,
                filter: "[EmailAddress] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
