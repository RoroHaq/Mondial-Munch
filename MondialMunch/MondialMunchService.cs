namespace MondialMunch;

public class MondialMunchService {
    private readonly MondialMunchContext _context;

    public MondialMunchService(MondialMunchContext context) {
        _context = context;
    }

    public List<Recipe> GetRecipes() => _context.Recipes.ToList();
    public List<User> GetUsers() => _context.Users.ToList();
    public List<Country> GetCountries() => _context.Countries.ToList();
    public List<DietaryTag> GetDietaryTags() => _context.DietaryTags.ToList();

    public Country? GetCountryByName(string name) => _context.Countries.FirstOrDefault(country => country.Name == name);

    public void AddRecipe(Recipe recipe) {
        _context.Recipes.Add(recipe);
        _context.SaveChanges();
    }

    public void AddUser(User user) {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void DeleteRecipe(Recipe recipe) {
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
    }

    public void DeleteUser(User user) {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
