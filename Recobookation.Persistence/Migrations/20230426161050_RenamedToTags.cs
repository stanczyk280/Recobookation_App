using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recobookation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamedToTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTags");

            migrationBuilder.CreateTable(
                name: "TagList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagList_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagList_BookId",
                table: "TagList",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagList");

            migrationBuilder.CreateTable(
                name: "BookTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_BookId",
                table: "BookTags",
                column: "BookId");
        }
    }
}
