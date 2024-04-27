using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MondialMunch.Migrations
{
    /// <inheritdoc />
    public partial class _0cdbe40a555c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietaryTag_Recipes_RecipeId",
                table: "DietaryTag");

            migrationBuilder.DropIndex(
                name: "IX_DietaryTag_RecipeId",
                table: "DietaryTag");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "DietaryTag");

            migrationBuilder.CreateTable(
                name: "DietaryTagRecipe",
                columns: table => new
                {
                    TaggedRecipesId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TagsId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryTagRecipe", x => new { x.TaggedRecipesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_DietaryTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "DietaryTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_Recipes_TaggedRecipesId",
                        column: x => x.TaggedRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTagRecipe_TagsId",
                table: "DietaryTagRecipe",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietaryTagRecipe");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "DietaryTag",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTag_RecipeId",
                table: "DietaryTag",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietaryTag_Recipes_RecipeId",
                table: "DietaryTag",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
