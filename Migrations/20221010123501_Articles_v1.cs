using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Virtualizebug.Migrations
{
    /// <inheritdoc />
    public partial class Articlesv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Stand");

            migrationBuilder.CreateTable(
                name: "Articles.Article",
                schema: "Stand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles.Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles.Details",
                schema: "Stand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles.Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles.Details_Articles.Article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "Stand",
                        principalTable: "Articles.Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles.Details_ArticleId",
                schema: "Stand",
                table: "Articles.Details",
                column: "ArticleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles.Details",
                schema: "Stand");

            migrationBuilder.DropTable(
                name: "Articles.Article",
                schema: "Stand");
        }
    }
}
