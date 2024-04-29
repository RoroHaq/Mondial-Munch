namespace MondialMunch;
using Microsoft.EntityFrameworkCore;
using Moq;

[TestClass]
public class MondialMunchServiceTest {

    public User MakeTestUser() {
        return new("Safin", "img/something.png", "I am Safin.",
                            new Country("Mexico"), new Country("Canada"), "password123", User.GenerateSalt());
    }

    public Recipe MakeTestRecipe(User creator) {
        return new("Poutine", creator, "Iconic Canadian dish", 1, 10, 10, new Country("Canada"),
                new List<RecipeInstruction> {
                    new("Peel potatoes"),
                    new("Slice potatoes"),
                    new("Place potatoes in fryer"),
                    new("Put gravy"),
                    new("Put cheese")
                },
                new List<Ingredient> { new("Potato", 6), new("Gravy", 1), new("Cheese", 12) });
    }

    [TestMethod]
    public void AddUserTestIsAuthenticated() {
        //Arrange
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<MondialMunchContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        var service = new MondialMunchService(mockContext.Object);

        var testUser = MakeTestUser();
        testUser.Authenticate("password123");

        //Act
        service.AddUser(testUser);

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void AddUserTestIsNotAuthenticated() {
        //Arrange
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<MondialMunchContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        var service = new MondialMunchService(mockContext.Object);

        var testUser = MakeTestUser();

        //Act
        service.AddUser(testUser);

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void AddRecipeTest() {
        //Arrange
        var mockSet = new Mock<DbSet<Recipe>>();
        var mockContext = new Mock<MondialMunchContext>();
        mockContext.Setup(m => m.Recipes).Returns(mockSet.Object);
        var service = new MondialMunchService(mockContext.Object);

        var testUser = MakeTestUser();
        testUser.Authenticate("password123");
        service.CurrentUser = testUser;
        var testRecipe = MakeTestRecipe(testUser);

        //Act
        service.AddRecipe(testRecipe);

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<Recipe>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void DeleteUserTest() {
        //Arrange
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<MondialMunchContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        var service = new MondialMunchService(mockContext.Object);

        var testUser = MakeTestUser();
        testUser.Authenticate("password123");
        service.AddUser(testUser);
        service.CurrentUser = testUser;

        //Act
        service.DeleteUser(testUser);

        //Assert
        mockSet.Verify(m => m.Remove(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Exactly(2));
    }
}
