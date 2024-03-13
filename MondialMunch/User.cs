public class Users{

    private String _name { get; private set;}
    private String? _pfp_path { get; private set;}
    private String? _description { get; private set;}
    private Country _country_origin { get; private set;}
    private Country? _country_current { get; private set;}
    private byte[] _password { get; private set;}
    private Recipe[] _personal_recipes { get; set;}
    private Recipe[] _favourite_recipies { get; set;}
    private Recipe[] _todo_recipies { get; set;} 
    
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