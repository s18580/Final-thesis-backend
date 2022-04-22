using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class ServiceNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceNames_MinimumRates_IdMinimumRate",
                table: "ServiceNames");

            migrationBuilder.DropTable(
                name: "MinimumRates");

            migrationBuilder.DropIndex(
                name: "IX_ServiceNames_IdMinimumRate",
                table: "ServiceNames");

            migrationBuilder.RenameColumn(
                name: "IdMinimumRate",
                table: "ServiceNames",
                newName: "MinimumCirculation");

            migrationBuilder.AddColumn<double>(
                name: "MinimumPrice",
                table: "ServiceNames",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumPrice",
                table: "ServiceNames");

            migrationBuilder.RenameColumn(
                name: "MinimumCirculation",
                table: "ServiceNames",
                newName: "IdMinimumRate");

            migrationBuilder.CreateTable(
                name: "MinimumRates",
                columns: table => new
                {
                    IdMinimumRate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Circulation = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinimumRates", x => x.IdMinimumRate);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceNames_IdMinimumRate",
                table: "ServiceNames",
                column: "IdMinimumRate");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceNames_MinimumRates_IdMinimumRate",
                table: "ServiceNames",
                column: "IdMinimumRate",
                principalTable: "MinimumRates",
                principalColumn: "IdMinimumRate",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
