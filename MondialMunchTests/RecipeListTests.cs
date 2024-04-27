namespace MondialMunchTests;
using MondialMunch;

[TestClass]
public class RecipeListTests {
    public RecipeList MakeMockRecipeList() {
        User testUser1 = new("User1", "img/something.png", "Description1", new Country("Canada"), new Country("Canada"), "password123", User.GenerateSalt());
        User testUser2 = new("User2", "img/something.png", "Description2", new Country("Canada"), new Country("Canada"), "password123", User.GenerateSalt());

        List<Recipe> recipes = new() {
            new Recipe(
                "Recipe 1", testUser1, "This is my first recipe", 3, 15, 15, new Country("Canada"),
                new List<RecipeInstruction> { new("Step 1"), new("Step 2") },
                new List<Ingredient> { new("Eggs", 3), new("Flour", 2) }
            ),
            new Recipe(
                "Recipe 2", testUser1, "This is my second recipe", 6, 5, 5, new Country("Mexico"),
                new List<RecipeInstruction> { new("Step 1"), new("Step 2") },
                new List<Ingredient> { new("Beans", 1), new("Steak", 2) }
            ),
            new Recipe(
                "Burger", testUser1, "Delicious food", 1, 10, 10, new Country("United States"),
                new List<RecipeInstruction> { new("Step 1"), new("Step 2") },
                new List<Ingredient> { new("Meat", 1), new("Bread", 2), new("Lettuce", 1), new("Tomato", 4), new("Cheese", 1) }
            ),
            new Recipe(
                "Food", testUser2, "Food", 2, 5, 10, new Country("Mexico"),
                new List<RecipeInstruction> { new("Step 1"), new("Step 2") },
                new List<Ingredient> { new("Eggs", 1), new("Cheese", 2) }
            )
        };

        return new RecipeList(recipes);
    }

    [TestMethod]
    public void RecipeList_FilterByIngredients() {
        // Arrange
        RecipeList mockRecipes = MakeMockRecipeList();

        // Act
        mockRecipes.FilterByIngredients(new List<Ingredient> { new("Eggs", 1) });

        // Assert
        Assert.AreEqual("Recipe 1", mockRecipes[0].Name);
        Assert.AreEqual("Food", mockRecipes[1].Name);
        Assert.AreEqual(2, mockRecipes.Recipes.Count());
    }


    [TestMethod]
    public void FilterByMinTime() {
        // Arrange
        RecipeList mockRecipes = MakeMockRecipeList();

        // Act
        mockRecipes.FilterByMinTime(20);

        // Assert
        Assert.AreEqual("Recipe 1", mockRecipes[0].Name);
        Assert.AreEqual("Burger", mockRecipes[1].Name);
        Assert.AreEqual(2, mockRecipes.Recipes.Count());
    }

    [TestMethod]
    public void FilterByMaxTime() {
        // Arrange
        RecipeList mockRecipes = MakeMockRecipeList();

        // Act
        mockRecipes.FilterByMaxTime(15);

        // Assert
        Assert.AreEqual("Recipe 2", mockRecipes[0].Name);
        Assert.AreEqual("Food", mockRecipes[1].Name);
        Assert.AreEqual(2, mockRecipes.Recipes.Count());
    }

    [TestMethod]
    public void FilterByMinServings() {
        // Arrange
        RecipeList mockRecipes = MakeMockRecipeList();

        // Act
        mockRecipes.FilterByMinServings(3);

        // Assert
        Assert.AreEqual("Recipe 1", mockRecipes[0].Name);
        Assert.AreEqual("Recipe 2", mockRecipes[1].Name);
        Assert.AreEqual(2, mockRecipes.Recipes.Count());
    }

    [TestMethod]
    public void FilterByMaxServings() {
        // Arrange
        RecipeList mockRecipes = MakeMockRecipeList();

        // Act
        mockRecipes.FilterByMaxServings(3);

        // Assert
        Assert.AreEqual("Recipe 1", mockRecipes[0].Name);
        Assert.AreEqual("Burger", mockRecipes[1].Name);
        Assert.AreEqual("Food", mockRecipes[2].Name);
        Assert.AreEqual(3, mockRecipes.Recipes.Count());
    }

    [TestMethod]
    public void FilterByTags() {
        // Tags are not yet part of the Recipe constructor, cannot test this method
        Assert.Fail();
    }

    [TestMethod]
    public void FilterByKeyword() {
        // Arrange
        RecipeList mockRecipes = MakeMockRecipeList();

        // Act
        mockRecipes.FilterByKeyword("food");

        // Assert
        Assert.AreEqual("Burger", mockRecipes[0].Name);
        Assert.AreEqual("Food", mockRecipes[1].Name);
        Assert.AreEqual(2, mockRecipes.Recipes.Count());
    }

    [TestMethod]
    public void FilterByCreator() {
        // Arrange
        RecipeList mockRecipes = MakeMockRecipeList();

        // Act
        mockRecipes.FilterByCreator("User2");

        // Assert
        Assert.AreEqual("Food", mockRecipes[0].Name);
        Assert.AreEqual(1, mockRecipes.Recipes.Count());
    }
}
