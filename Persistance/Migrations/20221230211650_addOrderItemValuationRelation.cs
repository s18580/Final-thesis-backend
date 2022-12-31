using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class addOrderItemValuationRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Valuations_OrderItems_OrderItemIdOrderItem",
                table: "Valuations");

            migrationBuilder.DropIndex(
                name: "IX_Valuations_OrderItemIdOrderItem",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "OrderItemIdOrderItem",
                table: "Valuations");

            migrationBuilder.CreateIndex(
                name: "IX_Valuations_IdOrderItem",
                table: "Valuations",
                column: "IdOrderItem");

            migrationBuilder.AddForeignKey(
                name: "FK_Valuations_OrderItems_IdOrderItem",
                table: "Valuations",
                column: "IdOrderItem",
                principalTable: "OrderItems",
                principalColumn: "IdOrderItem",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Valuations_OrderItems_IdOrderItem",
                table: "Valuations");

            migrationBuilder.DropIndex(
                name: "IX_Valuations_IdOrderItem",
                table: "Valuations");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemIdOrderItem",
                table: "Valuations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Valuations_OrderItemIdOrderItem",
                table: "Valuations",
                column: "OrderItemIdOrderItem");

            migrationBuilder.AddForeignKey(
                name: "FK_Valuations_OrderItems_OrderItemIdOrderItem",
                table: "Valuations",
                column: "OrderItemIdOrderItem",
                principalTable: "OrderItems",
                principalColumn: "IdOrderItem",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
