using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticlProject.Data.Migrations
{
    public partial class AddAurhorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    PostCategory = table.Column<string>(nullable: false),
                    PostTitle = table.Column<string>(nullable: false),
                    PostDescription = table.Column<string>(nullable: false),
                    PostImageUrl = table.Column<string>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorPost_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPost_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPost_AuthorId",
                table: "AuthorPost",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPost_CategoryId",
                table: "AuthorPost",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPost");
        }
    }
}
