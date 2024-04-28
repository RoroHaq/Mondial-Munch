

using System.ComponentModel.DataAnnotations;

public class Ingredient {
    public int Id { get; private set; }
    private string _name;
    private int _quantity;

    public Ingredient(string name, int quantity) {
        Name = name;
        Quantity = quantity;
    }

    private Ingredient() { }

    public string Name {
        get { return _name; }

        internal set {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException("Name is either null, an Empty String or blank");
            }
            else if (value.Length > 50) {
                throw new ArgumentException("Name is too big");
            }

            _name = value;
        }
    }

    public int Quantity {
        get { return _quantity; }

        internal set {
            if (value <= 0) {
                throw new ArgumentException("Ingredient Quantity cannot be 0 or any less");
            }

            _quantity = value;
        }
    }

}
