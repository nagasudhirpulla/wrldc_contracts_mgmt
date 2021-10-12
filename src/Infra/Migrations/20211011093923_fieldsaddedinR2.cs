using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class fieldsaddedinR2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BPSerialNo",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BPUnderHead",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DopSection",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IndentingDept",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherPointsRelevantWithCase",
                table: "Notesheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProposalForApprovalOthersOption",
                table: "Notesheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProprietaryArticleCertificate",
                table: "Notesheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonsForModeOfTender",
                table: "Notesheets",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BPSerialNo",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "BPUnderHead",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "DopSection",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "IndentingDept",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "OtherPointsRelevantWithCase",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "ProposalForApprovalOthersOption",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "ProprietaryArticleCertificate",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "ReasonsForModeOfTender",
                table: "Notesheets");
        }
    }
}
