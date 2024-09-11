using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageLogistic.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsRemade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductHistory",
                table: "ProductHistory");

            migrationBuilder.RenameTable(
                name: "ProductHistory",
                newName: "ProductHistories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductHistory_ProductId",
                table: "ProductHistories",
                newName: "IX_ProductHistories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductHistories",
                table: "ProductHistories",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistories_Products_ProductId",
                table: "ProductHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistories_Products_ProductId",
                table: "ProductHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductHistories",
                table: "ProductHistories");

            migrationBuilder.RenameTable(
                name: "ProductHistories",
                newName: "ProductHistory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductHistories_ProductId",
                table: "ProductHistory",
                newName: "IX_ProductHistory_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductHistory",
                table: "ProductHistory",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
