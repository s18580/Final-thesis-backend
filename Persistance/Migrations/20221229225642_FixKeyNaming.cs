using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class FixKeyNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValuationPriceLists_Valuations_IdPriceList",
                table: "ValuationPriceLists");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationPriceLists_Valuations_IdValuation",
                table: "ValuationPriceLists",
                column: "IdValuation",
                principalTable: "Valuations",
                principalColumn: "IdValuation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValuationPriceLists_Valuations_IdValuation",
                table: "ValuationPriceLists");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationPriceLists_Valuations_IdPriceList",
                table: "ValuationPriceLists",
                column: "IdPriceList",
                principalTable: "Valuations",
                principalColumn: "IdValuation");
        }
    }
}
