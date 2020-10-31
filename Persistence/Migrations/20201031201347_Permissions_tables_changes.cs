using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Permissions_tables_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "SystemPages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SystemEntityStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemEntityStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemPages_ParentId",
                table: "SystemPages",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemPages_SystemPages_ParentId",
                table: "SystemPages",
                column: "ParentId",
                principalTable: "SystemPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemPages_SystemPages_ParentId",
                table: "SystemPages");

            migrationBuilder.DropTable(
                name: "SystemEntityStatuses");

            migrationBuilder.DropIndex(
                name: "IX_SystemPages_ParentId",
                table: "SystemPages");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "SystemPages");
        }
    }
}
