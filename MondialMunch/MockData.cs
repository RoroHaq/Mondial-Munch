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
                new List<string> { "Peel potatoes", "Slice potatoes", "Place potatoes in fryer", "Put gravy", "Put cheese" },
                new List<Ingredient> { new("Potato", 6), new("Gravy", 1), new("Cheese", 12) }
        ),
        new ("Burger", Users[1], "America's best!", 2, 5, 20, new Country("United States"),
                new List<string> { "Shape meat into patties", "Grill meat", "Make burger" },
                new List<Ingredient> { new("Bun", 2), new("Cheese", 2), new("Lettuce", 1), new("Burger Meat", 1) }
        ),
        new ("Tacos", Users[2], "Very good tacos", 3, 5, 40, new Country("Mexico"),
                new List<string> { "Cook the meat", "Put the meat in the shell", "Put the toppings" },
                new List<Ingredient> { new("Taco shell", 3), new("Cheese", 2), new("Lettuce", 1), new("Taco Meat", 1) }
        )
    };
}
