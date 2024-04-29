using System.ComponentModel.DataAnnotations.Schema;
using MondialMunch;


public class Recipe {

    public int Id { get; private set; }
    private string _name;
    public User Creator { get; }
    public string? _description;
    public int _servings;
    public double _prepTime;
    public double _cookingTime;
    public double TotalTime => _prepTime + _cookingTime;
    public Country Country { get; internal set; }
    public List<RecipeInstruction> _instructions;
    public List<Ingredient> _ingredients;
    // public Dictionary<string, string[]>? Substitutions { get; internal set; } // entity framework doesn't like this
    public List<DietaryTag>? Tags { get; internal set; }
    public int Stars { get; internal set; }
    public List<User> FavouriteUsers { get; internal set; }
    public List<User> TodoUsers { get; internal set; }

    public Recipe(string name, User creator, string description, int servings,
                    double preptime, double cookingTime, Country country, List<RecipeInstruction> instructions, List<Ingredient> ingredients) {

        /*
            PrepTime & Cooking Cant be < 0
            Description and name cant be "" or " "
            name can have a size limit but cant be null
            Description can be null
            Instructions and Ingredients cannot be a size of 0
        */
        Name = name;
        Creator = creator;
        Description = description;
        Servings = servings;
        PrepTime = preptime;
        CookingTime = cookingTime;
        Country = country;
        Instructions = instructions;
        Ingredients = ingredients;
    }

    private Recipe() { }

    public string Name {
        get { return _name; }
        internal set {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException("Name is either null, has an Empty String or its a white space");
            }
            else if (value.Length > 50) {
                throw new ArgumentException("Name is too big");
            }

            _name = value;
        }
    }
    public string? Description {
        get { return _description; }

        internal set {
            if (value == "" || value == " ") {
                throw new ArgumentException("Description is empty or blank");
            }
            else if (value.Length > 300) {
                throw new ArgumentException("Description Length Too Large");
            }

            _description = value;
        }
    }

    public int Servings {
        get { return _servings; }

        internal set {
            if (value <= 0) {
                throw new ArgumentException("Serving size is invalid. Cannot be negative or 0");
            }

            _servings = value;
        }
    }

    public double PrepTime {
        get { return _prepTime; }

        internal set {
            if (value <= 0) {
                throw new ArgumentException("Prep time size is invalid. Cannot be negative or 0");
            }

            _prepTime = value;
        }
    }

    public double CookingTime {
        get { return _cookingTime; }

        internal set {
            if (value < 0) {
                throw new ArgumentException("Cooking Time size is invalid. Cannot be negative.");
            }

            _cookingTime = value;
        }
    }

    public List<RecipeInstruction> Instructions {
        get { return _instructions; }

        internal set {
            if (value.Count == 0) {
                throw new ArgumentException("You cant have 0 steps");
            }

            _instructions = value;
        }
    }

    public List<Ingredient> Ingredients {
        get { return _ingredients; }

        internal set {
            if (value.Count == 0) {
                throw new ArgumentException("You cant have 0 Ingredients in your Recipe");
            }

            _ingredients = value;
        }
    }
}

public class RecipeInstruction {
    public int Id { get; private set; }
    public string Text { get; private set; }
    public Recipe Recipe { get; private set; }

    public RecipeInstruction(string text) {
        Text = text;
    }
    private RecipeInstruction() { }

    public override string ToString() {
        return Text;
    }

    public override bool Equals(object? obj) {
        RecipeInstruction c = (RecipeInstruction)obj;
        return Text.Equals(c.Text);
    }
}

