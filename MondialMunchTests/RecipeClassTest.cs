namespace MondialMunchTests;

using Recipe;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void RecipeClassPasses()
    {
        User CreatorTest= new User();
        Recipe RecipeTest= new Recipe("Biryani");
    }
}