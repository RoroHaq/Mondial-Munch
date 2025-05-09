using Microsoft.EntityFrameworkCore;

namespace MondialMunch;

[Index(nameof(Name), IsUnique = true)]
public class Country {
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public List<MondialMunchEvent>? Events;

    public Country(string name) {
        Name = name;
    }
    private Country() { }

    public override string ToString() {
        return Name;
    }

    public override bool Equals(object? obj) {
        if (obj is string v) {
            return Name == v;
        }
        else if (obj is Country c) {
            return Name == c.Name;
        }
        return false;
    }

    public static string MakeGuiMapCssForCountries(List<Country> countries, string colorCode) {
        return string.Join(" ", countries.Select(c => string.Format("[id='{0}']{{ fill: {1}; }}", c, colorCode)));
    }
}
