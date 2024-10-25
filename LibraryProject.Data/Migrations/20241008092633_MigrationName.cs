using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_UserId1",
                table: "Borrows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_UserId1",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_BorrowId",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Borrows");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Libraries",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Libraries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Libraries",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Borrows",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BorrowId",
                table: "Borrows",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "BorrowId",
                table: "BorrowBooks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "BorrowId1",
                table: "BorrowBooks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BorrowBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AmountPages",
                table: "Books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries",
                column: "LibraryId");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullNameofAuthor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LibraryId",
                table: "Users",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_UserId",
                table: "Borrows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BorrowId",
                table: "BorrowBooks",
                column: "BorrowId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BorrowId1",
                table: "BorrowBooks",
                column: "BorrowId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_UserId",
                table: "BorrowBooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "LibraryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Borrows_BorrowId1",
                table: "BorrowBooks",
                column: "BorrowId1",
                principalTable: "Borrows",
                principalColumn: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Users_UserId",
                table: "BorrowBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_UserId",
                table: "Borrows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Libraries_LibraryId",
                table: "Users",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "LibraryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Borrows_BorrowId1",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Users_UserId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_UserId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Libraries_LibraryId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Users_LibraryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_UserId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_BorrowId",
                table: "BorrowBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_BorrowId1",
                table: "BorrowBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_UserId",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "BorrowId1",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BorrowBooks");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Libraries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Libraries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Borrows",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BorrowId",
                table: "Borrows",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Borrows",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BorrowId",
                table: "BorrowBooks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "AmountPages",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_UserId1",
                table: "Borrows",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BorrowId",
                table: "BorrowBooks",
                column: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_UserId1",
                table: "Borrows",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
