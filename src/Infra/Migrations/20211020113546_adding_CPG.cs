using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class adding_CPG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPG",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPG",
                table: "Notesheets");
        }
    }
}
