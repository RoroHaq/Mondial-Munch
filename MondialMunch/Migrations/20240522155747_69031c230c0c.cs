using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MondialMunch.Migrations
{
    /// <inheritdoc />
    public partial class _69031c230c0c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietaryTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tag = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MondialMunchEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ShortTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MondialMunchEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CountryOriginId = table.Column<int>(type: "INTEGER", nullable: false),
                    CountryCurrentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Password = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Salt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryCurrentId",
                        column: x => x.CountryCurrentId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryOriginId",
                        column: x => x.CountryOriginId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryMondialMunchEvent",
                columns: table => new
                {
                    EventCountriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMondialMunchEvent", x => new { x.EventCountriesId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_CountryMondialMunchEvent_Countries_EventCountriesId",
                        column: x => x.EventCountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMondialMunchEvent_MondialMunchEvents_EventsId",
                        column: x => x.EventsId,
                        principalTable: "MondialMunchEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatorId = table.Column<int>(type: "INTEGER", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Servings = table.Column<int>(type: "INTEGER", nullable: false),
                    PrepTime = table.Column<double>(type: "REAL", nullable: false),
                    CookingTime = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "DietaryTagRecipe",
                columns: table => new
                {
                    TaggedRecipesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryTagRecipe", x => new { x.TaggedRecipesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_DietaryTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "DietaryTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_Recipes_TaggedRecipesId",
                        column: x => x.TaggedRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeInstruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeInstruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeInstruction_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Stars = table.Column<int>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeReview_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeReview_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeUser",
                columns: table => new
                {
                    FavouriteRecipiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    FavouriteUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser", x => new { x.FavouriteRecipiesId, x.FavouriteUsersId });
                    table.ForeignKey(
                        name: "FK_RecipeUser_Recipes_FavouriteRecipiesId",
                        column: x => x.FavouriteRecipiesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUser_Users_FavouriteUsersId",
                        column: x => x.FavouriteUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeUser1",
                columns: table => new
                {
                    TodoRecipiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TodoUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser1", x => new { x.TodoRecipiesId, x.TodoUsersId });
                    table.ForeignKey(
                        name: "FK_RecipeUser1_Recipes_TodoRecipiesId",
                        column: x => x.TodoRecipiesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUser1_Users_TodoUsersId",
                        column: x => x.TodoUsersId,
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

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryMondialMunchEvent_EventsId",
                table: "CountryMondialMunchEvent",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTagRecipe_TagsId",
                table: "DietaryTagRecipe",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInstruction_RecipeId",
                table: "RecipeInstruction",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReview_RecipeId",
                table: "RecipeReview",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReview_UserId",
                table: "RecipeReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CountryId",
                table: "Recipes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUser_FavouriteUsersId",
                table: "RecipeUser",
                column: "FavouriteUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUser1_TodoUsersId",
                table: "RecipeUser1",
                column: "TodoUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryCurrentId",
                table: "Users",
                column: "CountryCurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryOriginId",
                table: "Users",
                column: "CountryOriginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedRecipe");

            migrationBuilder.DropTable(
                name: "CountryMondialMunchEvent");

            migrationBuilder.DropTable(
                name: "DietaryTagRecipe");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "RecipeInstruction");

            migrationBuilder.DropTable(
                name: "RecipeReview");

            migrationBuilder.DropTable(
                name: "RecipeUser");

            migrationBuilder.DropTable(
                name: "RecipeUser1");

            migrationBuilder.DropTable(
                name: "MondialMunchEvents");

            migrationBuilder.DropTable(
                name: "DietaryTags");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
