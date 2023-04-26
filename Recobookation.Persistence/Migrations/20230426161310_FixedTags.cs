using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recobookation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagList");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BookId",
                table: "Tag",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.CreateTable(
                name: "TagList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
