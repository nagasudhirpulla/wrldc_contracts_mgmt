using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class updated_local : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notesheet",
                table: "Notesheet");

            migrationBuilder.RenameTable(
                name: "Notesheet",
                newName: "Notesheets");

            migrationBuilder.RenameIndex(
                name: "IX_Notesheet_ReferenceNo",
                table: "Notesheets",
                newName: "IX_Notesheets_ReferenceNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notesheets",
                table: "Notesheets",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notesheets",
                table: "Notesheets");

            migrationBuilder.RenameTable(
                name: "Notesheets",
                newName: "Notesheet");

            migrationBuilder.RenameIndex(
                name: "IX_Notesheets_ReferenceNo",
                table: "Notesheet",
                newName: "IX_Notesheet_ReferenceNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notesheet",
                table: "Notesheet",
                column: "Id");
        }
    }
}
