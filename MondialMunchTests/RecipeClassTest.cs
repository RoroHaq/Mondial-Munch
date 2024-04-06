namespace MondialMunch;



[TestClass]
public class RecipeClassTest {
    [TestMethod]
    public void RecipeClassPasses() {
        User testUser = new User("Safin", "img/something.png", "a guy who enjoys cooking",
                                Country.Canada, Country.Mexico, );
    }
}
