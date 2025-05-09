using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MondialMunch;
public class User {
    public int Id { get; private set; }
    private string _name;
    public string Name {
        get { return _name; }
        private set {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException("Name is null or is an Empty String");
            }
            else if (value.Length > 50) {
                throw new ValidationException("Name is too long");
            }
            else if (value.Length < 3) {
                throw new ValidationException("Name is too short");
            }

            _name = value;
        }
    }
    public string? ProfilePicturePath { get; private set; }
    private string? _description;
    public string? Description {
        get { return _description; }
        internal set {
            if (value != null && value.Length > 5000) {
                throw new ValidationException("Description is too long");
            }

            _description = value;
        }
    }
    public Country CountryOrigin { get; internal set; }
    public Country? CountryCurrent { get; internal set; }
    private byte[] _password { get; set; }
    private byte[] _salt { get; set; }
    private bool _is_authenticated { get; set; } = false;
    public bool IsAuthenticated => _is_authenticated;
    public List<Recipe> PersonalRecipes { get; internal set; }
    [InverseProperty("FavouriteUsers")]
    public List<Recipe> FavouriteRecipies { get; internal set; }
    [InverseProperty("TodoUsers")]
    public List<Recipe> TodoRecipies { get; internal set; }
    public List<CompletedRecipe> CompletedRecipies { get; internal set; }

    public User(string name, string profile_picture_path, string description, Country country_origin,
                Country? country_current, string unhashed_password, byte[] salt) {
        Name = name;
        ProfilePicturePath = profile_picture_path;
        Description = description;
        CountryOrigin = country_origin;
        CountryCurrent = country_current;
        PersonalRecipes = new List<Recipe>();
        FavouriteRecipies = new List<Recipe>();
        TodoRecipies = new List<Recipe>();
        CompletedRecipies = new List<CompletedRecipe>();

        _salt = salt;
        Rfc2898DeriveBytes key = new(unhashed_password, _salt, 1000);
        _password = key.GetBytes(32);
    }

    private User() { }

    public bool ResetPassword(string old_password, string new_password) {
        if (SamePassword(old_password)) {
            _salt = GenerateSalt();
            Rfc2898DeriveBytes key = new(new_password, _salt, 1000);
            _password = key.GetBytes(32);
            return true;
        }

        return false;
    }

    public bool ChangeName(string password, string new_name) {
        if (SamePassword(password)) {
            try {
                Name = new_name;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        return false;
    }

    public bool ChangeDescription(string password, string new_description) {
        if (SamePassword(password)) {
            try {
                Description = new_description;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        return false;
    }

    public bool ChangeProfilePicture(string password, string profile_picture_path) {
        if (SamePassword(password)) {
            try {
                ProfilePicturePath = profile_picture_path;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        return false;
    }

    public bool RemoveDescription(string password) {
        if (SamePassword(password)) {
            try {
                Description = null;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        return false;
    }

    public bool RemoveProfilePicture(string password) {
        if (SamePassword(password)) {
            try {
                ProfilePicturePath = null;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        return false;
    }

    public bool ChangeCurrentCountry(string password, Country new_country) {
        if (SamePassword(password)) {
            try {
                CountryCurrent = new_country;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        return false;
    }

    public bool Authenticate(string password) {
        if (SamePassword(password)) {
            _is_authenticated = true;
            return true;
        }
        return false;
    }

    public void Logout() {
        _is_authenticated = false;
    }

    public bool SamePassword(string password_to_compare) {
        Rfc2898DeriveBytes key = new(password_to_compare, _salt, 1000);
        byte[] password_hash = key.GetBytes(32);

        for (int i = 0; i < password_hash.Length; i++) {
            if (password_hash[i] != _password[i]) {
                return false;
            }
        }
        if (password_hash.Length == _password.Length)
            return true;
        return false;
    }

    public static byte[] GenerateSalt() {
        byte[] salt = new byte[8];
        using RNGCryptoServiceProvider rngCsp = new();
        rngCsp.GetBytes(salt);
        return salt;
    }

    public void AddToFavouriteRecipies(Recipe recipe) {
        AddRecipe(FavouriteRecipies, recipe);
    }

    public void AddToTodoRecipies(Recipe recipe) {
        AddRecipe(TodoRecipies, recipe);
    }

    public void RemoveFromFavouriteRecipies(Recipe recipe) {
        RemoveRecipe(FavouriteRecipies, recipe);
    }

    public void RemoveFromTodoRecipies(Recipe recipe) {
        RemoveRecipe(TodoRecipies, recipe);
    }

    public void AddCompletedRecipe(CompletedRecipe recipe) {
        CompletedRecipies.Add(recipe);
    }

    public void RemoveompletedRecipe(CompletedRecipe recipe) {
        CompletedRecipies.Remove(recipe);
    }

    private static void AddRecipe(List<Recipe> list, Recipe recipe) {
        list.Add(recipe);
    }

    private static void RemoveRecipe(List<Recipe> list, Recipe recipe) {
        list.Remove(recipe);
    }
}
