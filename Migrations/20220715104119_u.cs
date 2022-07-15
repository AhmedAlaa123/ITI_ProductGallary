using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductGallary.Migrations
{
    public partial class u : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CartProductList_OrderProductListId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "OrderProductListId",
                table: "Product",
                newName: "ProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_OrderProductListId",
                table: "Product",
                newName: "IX_Product_ProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CartProductList_ProductListId",
                table: "Product",
                column: "ProductListId",
                principalTable: "CartProductList",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CartProductList_ProductListId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductListId",
                table: "Product",
                newName: "OrderProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductListId",
                table: "Product",
                newName: "IX_Product_OrderProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CartProductList_OrderProductListId",
                table: "Product",
                column: "OrderProductListId",
                principalTable: "CartProductList",
                principalColumn: "Id");
        }
    }
}
