using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegocioInversiones.Migrations
{
    /// <inheritdoc />
    public partial class generalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GeneralRequestId",
                table: "LoanRequest",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralRequestId",
                table: "LoanRequest");
        }
    }
}
