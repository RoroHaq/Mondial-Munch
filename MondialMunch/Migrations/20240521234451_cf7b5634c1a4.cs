using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MondialMunch.Migrations
{
    /// <inheritdoc />
    public partial class cf7b5634c1a4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletedRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeCompletedId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserCompletingId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedRecipe_Recipes_RecipeCompletedId",
                        column: x => x.RecipeCompletedId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedRecipe_Users_UserCompletingId",
                        column: x => x.UserCompletingId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRecipe_RecipeCompletedId",
                table: "CompletedRecipe",
                column: "RecipeCompletedId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRecipe_UserCompletingId",
                table: "CompletedRecipe",
                column: "UserCompletingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedRecipe");
        }
    }
}
