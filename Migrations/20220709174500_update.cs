using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductGallary.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_User_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Gallary_Gallary_Id",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "Category_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_Category_Id");

            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Gallary_Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_User_Id",
                table: "Product",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_Category_Id",
                table: "Product",
                column: "Category_Id",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Gallary_Gallary_Id",
                table: "Product",
                column: "Gallary_Id",
                principalTable: "Gallary",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_User_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_Category_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Gallary_Gallary_Id",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Category_Id",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Gallary_Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_User_Id",
                table: "Product",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Gallary_Gallary_Id",
                table: "Product",
                column: "Gallary_Id",
                principalTable: "Gallary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
