using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegocioInversiones.Migrations
{
    /// <inheritdoc />
    public partial class loa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WithdrawalDate",
                table: "loan");

            migrationBuilder.RenameColumn(
                name: "TasaFijaEnMeses",
                table: "loan",
                newName: "PlazoEnMeses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "loan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CoSignerId",
                table: "loan",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiaryCustomerId",
                table: "loan",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<bool>(
                name: "IsWithdrawn",
                table: "loan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MesesTasaFija",
                table: "loan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextPaymentDate",
                table: "loan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "loan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "product_customer_id",
                table: "customer_product",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWithdrawn",
                table: "loan");

            migrationBuilder.DropColumn(
                name: "MesesTasaFija",
                table: "loan");

            migrationBuilder.DropColumn(
                name: "NextPaymentDate",
                table: "loan");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "loan");

            migrationBuilder.RenameColumn(
                name: "PlazoEnMeses",
                table: "loan",
                newName: "TasaFijaEnMeses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "loan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CoSignerId",
                table: "loan",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BeneficiaryCustomerId",
                table: "loan",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "WithdrawalDate",
                table: "loan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "product_customer_id",
                table: "customer_product",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
