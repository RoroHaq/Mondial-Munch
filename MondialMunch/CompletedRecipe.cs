using Microsoft.VisualBasic;

namespace MondialMunch;

public class CompletedRecipe {

    public int Id { get; private set; }
    public Recipe RecipeCompleted { get; private set; }
    public User UserCompleting { get; private set; }
    public DateTime DateCompleted { get; private set; }

    public CompletedRecipe(Recipe recipe, User user, DateTime date) {
        this.RecipeCompleted = recipe;
        this.UserCompleting = user;
        this.DateCompleted = date;
    }

    private CompletedRecipe() { }

    // override object.Equals
    public override bool Equals(object obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }

        if (obj is CompletedRecipe c) {
            return RecipeCompleted == c.RecipeCompleted && UserCompleting == c.UserCompleting;
        }
        return false;
    }
}
