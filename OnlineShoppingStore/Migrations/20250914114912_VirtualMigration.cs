using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingStore.Migrations
{
    /// <inheritdoc />
    public partial class VirtualMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discount_Admin_AdminId",
                table: "Discount");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Admin_AdminId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AdminId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Discount_AdminId",
                table: "Discount");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Discount");

            migrationBuilder.CreateTable(
                name: "AdminDiscount",
                columns: table => new
                {
                    AdminsAdminId = table.Column<int>(type: "int", nullable: false),
                    DiscountsDiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDiscount", x => new { x.AdminsAdminId, x.DiscountsDiscountId });
                    table.ForeignKey(
                        name: "FK_AdminDiscount_Admin_AdminsAdminId",
                        column: x => x.AdminsAdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdminDiscount_Discount_DiscountsDiscountId",
                        column: x => x.DiscountsDiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdminProduct",
                columns: table => new
                {
                    AdminsAdminId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProduct", x => new { x.AdminsAdminId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_AdminProduct_Admin_AdminsAdminId",
                        column: x => x.AdminsAdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdminProduct_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProduct",
                columns: table => new
                {
                    DiscountsDiscountId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProduct", x => new { x.DiscountsDiscountId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Discount_DiscountsDiscountId",
                        column: x => x.DiscountsDiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrderId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminDiscount_DiscountsDiscountId",
                table: "AdminDiscount",
                column: "DiscountsDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminProduct_ProductsProductId",
                table: "AdminProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProduct_ProductsProductId",
                table: "DiscountProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProductId",
                table: "OrderProduct",
                column: "ProductsProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDiscount");

            migrationBuilder.DropTable(
                name: "AdminProduct");

            migrationBuilder.DropTable(
                name: "DiscountProduct");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Discount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_AdminId",
                table: "Product",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AdminId",
                table: "Discount",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discount_Admin_AdminId",
                table: "Discount",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Admin_AdminId",
                table: "Product",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId");
        }
    }
}
