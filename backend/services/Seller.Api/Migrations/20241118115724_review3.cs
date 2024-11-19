using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seller.Api.Migrations
{
    /// <inheritdoc />
    public partial class review3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "shops");

            migrationBuilder.DropColumn(
                name: "cumulativeSum",
                table: "shops");

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "cumulativeSum",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "products");

            migrationBuilder.DropColumn(
                name: "cumulativeSum",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "cumulativeSum",
                table: "shops",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
