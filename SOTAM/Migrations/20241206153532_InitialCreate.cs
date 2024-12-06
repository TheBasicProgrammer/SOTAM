using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOTAM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__719FE4E89C6F93B4", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: true),
                    TimeEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeLeft = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tables__7D5F018E1E0BEF02", x => x.TableID);
                });

            migrationBuilder.CreateTable(
                name: "QueueList",
                columns: table => new
                {
                    QueueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QueueLis__8324E8F5BAE102C6", x => x.QueueID);
                    table.ForeignKey(
                        name: "FK__QueueList__Table__3F466844",
                        column: x => x.TableID,
                        principalTable: "Tables",
                        principalColumn: "TableID");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    TableID = table.Column<int>(type: "int", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__55433A4B5E7801C6", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK__Transacti__Table__4316F928",
                        column: x => x.TableID,
                        principalTable: "Tables",
                        principalColumn: "TableID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Admin__536C85E434607868",
                table: "Admin",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QueueList_TableID",
                table: "QueueList",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TableID",
                table: "Transactions",
                column: "TableID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "QueueList");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
