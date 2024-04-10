namespace MondialMunch;

public class Program {
    private static User? currentUser;

    private static void PromptLogin() {
        Console.WriteLine("Enter username:");
        string? username = Console.ReadLine();

        Console.WriteLine("Enter password:");
        string? password = Console.ReadLine();

        if (username == null || password == null) return;

        User? user = MockData.Users.FirstOrDefault(u => u.Name == username);
        if (user == null) {
            Console.WriteLine("This user does not exist.");
            return;
        }

        if (!user.SamePassword(password)) {
            Console.WriteLine("Wrong password.");
            return;
        }

        currentUser = user;
        Console.WriteLine("Welcome back to Mondial Munch, " + username + "!");
    }

    private static void PromptCreateAccount() {
        // prompt username
        Console.WriteLine("Enter username (leave blank to cancel):");
        string? username = Console.ReadLine();
        if (string.IsNullOrEmpty(username)) return;
        if (MockData.Users.FirstOrDefault(u => u.Name == username) != null) {
            Console.WriteLine("This user already exists.");
            return;
        }

        // prompt password
        Console.WriteLine("Create your password (leave blank to cancel):");
        string? password = Console.ReadLine();
        if (string.IsNullOrEmpty(password)) return;

        // re-prompt password
        Console.WriteLine("Re-enter your password (leave blank to cancel):");
        string? password2 = Console.ReadLine();
        if (string.IsNullOrEmpty(password2)) return;
        if (password != password2) {
            Console.WriteLine("Passwords do not match.");
            return;
        }

        // prompt description
        Console.WriteLine("Enter profile description (leave blank to cancel):");
        string? description = Console.ReadLine();
        if (string.IsNullOrEmpty(description)) return;

        // prompt country of origin
        Console.WriteLine("Enter your country of origin (enter the number) (leave blank/invalid to cancel):");
        foreach (int c in Enum.GetValues(typeof(Country))) {
            Console.Write("( " + c + " " + Enum.GetName(typeof(Country), c) + " ) ");
        }
        bool hasCountryNumber = int.TryParse(Console.ReadLine(), out int countryNumber);
        if (!hasCountryNumber) return;
        if (!Enum.IsDefined(typeof(Country), countryNumber)) return;
        Country country = (Country)countryNumber;

        // prompt current country
        Console.WriteLine("Enter your current country (enter the number) (leave blank/invalid to cancel):");
        foreach (int c in Enum.GetValues(typeof(Country))) {
            Console.Write("( " + c + " " + Enum.GetName(typeof(Country), c) + " ) ");
        }
        bool hasCurrentCountryNumber = int.TryParse(Console.ReadLine(), out int currentCountryNumber);
        if (!hasCurrentCountryNumber) return;
        if (!Enum.IsDefined(typeof(Country), countryNumber)) return;
        Country currentCountry = (Country)countryNumber;

        // create user
        User newUser = new(username, "img/something.png", description, country, currentCountry, password, User.GenerateSalt());
        MockData.Users.Add(newUser);
        currentUser = newUser;
        Console.WriteLine("Welcome to Mondial Munch, " + username + "!");
    }

    private static void PromptUserActionUpdateProfile() {
        Console.WriteLine("Write your new description (leave blank to skip):");
        string? description = Console.ReadLine();

        Console.WriteLine("Write your new country of origin (enter the number) (leave blank to skip):");
        foreach (int c in Enum.GetValues(typeof(Country))) {
            Console.Write("( " + c + " " + Enum.GetName(typeof(Country), c) + " ) ");
        }
        Console.WriteLine();
        string? countryOrigin = Console.ReadLine();

        Console.WriteLine("Write your new current country (enter the number) (leave blank to skip):");
        foreach (int c in Enum.GetValues(typeof(Country))) {
            Console.Write("( " + c + " " + Enum.GetName(typeof(Country), c) + " ) ");
        }
        Console.WriteLine();
        string? currentCountry = Console.ReadLine();

        if (!string.IsNullOrEmpty(description)) {
            // currentUser.ChangeDescription(description);
        }
    }

    private static void PromptUserActionUpdatePassword() {
        Console.WriteLine("Enter current password:");
        string? currentPassword = Console.ReadLine();

        while (true) {
            if (string.IsNullOrEmpty(currentPassword)) {
                Console.WriteLine("Null value entered, cancelling operation.");
                return;
            }
            if (!currentUser!.SamePassword(currentPassword)) {
                Console.WriteLine("Password is wrong. Try again.");
                currentPassword = Console.ReadLine();
            }
            else break;
        }

        Console.WriteLine("Enter new password:");
        string? newPassword = Console.ReadLine();

        Console.WriteLine("Re-enter new password:");
        string? newPassword2 = Console.ReadLine();

        if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newPassword2)) {
            Console.WriteLine("Null value entered, cancelling operation.");
            return;
        }
        if (newPassword != newPassword2) {
            Console.WriteLine("Passwords do not match.");
            return;
        }

        if (currentUser.ResetPassword(currentPassword, newPassword) == true) {
            Console.WriteLine("Updated password!");
        }
        else {
            Console.WriteLine("Could not reset password.");
        }
    }

    private static void PromptUserDeleteAccount() {
        Console.WriteLine("Enter password:");
        string? currentPassword = Console.ReadLine();

        while (true) {
            if (string.IsNullOrEmpty(currentPassword)) {
                Console.WriteLine("Null value entered, cancelling operation.");
                return;
            }
            if (!currentUser!.SamePassword(currentPassword)) {
                Console.WriteLine("Password is wrong. Try again.");
                currentPassword = Console.ReadLine();
            }
            else break;
        }

        Console.WriteLine("Are you sure you want to delete your account? Type in " + currentUser.Name + " to confirm.");
        string? username = Console.ReadLine();

        if (username != currentUser.Name) {
            Console.WriteLine("Operation cancelled.");
        }
        else {
            MockData.Users.Remove(currentUser);
            currentUser = null;
            Console.WriteLine("Deleted account.");
        }
    }

    private static void PromptUserActions() {
        Console.WriteLine("1. Update profile");
        Console.WriteLine("2. Update password");
        Console.WriteLine("3. Delete account");

        string? input = Console.ReadLine();
        if (input == null) return;

        switch (input) {
            case "1":
                PromptUserActionUpdateProfile();
                break;
            case "2":
                PromptUserActionUpdatePassword();
                break;
            case "3":
                PromptUserDeleteAccount();
                break;
        }
    }

    private static void PromptSearchRecipe() {
        // input keyword
        Console.WriteLine("Filter by keyword (leave blank to skip):");
        string? keyword = Console.ReadLine();

        // input ingredients
        Console.WriteLine("Filter by ingredients (leave blank to skip/continue):");
        List<Ingredient> ingredients = new();
        while (true) {
            string? ingredient = Console.ReadLine();
            if (string.IsNullOrEmpty(ingredient)) break;
            ingredients.Add(new(ingredient, 1));
        }

        // input min time
        Console.WriteLine("Filter by minimum time (leave blank to skip):");
        bool hasMinTime = int.TryParse(Console.ReadLine(), out int minTime);

        // input max time
        Console.WriteLine("Filter by maximum time (leave blank to skip):");
        bool hasMaxTime = int.TryParse(Console.ReadLine(), out int maxTime);

        // input min servings
        Console.WriteLine("Filter by minimum servings (leave blank to skip):");
        bool hasMinServings = int.TryParse(Console.ReadLine(), out int minServings);

        // input max servings
        Console.WriteLine("Filter by maximum servings (leave blank to skip):");
        bool hasMaxServings = int.TryParse(Console.ReadLine(), out int maxServings);

        // input tags
        List<DietaryTags> tags = new();
        Console.WriteLine("Filter by tags (enter the number) (leave blank to skip/continue):");
        foreach (int c in Enum.GetValues(typeof(DietaryTags))) {
            Console.Write("( " + c + " " + Enum.GetName(typeof(DietaryTags), c) + " ) ");
        }
        Console.WriteLine();
        while (true) {
            bool didParseCorrectly = int.TryParse(Console.ReadLine(), out int tagNumber);
            if (!didParseCorrectly) break;
            if (Enum.IsDefined(typeof(DietaryTags), tagNumber)) {
                tags.Add((DietaryTags)tagNumber);
            }
        }

        // input creator
        Console.WriteLine("Filter by creator (leave blank to skip):");
        string? creator = Console.ReadLine();

        // filter
        RecipeList recipes = new(MockData.Recipes);
        if (!string.IsNullOrEmpty(keyword)) recipes.FilterByKeyword(keyword);
        if (ingredients.Count > 0) recipes.FilterByIngredients(ingredients);
        if (hasMinTime) recipes.FilterByMinTime(minTime);
        if (hasMaxTime) recipes.FilterByMaxTime(maxTime);
        if (hasMinServings) recipes.FilterByMinServings(minServings);
        if (hasMaxServings) recipes.FilterByMaxServings(maxServings);
        if (tags.Count > 0) recipes.FilterByTags(tags);
        if (!string.IsNullOrEmpty(creator)) recipes.FilterByCreator(creator);

        // display
        Console.WriteLine("Found " + recipes.Recipes.Count() + " recipes.");
        foreach (Recipe r in recipes.Recipes) {
            Console.WriteLine(r.Name + " by " + r.Creator);
        }
        Console.WriteLine();
    }

    private static void PromptAddRecipe() {
        // input name
        Console.WriteLine("Enter recipe name (leave blank to cancel):");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name)) return;

        // input description
        Console.WriteLine("Enter description (leave blank to skip):");
        string? description = Console.ReadLine();

        // input servings
        Console.WriteLine("Enter serving size (leave blank to cancel):");
        bool hasServings = int.TryParse(Console.ReadLine(), out int servings);
        if (!hasServings) return;

        // input prep time
        Console.WriteLine("Enter prep time (leave blank to cancel):");
        bool hasPrepTime = int.TryParse(Console.ReadLine(), out int prepTime);
        if (!hasPrepTime) return;

        // input cook time
        Console.WriteLine("Enter cook time (leave blank to cancel):");
        bool hasCookTime = int.TryParse(Console.ReadLine(), out int cookTime);
        if (!hasCookTime) return;

        // input country
        Console.WriteLine("Enter country (enter the number) (leave blank/invalid to cancel):");
        foreach (int c in Enum.GetValues(typeof(Country))) {
            Console.Write("( " + c + " " + Enum.GetName(typeof(Country), c) + " ) ");
        }
        bool hasCountryNumber = int.TryParse(Console.ReadLine(), out int countryNumber);
        if (!hasCountryNumber) return;
        if (!Enum.IsDefined(typeof(Country), countryNumber)) return;
        Country country = (Country)countryNumber;

        // input instructions
        Console.WriteLine("Enter instructions (leave blank to cancel/continue)");
        List<string> instructions = new();
        while (true) {
            string? instruction = Console.ReadLine();
            if (string.IsNullOrEmpty(instruction)) break;
            instructions.Add(instruction);
        }
        if (instructions.Count == 0) return;

        // input ingredients
        Console.WriteLine("Enter ingredients (leave blank to skip/continue):");
        List<Ingredient> ingredients = new();
        while (true) {
            Console.WriteLine("Name:");
            string? ingredient = Console.ReadLine();
            if (string.IsNullOrEmpty(ingredient)) break;

            Console.WriteLine("Amount:");
            bool hasAmount = int.TryParse(Console.ReadLine(), out int amount);
            if (!hasAmount) break;

            ingredients.Add(new(ingredient, amount));
        }
        if (ingredients.Count == 0) return;

        // make recipe
        Recipe recipe = new(name, currentUser!, description!, servings, prepTime, cookTime, country, instructions, ingredients);
        MockData.Recipes.Add(recipe);
        Console.WriteLine("Created recipe!");
    }

    public static void PromptDeleteRecipe() {
        // prompt enter name
        Console.WriteLine("Enter recipe name to delete (enter blank to cancel):");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name)) {
            Console.WriteLine("Cancelling operation.");
            return;
        }

        // get recipe
        Recipe? recipe = MockData.Recipes.FirstOrDefault(r => r.Name == name);
        if (recipe == null) {
            Console.WriteLine("This recipe does not exist.");
            return;
        }
        if (recipe.Creator != currentUser) {
            Console.WriteLine("You do not own this recipe.");
            return;
        }

        // prompt confirm
        Console.WriteLine("Are you sure you want to delete your recipe " + recipe.Name + "? You cannot undo this. Type 'yes' to confirm.");
        string? confirmation = Console.ReadLine();
        if (confirmation != "yes") {
            Console.WriteLine("Cancelling operation.");
            return;
        }

        // delete recipe
        MockData.Recipes.Remove(recipe);
        Console.WriteLine("Deleted recipe.");
    }

    public static void Main() {
        while (true) {
            if (currentUser == null) {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Sign up");

                string? input = Console.ReadLine();
                if (input == null) return;

                switch (input) {
                    case "1":
                        PromptLogin();
                        break;
                    case "2":
                        PromptCreateAccount();
                        break;
                }
            }
            else {
                Console.WriteLine("1. User operations");
                Console.WriteLine("2. Search for recipes");
                Console.WriteLine("3. Add recipe");
                Console.WriteLine("4. Delete recipe");

                string? input = Console.ReadLine();
                if (input == null) continue;

                switch (input) {
                    case "1":
                        PromptUserActions();
                        break;
                    case "2":
                        PromptSearchRecipe();
                        break;
                    case "3":
                        PromptAddRecipe();
                        break;
                    case "4":
                        PromptDeleteRecipe();
                        break;
                }
            }
        }
    }
}
