using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderBook.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Portfolio_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Portfolio_Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Stock_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abreviation = table.Column<string>(type: "Varchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Stock_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "Varchar(32)", nullable: false),
                    Balance = table.Column<decimal>(type: "Decimal(6,2)", nullable: false),
                    Password = table.Column<byte[]>(type: "Binary(64)", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Users_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Portfolio_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionModel",
                columns: table => new
                {
                    Position_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    PortfolioModelPortfolioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionModel", x => x.Position_Id);
                    table.ForeignKey(
                        name: "FK_PositionModel_Portfolios_PortfolioModelPortfolioId",
                        column: x => x.PortfolioModelPortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Portfolio_Id");
                    table.ForeignKey(
                        name: "FK_PositionModel_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Stock_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Buy_Order = table.Column<bool>(type: "BIT", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IssuerUserId = table.Column<int>(type: "int", nullable: false),
                    UnderlyingStockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Orders_Stocks_UnderlyingStockId",
                        column: x => x.UnderlyingStockId,
                        principalTable: "Stocks",
                        principalColumn: "Stock_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_IssuerUserId",
                        column: x => x.IssuerUserId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Sale_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Execution_Time = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UnderlyingStockId = table.Column<int>(type: "int", nullable: false),
                    BuyerUserId = table.Column<int>(type: "int", nullable: false),
                    SellerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Sale_Id);
                    table.ForeignKey(
                        name: "FK_Sales_Stocks_UnderlyingStockId",
                        column: x => x.UnderlyingStockId,
                        principalTable: "Stocks",
                        principalColumn: "Stock_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_BuyerUserId",
                        column: x => x.BuyerUserId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Sales_Users_SellerUserId",
                        column: x => x.SellerUserId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IssuerUserId",
                table: "Orders",
                column: "IssuerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UnderlyingStockId",
                table: "Orders",
                column: "UnderlyingStockId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionModel_PortfolioModelPortfolioId",
                table: "PositionModel",
                column: "PortfolioModelPortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionModel_StockId",
                table: "PositionModel",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerUserId",
                table: "Sales",
                column: "BuyerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SellerUserId",
                table: "Sales",
                column: "SellerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UnderlyingStockId",
                table: "Sales",
                column: "UnderlyingStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PortfolioId",
                table: "Users",
                column: "PortfolioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PositionModel");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
