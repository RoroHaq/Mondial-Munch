public class User{

    public string Name { get; private set;}
    public string? ProfilePicturePath { get; private set;}
    public string? Description { get; private set;}
    public Country CountryOrigin { get; private set;}
    public Country? CountryCurrent { get; private set;}
    private byte[] _password { get; private set;}
    public List<Recipe> PersonalRecipes { get; internal set;}
    public List<Recipe> FavouriteRecipies { get; internal set;}
    public List<Recipe> TodoRecipies { get; internal set;} 
    
    public User(string name, string profilePicturePath, string description, Country countryOrigin, Country? countryCurrent, byte[] password){
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

    public void ResetPassword(){
        throw new InvalidOperationException("Method Incomplete!");
    }

    public void ChangeName(){
        throw new InvalidOperationException("Method Incomplete!");
    }
    
    public void ChangeDescription(){
        throw new InvalidOperationException("Method Incomplete!");
    }
    
    public void ChangeCurrentCountry(){
        throw new InvalidOperationException("Method Incomplete!");
    }
}