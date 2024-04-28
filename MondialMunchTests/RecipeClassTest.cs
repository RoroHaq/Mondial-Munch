using System.Net.Http.Headers;

namespace MondialMunch;

[TestClass]
public class RecipeClassTest {
    public List<RecipeInstruction> MakeMockSteps() {
        List<RecipeInstruction> steps = new();
        steps.Add(new("1. Get out your meat"));
        steps.Add(new("2. Add in seasoning"));
        return steps;
    }

    public List<Ingredient> MakeMockIngredients() {
        List<Ingredient> ingredients = new List<Ingredient>();
        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));
        return ingredients;
    }

    public User MakeMockUser() {
        return new User("Safin", "img/something.png", "a guy who enjoys cooking",
                        new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());
    }

    [TestMethod]
    public void RecipeClassPasses() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new("Tacos", testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameIsNull() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new(null, testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameIsBlank() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("", testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameHasWhiteSpace() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe(" ", testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidNameIsTooBig() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("tacooooooooooooooooooooooooooooooooooooooooooooooos",
                            testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidDescriptionIsBlank() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidDescriptionIsEmpty() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, " ", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidServingSizeIs0() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", 0, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidServingSizeIsNegative() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", -2, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidPrepTimeIs0() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 0, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidPrepTimeIsNegative() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", 5, -14, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidCookingTimeIs0() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", 5, 3, 0, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidCookingTimeIsNegative() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", 5, 3, -15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidStepsIsSize0() {
        // arrange
        List<RecipeInstruction> steps = new List<RecipeInstruction>();
        List<Ingredient> ingredients = MakeMockIngredients();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidIngredeintsIsSize0() {
        // arrange
        List<RecipeInstruction> steps = MakeMockSteps();
        List<Ingredient> ingredients = new List<Ingredient>();
        User testUser = MakeMockUser();

        // act
        Recipe recipe = new Recipe("taco", testUser, "", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }
}
