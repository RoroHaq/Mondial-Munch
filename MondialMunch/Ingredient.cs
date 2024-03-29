

using System.ComponentModel.DataAnnotations;

public class Ingredient{
    public string _name;
    public int _quantity;

    public Ingredient(string name, int quantity){
        _name= name;
        _quantity = quantity;
    }

    public string Name{
        get{return _name;}

        internal set{
            if(string.IsNullOrEmpty(_name) || string.IsNullOrWhiteSpace(_name)){
                throw new ArgumentNullException("Name is either null, an Empty String or blank");
            }
            else if(_name.Length > 50){
                throw new ValidationException("Name is too big");
            }
        }
    }

}   