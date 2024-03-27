public class Recipe{

    public string Name { get; internal set;}
    public User Creator { get;}
    public string? Description { get; internal set;}
    public int Servings { get; internal set;}
    public double PrepTime { get; internal set;}
    public double CookingTime { get; internal set;}
    public double TotalTime => PrepTime + CookingTime;
    public Country Country { get; internal set;}
    public List<string> Instructions { get; internal set;}
    public List<Ingredient> Ingredients { get; internal set;}
    public Dictionary<string, string[]>? Substitutions { get; internal set;}
    public List<DietaryTags>? Tags { get; internal set;}
    public int Stars { get; internal set;}

    public Recipe(string name, User creator, string description, int servings, 
                    double preptime, double cookingTime, Country country, List<string> instructions, List<Ingredient> ingredients){
        
        /*
            PrepTime & Cooking Cant be < 0
            Description and name cant be "" or " "
            name can have a size limit but cant be null
            Description can be null
            Instructions and Ingredients cannot be a size of 0
        */

        Name= name;
        Creator = creator;
        Description= description;
        Servings = servings;
        PrepTime = preptime;
        CookingTime = cookingTime;
        Country = country;
        Instructions = instructions;
        Ingredients = ingredients;
    }
}
