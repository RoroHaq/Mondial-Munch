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
            Console.WriteLine(r.Name);
        }
    }

    public static void Main() {
        while (true) {
            if (currentUser == null) {
                PromptLogin();
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
                }
            }
        }
    }
}
