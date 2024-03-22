// Migrations/20220310000000_InitialCreate.cs

using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlInjectionExample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            // Seed data
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password" },
                values: new object[,]
                {
                    { "admin", "adminpassword" },
                    { "user", "userpassword" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
