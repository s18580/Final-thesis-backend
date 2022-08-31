using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class ColorAndValuationUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraphicDesignPrice",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "PrintPrice",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "PrintingOnReverse",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "SamplePrintoutsPrice",
                table: "Valuations");

            migrationBuilder.RenameColumn(
                name: "UnitPriceNet",
                table: "Valuations",
                newName: "FinalPrice");

            migrationBuilder.RenameColumn(
                name: "PrintingPlateNuber",
                table: "Valuations",
                newName: "MainCirculation");

            migrationBuilder.RenameColumn(
                name: "Circulation",
                table: "Valuations",
                newName: "InsideSheetNumber");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemIdOrderItem",
                table: "Valuations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OfferValidityDate",
                table: "Valuations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdOrderItem",
                table: "Valuations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Valuations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoverCirculation",
                table: "Valuations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverOther",
                table: "Valuations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CoverPlateNumber",
                table: "Valuations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoverSheetNumber",
                table: "Valuations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsideCirculation",
                table: "Valuations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsideOther",
                table: "Valuations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InsidePlateNumber",
                table: "Valuations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Recipient",
                table: "Valuations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsForCover",
                table: "Colors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverCirculation",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "CoverOther",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "CoverPlateNumber",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "CoverSheetNumber",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "InsideCirculation",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "InsideOther",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "InsidePlateNumber",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "Recipient",
                table: "Valuations");

            migrationBuilder.DropColumn(
                name: "IsForCover",
                table: "Colors");

            migrationBuilder.RenameColumn(
                name: "MainCirculation",
                table: "Valuations",
                newName: "PrintingPlateNuber");

            migrationBuilder.RenameColumn(
                name: "InsideSheetNumber",
                table: "Valuations",
                newName: "Circulation");

            migrationBuilder.RenameColumn(
                name: "FinalPrice",
                table: "Valuations",
                newName: "UnitPriceNet");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemIdOrderItem",
                table: "Valuations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OfferValidityDate",
                table: "Valuations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "IdOrderItem",
                table: "Valuations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Valuations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "GraphicDesignPrice",
                table: "Valuations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrintPrice",
                table: "Valuations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "PrintingOnReverse",
                table: "Valuations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "SamplePrintoutsPrice",
                table: "Valuations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
