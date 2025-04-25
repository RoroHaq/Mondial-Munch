using System.ComponentModel.DataAnnotations.Schema;

namespace MondialMunch;

public class DietaryTag {
    public int Id { get; private set; }
    public string Tag { get; private set; }

    public DietaryTag(string tag) {
        Tag = tag;
    }
    private DietaryTag() { }

    [InverseProperty("Tags")]
    public List<Recipe> TaggedRecipes;

    public override string ToString() {
        return Tag;
    }

    public override bool Equals(object? obj) {
        DietaryTag c = (DietaryTag)obj;
        return Tag.Equals(c.Tag);
    }
}
