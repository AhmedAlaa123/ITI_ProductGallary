using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductGallary.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_CartProductLists_CardProductListId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_CartProductLists_CardProductListId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CardProductListId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Cart_CardProductListId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CardProductListId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CardProductListId",
                table: "Cart");

            migrationBuilder.AddColumn<Guid>(
                name: "cart_id",
                table: "CartProductLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                table: "CartProductLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartProductLists_cart_id",
                table: "CartProductLists",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductLists_product_id",
                table: "CartProductLists",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductLists_Cart_cart_id",
                table: "CartProductLists",
                column: "cart_id",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductLists_Product_product_id",
                table: "CartProductLists",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProductLists_Cart_cart_id",
                table: "CartProductLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProductLists_Product_product_id",
                table: "CartProductLists");

            migrationBuilder.DropIndex(
                name: "IX_CartProductLists_cart_id",
                table: "CartProductLists");

            migrationBuilder.DropIndex(
                name: "IX_CartProductLists_product_id",
                table: "CartProductLists");

            migrationBuilder.DropColumn(
                name: "cart_id",
                table: "CartProductLists");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "CartProductLists");

            migrationBuilder.AddColumn<Guid>(
                name: "CardProductListId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CardProductListId",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CardProductListId",
                table: "Product",
                column: "CardProductListId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CardProductListId",
                table: "Cart",
                column: "CardProductListId");

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
    }
}
