using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegocioInversiones.Migrations
{
    /// <inheritdoc />
    public partial class loan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer_product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_type_id = table.Column<int>(type: "int", nullable: false),
                    product_customer_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_product", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanStatusId = table.Column<int>(type: "int", nullable: false),
                    LoanTypeId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryCustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CoSignerId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CapitalBalance = table.Column<double>(type: "float", nullable: false),
                    InterestBalance = table.Column<double>(type: "float", nullable: false),
                    CancellationAmount = table.Column<double>(type: "float", nullable: false),
                    MontoCuota = table.Column<double>(type: "float", nullable: false),
                    MontoMora = table.Column<double>(type: "float", nullable: false),
                    Interest = table.Column<double>(type: "float", nullable: false),
                    WithdrawalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TasaFijaEnMeses = table.Column<int>(type: "int", nullable: false),
                    GuaranteeTypeId = table.Column<int>(type: "int", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsInLegal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_product");

            migrationBuilder.DropTable(
                name: "loan");
        }
    }
}
