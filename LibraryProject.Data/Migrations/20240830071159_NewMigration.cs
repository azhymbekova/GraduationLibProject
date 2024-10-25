using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Borrows_BorrowId1",
                table: "BorrowBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_BorrowId1",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "BorrowId1",
                table: "BorrowBooks");

            migrationBuilder.AlterColumn<long>(
                name: "BorrowId",
                table: "BorrowBooks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "BorrowBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BorrowId",
                table: "BorrowBooks",
                column: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Borrows_BorrowId",
                table: "BorrowBooks",
                column: "BorrowId",
                principalTable: "Borrows",
                principalColumn: "BorrowId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Borrows_BorrowId",
                table: "BorrowBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_BorrowId",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BorrowBooks");

            migrationBuilder.AlterColumn<int>(
                name: "BorrowId",
                table: "BorrowBooks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "BorrowId1",
                table: "BorrowBooks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BorrowId1",
                table: "BorrowBooks",
                column: "BorrowId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Borrows_BorrowId1",
                table: "BorrowBooks",
                column: "BorrowId1",
                principalTable: "Borrows",
                principalColumn: "BorrowId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
