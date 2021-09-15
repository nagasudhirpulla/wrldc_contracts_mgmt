using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class DopClause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DopClause",
                table: "Notesheets",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DopClause",
                table: "Notesheets");
        }
    }
}
