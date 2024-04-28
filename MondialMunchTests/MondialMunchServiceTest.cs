namespace MondialMunch;
using Microsoft.EntityFrameworkCore;
using Moq;

[TestClass]
public class MondialMunchServiceTest {

    [TestMethod]
    public void AddUserTest() {
        //Arrange
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<MondialMunchContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        var service = new MondialMunchService(mockContext.Object);

        //Act
        service.AddUser(MockData.Users[0]);

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

        //Act
        service.AddRecipe(MockData.Recipes[0]);

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
        service.AddUser(MockData.Users[0]);

        //Act
        service.DeleteUser(MockData.Users[0]);

        //Assert
        mockSet.Verify(m => m.Remove(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Exactly(2));
    }

    [TestMethod]
    public void DeleteUserTestNoUser() { /*So I understand why this passes but it 
    shouldn't? At least I don't think so, it passes because it calls remove and no 
    error is thrown which makes sense but it's still odd behaviour no?*/
        //Arrange
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<MondialMunchContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        var service = new MondialMunchService(mockContext.Object);

        //Act
        service.DeleteUser(MockData.Users[0]);

        //Assert
        mockSet.Verify(m => m.Remove(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
}
