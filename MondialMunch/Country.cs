using System.ComponentModel.DataAnnotations;
namespace MondialMunch;

public class Country {
    private readonly string Name;
    public Country(string name) {
        Name = name;
    }

    public override string ToString() {
        return Name;
    }
}
