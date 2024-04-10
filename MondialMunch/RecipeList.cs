namespace MondialMunch;

public class RecipeList {
    public IEnumerable<Recipe> Recipes { get; private set; }

    public RecipeList(IEnumerable<Recipe> recipes) {
        this.Recipes = recipes;
    }

    public Recipe this[int index] => this.Recipes.ToList()[index];

    public void FilterByIngredients(IEnumerable<Ingredient> ingredients) {
        this.Recipes = this.Recipes.Where(r => r.Ingredients.Select(i => i.Name).Intersect(ingredients.Select(i => i.Name)).Any());
    }

    public void FilterByMinTime(double minTime) {
        this.Recipes = this.Recipes.Where(r => r.TotalTime >= minTime);
    }

    public void FilterByMaxTime(double maxTime) {
        this.Recipes = this.Recipes.Where(r => r.TotalTime <= maxTime);
    }

    public void FilterByMinServings(int minServings) {
        this.Recipes = this.Recipes.Where(r => r.Servings >= minServings);
    }

    public void FilterByMaxServings(int maxServings) {
        this.Recipes = this.Recipes.Where(r => r.Servings <= maxServings);
    }

    public void FilterByTags(List<DietaryTags> tags) {
        this.Recipes = this.Recipes.Where(r => r.Tags != null && r.Tags.Intersect(tags).Any());
    }

    public void FilterByKeyword(string keyword) {
        this.Recipes = this.Recipes.Where(r => r.Name.ToLower().Contains(keyword.ToLower()) || (r.Description != null && r.Description.ToLower().Contains(keyword.ToLower())));
    }

    public void FilterByCreator(string username) {
        this.Recipes = this.Recipes.Where(r => r.Creator.Name == username);
    }
}
