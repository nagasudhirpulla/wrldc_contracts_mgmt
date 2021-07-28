using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class departAcronym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Acronym",
                table: "Departments",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Acronym",
                table: "Departments",
                column: "Acronym",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_Acronym",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Acronym",
                table: "Departments");
        }
    }
}
