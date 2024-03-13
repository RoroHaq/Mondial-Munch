public class Recipe{

    public String _name { get;}
    public User _creator { get;}
    public String? _description { get; private set;}
    public int _servings { get;}
    public double _prep_time { get;}
    public double _cooking_time { get;}
    public double total_time => _prep_time + _cooking_time;
    public Country? _country { get;}
    public String[] _insturctions { get; private set;}
    public String[] _regular_ingredients { get; private set;}
    public String[] _ingredients_amounts { get; private set;}
    public String[] _substitutions { get; private set;}
    public DietaryTags tags { get; private set;}
    public int _stars { get; private set;}
}