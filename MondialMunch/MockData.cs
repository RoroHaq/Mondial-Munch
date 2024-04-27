namespace MondialMunch;

public class MockData {
    public static List<User> Users = new(){
        new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            new Country("Canada"), new Country("Canada"), "password123", User.GenerateSalt()),
        new("Andrew", "img/something.png", "This is Andrew.",
                            new Country("Canada"), new Country("United States"), "password123", User.GenerateSalt()),
        new("Safin", "img/something.png", "I am Safin.",
                            new Country("Mexico"), new Country("Canada"), "password123", User.GenerateSalt())
    };

    public static List<Recipe> Recipes = new() {
        new ("Poutine", Users[0], "Iconic Canadian dish", 1, 10, 10, new Country("Canada"),
                new List<RecipeInstruction> { new("Peel potatoes"), new("Slice potatoes"), new("Place potatoes in fryer"), new("Put gravy"), new("Put cheese") },
                new List<Ingredient> { new("Potato", 6), new("Gravy", 1), new("Cheese", 12) }
        ),
        new ("Burger", Users[1], "America's best!", 2, 5, 20, new Country("United States"),
                new List<RecipeInstruction> { new("Shape meat into patties"), new("Grill meat"), new("Make burger") },
                new List<Ingredient> { new("Bun", 2), new("Cheese", 2), new("Lettuce", 1), new("Burger Meat", 1) }
        ),
        new ("Tacos", Users[2], "Very good tacos", 3, 5, 40, new Country("Mexico"),
                new List<RecipeInstruction> { new("Cook the meat"), new("Put the meat in the shell"), new("Put the toppings") },
                new List<Ingredient> { new("Taco shell", 3), new("Cheese", 2), new("Lettuce", 1), new("Taco Meat", 1) }
        )
    };
}
