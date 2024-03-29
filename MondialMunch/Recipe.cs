using System.ComponentModel.DataAnnotations;

public class Recipe{

    private string _name;
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
        _name= name;
        Creator = creator;
        Description= description;
        Servings = servings;
        PrepTime = preptime;
        CookingTime = cookingTime;
        Country = country;
        Instructions = instructions;
        Ingredients = ingredients;
    }

    public string Name{
        get{ return _name;}
        set{
            if(string.IsNullOrEmpty(_name)){
                throw new ArgumentNullException("Name is null or is an Empty String");
            }
            else if(_name.Length > 50){
                throw new ValidationException("Name is too big");
            }

            _name = value;
        }
    }
}
