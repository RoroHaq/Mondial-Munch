namespace MondialMunch;

public class Program {
    private static User? currentUser;

    private static void PromptLogin() {
        Console.WriteLine("Enter username:");
        string? username = Console.ReadLine();

        Console.WriteLine("Enter password:");
        string? password = Console.ReadLine();

        if (username == null || password == null) return;

        User user = MockData.Users.First(u => u.Name == username);
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

    private static void PromptUserActions() {
        Console.WriteLine("1. Update description");
        Console.WriteLine("2. Update password");
        Console.WriteLine("3. Delete account");

        string? input = Console.ReadLine();
        if (input == null) return;
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
                }
            }
        }
    }
}
