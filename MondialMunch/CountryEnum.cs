using System.ComponentModel.DataAnnotations;
using MondialMunch;

public class Country
{
    private string _name;
    public string Name
    {
        get { return _name; }
        internal set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Country name is either null, has an Empty String or its a white space");
            }

            _name = value;
        }
    }
    public Country(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
