using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Migrations
{
    public partial class multiselect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposalForApproval",
                table: "Notesheets");

            migrationBuilder.CreateTable(
                name: "ProposalForApproval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotesheetId = table.Column<int>(type: "integer", nullable: false),
                    ProposalOption = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalForApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposalForApproval_Notesheets_NotesheetId",
                        column: x => x.NotesheetId,
                        principalTable: "Notesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProposalForApproval_NotesheetId_ProposalOption",
                table: "ProposalForApproval",
                columns: new[] { "NotesheetId", "ProposalOption" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProposalForApproval");

            migrationBuilder.AddColumn<string>(
                name: "ProposalForApproval",
                table: "Notesheets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
