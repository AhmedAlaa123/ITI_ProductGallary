using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductGallary.Migrations
{
    public partial class o : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProductLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartProductLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cart_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProductLists_Cart_cart_id",
                        column: x => x.cart_id,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProductLists_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductLists_cart_id",
                table: "CartProductLists",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductLists_product_id",
                table: "CartProductLists",
                column: "product_id");
        }
    }
}
