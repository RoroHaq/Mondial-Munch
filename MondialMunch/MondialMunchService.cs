using Microsoft.EntityFrameworkCore;

namespace MondialMunch;

public class MondialMunchService {
    private User? _current_user;
    private readonly MondialMunchContext _context;

    public User? CurrentUser {
        get => this._current_user;
        set {
            if (value != null && !value.IsAuthenticated) throw new Exception("Current user must be authenticated.");
            this._current_user = value;
        }
    }

    public MondialMunchService(MondialMunchContext context) {
        _context = context;
    }

    public List<Recipe> GetRecipes() {
        return _context.Recipes
            .Include(r => r.Creator)
            .Include(r => r.Country)
            .Include(r => r.Instructions)
            .Include(r => r.Ingredients)
            .ToList();
    }
    public List<User> GetUsers() {
        return _context.Users
            .Include(u => u.CountryOrigin)
            .Include(u => u.CountryCurrent)

            .Include(u => u.PersonalRecipes).ThenInclude(r => r.Country)
            .Include(u => u.PersonalRecipes).ThenInclude(r => r.Instructions)
            .Include(u => u.PersonalRecipes).ThenInclude(r => r.Ingredients)

            .Include(u => u.FavouriteRecipies).ThenInclude(r => r.Country)
            .Include(u => u.FavouriteRecipies).ThenInclude(r => r.Instructions)
            .Include(u => u.FavouriteRecipies).ThenInclude(r => r.Ingredients)

            .Include(u => u.TodoRecipies).ThenInclude(r => r.Country)
            .Include(u => u.TodoRecipies).ThenInclude(r => r.Instructions)
            .Include(u => u.TodoRecipies).ThenInclude(r => r.Ingredients)

            .ToList();
    }
    public List<Country> GetCountries() => _context.Countries.ToList();
    public List<DietaryTag> GetDietaryTags() => _context.DietaryTags.ToList();

    public User? GetUserByUsername(string name) => GetUsers().FirstOrDefault(user => user.Name == name);
    public Country? GetCountryByName(string name) => _context.Countries.FirstOrDefault(country => country.Name == name);

    public void AddRecipe(Recipe recipe) {
        _context.Recipes.Add(recipe);
        _context.SaveChanges();
    }

    public void AddUser(User user) {
        if (!user.IsAuthenticated) throw new Exception("User objects must be authenticated before entering database.");

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void FavoriteRecipe(Recipe recipe) {
        if (_current_user == null) throw new Exception("Not logged in.");
        if (_current_user.FavouriteRecipies.Contains(recipe)) throw new Exception("Recipe is already in favorites.");

        _current_user.FavouriteRecipies.Add(recipe);
        _context.SaveChanges();
    }

    public void UnfavoriteRecipe(Recipe recipe) {
        if (_current_user == null) throw new Exception("Not logged in.");
        if (!_current_user.FavouriteRecipies.Contains(recipe)) throw new Exception("Recipe is not in favorites.");

        _current_user.FavouriteRecipies.Remove(recipe);
        _context.SaveChanges();
    }

    public void DeleteRecipe(Recipe recipe) {
        if (_current_user == null) throw new Exception("Not logged in.");
        if (_current_user.Name != recipe.Creator.Name) throw new Exception("You do not own this recipe.");

        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
    }

    public void DeleteUser(User user) {
        if (_current_user == null) throw new Exception("Not logged in.");
        if (_current_user.Name != user.Name) throw new Exception("You cannot delete this user.");

        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
