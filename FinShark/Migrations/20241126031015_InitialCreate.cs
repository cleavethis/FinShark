using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinShark.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    stockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.stockId);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stockId = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comment_Stock_stockId",
                        column: x => x.stockId,
                        principalTable: "Stock",
                        principalColumn: "stockId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_stockId",
                table: "Comment",
                column: "stockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
