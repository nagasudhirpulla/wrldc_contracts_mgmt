using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class budgetaryOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BudgetOfferAddress",
                table: "Notesheets",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BudgetOfferDate",
                table: "Notesheets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 9, 2021, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BudgetOfferReference",
                table: "Notesheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BudgetOfferValidity",
                table: "Notesheets",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetOfferAddress",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "BudgetOfferDate",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "BudgetOfferReference",
                table: "Notesheets");

            migrationBuilder.DropColumn(
                name: "BudgetOfferValidity",
                table: "Notesheets");
        }
    }
}
