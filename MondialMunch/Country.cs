namespace MondialMunch;

public class Country {
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Country(string name) {
        Name = name;
    }
    private Country() { }

    public override string ToString() {
        return Name;
    }

    public override bool Equals(object? obj) {
        // Country c = (Country)obj;
        // return Name.Equals(c.Name);
        return true;
    }
}
