using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_S_Reality.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBuyerSellerAndProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BuyerSellers_BuyerSellerID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BuyerSellers_BuyerSellerID1",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_BuyerSellerID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "BuyerSellerID",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "BuyerSellerID1",
                table: "Properties",
                newName: "BuyerID");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_BuyerSellerID1",
                table: "Properties",
                newName: "IX_Properties_BuyerID");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CrimeRate",
                table: "Neighborhoods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PreferredContactMethod",
                table: "BuyerSellers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegistered",
                table: "BuyerSellers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SellerID",
                table: "Properties",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BuyerSellers_BuyerID",
                table: "Properties",
                column: "BuyerID",
                principalTable: "BuyerSellers",
                principalColumn: "BuyerSellerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BuyerSellers_SellerID",
                table: "Properties",
                column: "SellerID",
                principalTable: "BuyerSellers",
                principalColumn: "BuyerSellerID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BuyerSellers_BuyerID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BuyerSellers_SellerID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_SellerID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "BuyerID",
                table: "Properties",
                newName: "BuyerSellerID1");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_BuyerID",
                table: "Properties",
                newName: "IX_Properties_BuyerSellerID1");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerSellerID",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CrimeRate",
                table: "Neighborhoods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreferredContactMethod",
                table: "BuyerSellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegistered",
                table: "BuyerSellers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BuyerSellerID",
                table: "Properties",
                column: "BuyerSellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BuyerSellers_BuyerSellerID",
                table: "Properties",
                column: "BuyerSellerID",
                principalTable: "BuyerSellers",
                principalColumn: "BuyerSellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BuyerSellers_BuyerSellerID1",
                table: "Properties",
                column: "BuyerSellerID1",
                principalTable: "BuyerSellers",
                principalColumn: "BuyerSellerID");
        }
    }
}
