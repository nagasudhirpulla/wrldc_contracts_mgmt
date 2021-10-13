using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class notesheet_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposalForApprovalOthersOption",
                table: "Notesheets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProposalForApprovalOthersOption",
                table: "Notesheets",
                type: "text",
                nullable: true);
        }
    }
}
