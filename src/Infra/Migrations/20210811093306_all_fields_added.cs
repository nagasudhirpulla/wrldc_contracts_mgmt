using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class all_fields_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovingAuthority",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillOfQuantity",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BudgetProvision",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "EstimatedCost",
                table: "Notesheets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "GeMNonAvailabilityCertificate",
                table: "Notesheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guarantee_Warranty",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ListOfParties",
                table: "Notesheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModeOfTerm",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Payment_Terms_CPG",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProposalForApproval",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialConditionsOfContract",
                table: "Notesheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfBidding",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkCompletionSchedule",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovingAuthority",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "BillOfQuantity",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "BudgetProvision",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "EstimatedCost",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "GeMNonAvailabilityCertificate",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "Guarantee_Warranty",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "ListOfParties",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "ModeOfTerm",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "Payment_Terms_CPG",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "ProposalForApproval",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "SpecialConditionsOfContract",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "TypeOfBidding",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "WorkCompletionSchedule",
                table: "Notesheets");
        }
    }
}
