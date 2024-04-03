using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MondialMunch;
public class User {
    private string _name;
    public string Name {
        get { return _name; }
        private set {
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentNullException("Name is null or is an Empty String");
            }
            else if (value.Length > 50) {
                throw new ValidationException("Name is too long");
            }

            _name = value;
        }
    }
    public string? ProfilePicturePath { get; private set; }
    public string? Description { get; private set; }
    public Country CountryOrigin { get; private set; }
    public Country? CountryCurrent { get; private set; }
    private byte[] _password { get; set; }
    public List<Recipe> PersonalRecipes { get; internal set; }
    public List<Recipe> FavouriteRecipies { get; internal set; }
    public List<Recipe> TodoRecipies { get; internal set; }

    public User(string name, string profilePicturePath, string description, Country countryOrigin, Country? countryCurrent, byte[] password) {
        Name = name;
        ProfilePicturePath = profilePicturePath;
        Description = description;
        CountryOrigin = countryOrigin;
        CountryCurrent = countryCurrent;
        _password = password;
        PersonalRecipes = new List<Recipe>();
        FavouriteRecipies = new List<Recipe>();
        TodoRecipies = new List<Recipe>();
    }

    public bool ResetPassword(string old_password, string new_password) {
        byte[] old_password_hash = MD5.HashData(ASCIIEncoding.ASCII.GetBytes(old_password));
        bool same_passwords = true;
        for (int i = 0; i < old_password_hash.Length; i++) {
            if (old_password_hash[i] != _password[i]) {
                same_passwords = false;
                break;
            }
        }
        if (same_passwords && old_password_hash.Length == _password.Length) {
            _password = MD5.HashData(ASCIIEncoding.ASCII.GetBytes(new_password));
            return true;
        }

        return false;
    }

    public bool ChangeName(string password, string new_name) {
        byte[] password_hash = MD5.HashData(ASCIIEncoding.ASCII.GetBytes(password));
        bool same_passwords = true;
        for (int i = 0; i < password_hash.Length; i++) {
            if (password_hash[i] != _password[i]) {
                same_passwords = false;
                break;
            }
        }
        if (same_passwords && password_hash.Length == _password.Length) {
            try {
                Name = new_name;
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
        return false;
    }

    public void ChangeDescription() {
        throw new InvalidOperationException("Method Incomplete!");
    }

    public void ChangeCurrentCountry() {
        throw new InvalidOperationException("Method Incomplete!");
    }
}
