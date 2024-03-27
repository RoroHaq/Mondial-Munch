

public class Ingredient{
    public string Name {get;}
    public int Quantity {get; internal set;}

    public Ingredient(string name, int quantity){
        Name= name;
        Quantity = quantity;
    }

}   