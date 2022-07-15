using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductGallary.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_CartProductList_ProductListId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_CartProductList_ProductListId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CartProductList");

            migrationBuilder.RenameColumn(
                name: "ProductListId",
                table: "Product",
                newName: "CardProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductListId",
                table: "Product",
                newName: "IX_Product_CardProductListId");

            migrationBuilder.RenameColumn(
                name: "ProductListId",
                table: "Cart",
                newName: "CardProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ProductListId",
                table: "Cart",
                newName: "IX_Cart_CardProductListId");

            migrationBuilder.CreateTable(
                name: "CartProductLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductLists", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_CartProductLists_CardProductListId",
                table: "Cart",
                column: "CardProductListId",
                principalTable: "CartProductLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CartProductLists_CardProductListId",
                table: "Product",
                column: "CardProductListId",
                principalTable: "CartProductLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_CartProductLists_CardProductListId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_CartProductLists_CardProductListId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CartProductLists");

            migrationBuilder.RenameColumn(
                name: "CardProductListId",
                table: "Product",
                newName: "ProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CardProductListId",
                table: "Product",
                newName: "IX_Product_ProductListId");

            migrationBuilder.RenameColumn(
                name: "CardProductListId",
                table: "Cart",
                newName: "ProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_CardProductListId",
                table: "Cart",
                newName: "IX_Cart_ProductListId");

            migrationBuilder.CreateTable(
                name: "CartProductList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductList", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_CartProductList_ProductListId",
                table: "Cart",
                column: "ProductListId",
                principalTable: "CartProductList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CartProductList_ProductListId",
                table: "Product",
                column: "ProductListId",
                principalTable: "CartProductList",
                principalColumn: "Id");
        }
    }
}
