using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Turnover = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CEO = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    BoardOfDirectors = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ListedInSE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Sector = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Brief = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    StockCode = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Company__9BCE05DDFA6D4768", x => x.CompanyName);
                });

            migrationBuilder.CreateTable(
                name: "IPO",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    StockExchange = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    PricePerShare = table.Column<int>(nullable: false),
                    NoOfShares = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    OpenDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remarks = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    SectorName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Brief = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StockExchange",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockExchangeName = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Brief = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ContactAddress = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchange", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StockPrice",
                columns: table => new
                {
                    stockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    StockExchange = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StockPri__CBAD8763CB9697DF", x => x.stockId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserType = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
                    MobileNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Confirmed = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "IPO");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "StockExchange");

            migrationBuilder.DropTable(
                name: "StockPrice");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
