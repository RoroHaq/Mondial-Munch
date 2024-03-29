using System.ComponentModel.DataAnnotations;

public class Recipe{

    private string _name;
    public User Creator { get;}
    public string? _description;
    public int _servings;
    public double _prepTime;
    public double _cookingTime;
    public double TotalTime => _prepTime + _cookingTime;
    public Country Country { get; internal set;}
    public List<string> _instructions;
    public List<Ingredient> _ingredients;
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
        _description= description;
        _servings = servings;
        _prepTime = preptime;
        _cookingTime = cookingTime;
        Country = country;
        _instructions = instructions;
        _ingredients = ingredients;
    }

    public string Name{
        get{ return _name;}
        internal set{
            if(string.IsNullOrEmpty(_name)){
                throw new ArgumentNullException("Name is null or is an Empty String");
            }
            else if(_name.Length > 50){
                throw new ValidationException("Name is too big");
            }

            _name = value;
        }
    }

    public string? Description{
        get{ return _description;}

        internal set{
            if(_description == "" || _description == ""){
                throw new ValidationException("Description is empty or blank");
            }
            else if(_description.Length > 300){
                throw new ValidationException("Description Lenght Too Large");
            }

            _description = value;
        }
    }

    public int Servings{
        get{ return _servings; }

        internal set{
            if(_servings < 0){
                throw new ValidationException("Serving size is invalid. Cannot be negative or 0");
            }

            _servings = value;
        }
    }

    public double PrepTime{
        get{ return _prepTime;}

        internal set{
            if(_prepTime < 0){
                throw new ValidationException("Prep time size is invalid. Cannot be negative or 0");
            }

            _prepTime = value;
        }
    }

    public double CookingTime{
        get{ return _cookingTime;}

        internal set{
            if(_cookingTime < 0){
                throw new ValidationException("Cooking Time size is invalid. Cannot be negative or 0");
            }

            _cookingTime = value;
        }
    }

    public List<string> Instructions{
        get{return _instructions; }

        internal set{
            if(_instructions.Count == 0){
                throw new ValidationException("You cant have 0 steps");
            }

            _instructions = value;
        }
    }

    public List<Ingredient> Ingredients{
        get{return _ingredients; }

        internal set{
            if(_instructions.Count == 0){
                throw new ValidationException("You cant have 0 Ingredients in your Recipe");
            }

            _ingredients = value;
        }
    }


}
