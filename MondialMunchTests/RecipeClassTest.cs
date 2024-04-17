using System.Net.Http.Headers;

namespace MondialMunch;

[TestClass]
public class RecipeClassTest {
    [TestMethod]
    public void RecipeClassPasses() {

        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("Tacos", testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameIsNull() {



        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe(null, testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameIsBlank() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("", testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RecipeClassInvalidNameHasWhiteSpace() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe(" ", testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidNameIsTooBig() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Ground Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("tacooooooooooooooooooooooooooooooooooooooooooooooos",
                            testUser, "made in the depths of hell", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidDescriptionIsBlank() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidDescriptionIsEmpty() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, " ", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidServingSizeIs0() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 0, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidServingSizeIsNegative() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", -2, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidPrepTimeIs0() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 0, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidPrepTimeIsNegative() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, -14, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidCookingTimeIs0() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 0, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidCookingTimeIsNegative() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, -15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidStepsIsSize0() {


        List<string> steps = new List<string>();

        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients.Add(new Ingredient("Groudn Beef", 2));
        ingredients.Add(new Ingredient("Taco seasoning", 1));

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RecipeClassInvalidIngredeintsIsSize0() {


        List<string> steps = new List<string>();

        steps.Add("1. Get out your meat");
        steps.Add("2. Add in seasoning");

        List<Ingredient> ingredients = new List<Ingredient>();

        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                new Country("Canada"), new Country("Mexico"), "password123", User.GenerateSalt());


        Recipe recipe = new Recipe("taco",
                            testUser, "", 5, 3, 15, new Country("Mexico"),
                            steps, ingredients);
    }
}
