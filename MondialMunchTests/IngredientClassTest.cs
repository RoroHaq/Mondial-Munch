namespace MondialMunch;

[TestClass]
public class UnitTest1 {
  [TestMethod]
  public void IngredientClassWorks() {

    Ingredient ingredientTest = new Ingredient("Lettuce", 5);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void IngredientClassInvalidNameIsNull() {

    Ingredient ingredientTest = new Ingredient(null, 5);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void IngredientClassInvalidNameIsBlank() {

    Ingredient ingredientTest = new Ingredient("", 5);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void IngredientClassInvalidNameIsEmpty() {

    Ingredient ingredientTest = new Ingredient(" ", 5);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void IngredientClassInvalidQuantityIs0() {

    Ingredient ingredientTest = new Ingredient("taco", 0);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void IngredientClassInvalidQuantityIsNegative() {

    Ingredient ingredientTest = new Ingredient("taco", -5);
  }


}
