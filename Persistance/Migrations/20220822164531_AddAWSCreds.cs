using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddAWSCreds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderSubmissionDate",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "AccessKeyAWS",
                table: "Workers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecretKeyAWS",
                table: "Workers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemIdOrderItem",
                table: "Valuations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessKeyAWS",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "SecretKeyAWS",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemIdOrderItem",
                table: "Valuations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderSubmissionDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }
    }
}
