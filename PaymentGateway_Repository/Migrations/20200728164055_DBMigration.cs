using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGateway_Repository.Migrations
{
    public partial class DBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    CardNumber = table.Column<string>(maxLength: 16, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CVV = table.Column<string>(maxLength: 3, nullable: false),
                    AmountRemaining = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => new { x.Name, x.CardNumber, x.ExpiryDate, x.CVV });
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(nullable: false),
                    CardNumber = table.Column<string>(maxLength: 16, nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CVV = table.Column<string>(maxLength: 3, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentSuccessful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Bank_Name_CardNumber_ExpiryDate_CVV",
                        columns: x => new { x.Name, x.CardNumber, x.ExpiryDate, x.CVV },
                        principalTable: "Bank",
                        principalColumns: new[] { "Name", "CardNumber", "ExpiryDate", "CVV" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Name_CardNumber_ExpiryDate_CVV",
                table: "Payment",
                columns: new[] { "Name", "CardNumber", "ExpiryDate", "CVV" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
