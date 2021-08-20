using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class multiselectnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProposalForApproval_Notesheets_NotesheetId",
                table: "ProposalForApproval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProposalForApproval",
                table: "ProposalForApproval");

            migrationBuilder.RenameTable(
                name: "ProposalForApproval",
                newName: "ProposalForApprovals");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalForApproval_NotesheetId_ProposalOption",
                table: "ProposalForApprovals",
                newName: "IX_ProposalForApprovals_NotesheetId_ProposalOption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProposalForApprovals",
                table: "ProposalForApprovals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalForApprovals_Notesheets_NotesheetId",
                table: "ProposalForApprovals",
                column: "NotesheetId",
                principalTable: "Notesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProposalForApprovals_Notesheets_NotesheetId",
                table: "ProposalForApprovals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProposalForApprovals",
                table: "ProposalForApprovals");

            migrationBuilder.RenameTable(
                name: "ProposalForApprovals",
                newName: "ProposalForApproval");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalForApprovals_NotesheetId_ProposalOption",
                table: "ProposalForApproval",
                newName: "IX_ProposalForApproval_NotesheetId_ProposalOption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProposalForApproval",
                table: "ProposalForApproval",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalForApproval_Notesheets_NotesheetId",
                table: "ProposalForApproval",
                column: "NotesheetId",
                principalTable: "Notesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
