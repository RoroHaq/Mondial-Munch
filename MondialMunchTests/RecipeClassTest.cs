using System.Net.Http.Headers;

namespace MondialMunch;

[TestClass]
public class RecipeClassTest {
    [TestMethod]
    public void RecipeClassPasses() {

        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("Tacos", testUser, "made in the depths of hell", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameIsNull() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe(null, testUser, "made in the depths of hell", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameIsBlank() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("", testUser, "made in the depths of hell", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameHasWhiteSpace() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe(" ", testUser, "made in the depths of hell", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidNameIsTooBig() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Ground Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("tacooooooooooooooooooooooooooooooooooooooooooooooos",
                            testUser, "made in the depths of hell", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidDescriptionIsBlank() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidDescriptionIsEmpty() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, " ", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidServingSizeIs0() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 0, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidServingSizeIsNegative() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", -2, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidPrepTimeIs0() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 0, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidPrepTimeIsNegative() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, -14, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidCookingTimeIs0() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 0, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidCookingTimeIsNegative() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, -15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidStepsIsSize0() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidIngredeintsIsSize0() {
        byte[] hash = User.GenerateSalt();

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, "password123", hash);


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 15, Country.Mexico,
                            steps, ingredients);
    }
}
