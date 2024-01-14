using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class cartupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiningTableId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_DiningTableId",
                table: "ShoppingCarts",
                column: "DiningTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_DiningTables_DiningTableId",
                table: "ShoppingCarts",
                column: "DiningTableId",
                principalTable: "DiningTables",
                principalColumn: "DiningTableId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_DiningTables_DiningTableId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_DiningTableId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "DiningTableId",
                table: "ShoppingCarts");
        }
    }
}
