using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seller.Api.Migrations
{
    /// <inheritdoc />
    public partial class review1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "reviews",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "shopName",
                table: "reviews",
                newName: "shopid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userid",
                table: "reviews",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "shopid",
                table: "reviews",
                newName: "shopName");
        }
    }
}
