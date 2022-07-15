using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductGallary.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_product_id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_product_id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "Cart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_product_id",
                table: "Cart",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_product_id",
                table: "Cart",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
