public class Recipe{

    public string Name { get; internal set;}
    public User Creator { get;}
    public string? Description { get; internal set;}
    public int Servings { get; internal set;}
    public double PrepTime { get; internal set;}
    public double CookingTime { get; internal set;}
    public double TotalTime => PrepTime + CookingTime;
    public Country Country { get; internal set;}
    public string[] Instructions { get; internal set;}
    public string[] RegularIngredients { get; internal set;}
    public string[] IngredientsAmounts { get; internal set;}
    public Dictionary<string, string[]>? Substitutions { get; internal set;}
    public DietaryTags Tags { get; internal set;}
    public int Stars { get; internal set;}

    public Recipe(string name, User creator, string description, int servings, double preptime, double cookingTime, Country country, string[] Instructions, ){

    }
}