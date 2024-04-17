using System.ComponentModel.DataAnnotations;
namespace MondialMunch;

public class Country {
    public readonly string Name;
    public Country(string name) {
        Name = name;
    }

    public override string ToString() {
        return Name;
    }

    public override bool Equals(object? obj) {
        Country c = (Country)obj;
        return Name.Equals(c.Name);
    }
}
