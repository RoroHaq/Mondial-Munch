using System.ComponentModel.DataAnnotations;

namespace MondialMunch;

[TestClass]
public class UserClassTest {
    [TestMethod]
    public void UserInitialization() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());
    }

    [ExpectedException(typeof(ArgumentNullException))]
    [TestMethod]
    public void UserClassInvalidNameIsNull() {
        User testUser = new(null, "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());
    }

    [ExpectedException(typeof(ArgumentNullException))]
    [TestMethod]
    public void UserClassInvalidNameIsBlank() {
        User testUser = new("", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());
    }

    [ExpectedException(typeof(ArgumentNullException))]
    [TestMethod]
    public void UserClassInvalidNameIsWhiteSpace() {
        User testUser = new(" ", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());
    }

    [ExpectedException(typeof(ValidationException))]
    [TestMethod]
    public void UserClassInvalidNameTooLong() {
        User testUser = new("Johnaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());
    }

    [ExpectedException(typeof(ValidationException))]
    [TestMethod]
    public void UserClassInvalidDescriptionTooLong() {
        string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam ligula eros, sollicitudin ut sapien ac, viverra posuere justo. Aenean blandit, felis pellentesque vulputate eleifend, est lorem hendrerit ligula, eu dapibus urna enim at mi. Aliquam eu ligula placerat, molestie urna nec, finibus neque. Praesent imperdiet risus purus, sed egestas velit ultricies quis. Mauris quam ligula, euismod et ornare et, tristique in nisl. Morbi blandit commodo libero. Nullam tristique scelerisque massa ut vestibulum. Nulla a tortor quam. Maecenas egestas augue vitae venenatis tristique. Fusce a felis non erat facilisis tristique. Phasellus nec dui et tellus aliquam commodo. Morbi nisl nulla, mattis eget dui id, cursus ultricies justo. Nulla non eros hendrerit, rutrum orci vel, blandit dolor. Phasellus sit amet nisl laoreet, cursus nisi vitae, vehicula neque. Duis iaculis lorem eget laoreet vestibulum. Suspendisse consectetur tellus in consequat rhoncus. Sed lacus massa, volutpat vel consectetur sed, lacinia sit amet lacus. In tincidunt nunc velit, eu bibendum sapien sollicitudin at. Nulla pharetra fermentum accumsan. Nunc id sem quis nisl tristique imperdiet sit amet eu magna. Curabitur feugiat sem ipsum, aliquet porttitor enim varius a. Aliquam vestibulum mi sit amet leo iaculis, vitae luctus risus pulvinar. Mauris a mauris non ex vestibulum aliquet. Quisque nec turpis euismod, aliquam sapien eu, ultrices risus. Quisque ullamcorper tristique tempus. Pellentesque interdum ullamcorper viverra. Aliquam erat volutpat. Nullam sit amet lorem sit amet lorem dictum dictum. Vestibulum fermentum ultricies elementum. Ut eget lorem vel mauris egestas volutpat ac non orci. Vestibulum gravida mollis enim eu feugiat. Nunc nulla nisl, accumsan id mauris in, tristique lacinia dolor. Duis luctus, ipsum eget pharetra dignissim, ipsum ex consequat metus, sed molestie odio eros non nisl. Praesent dolor ante, ultrices eget mi egestas, molestie dignissim purus. Morbi id lectus et lorem consequat tempus at ut risus. Mauris scelerisque dui nisl, non gravida libero tincidunt a. Fusce porta aliquet metus ornare ultricies. Nulla sed odio risus. Nunc eget mollis metus, non posuere ante. Nunc finibus dui id elit vehicula, eu varius leo scelerisque. Nam odio ex, faucibus sit amet iaculis id, luctus at turpis. Donec in ultricies elit, ac ullamcorper metus. Duis congue ligula vitae sagittis commodo. Mauris id blandit orci. Vivamus a sapien lectus. Fusce auctor, urna eu volutpat tristique, orci ex vehicula lacus, a rhoncus ex mi eget libero. Vivamus feugiat iaculis dui. Quisque pharetra turpis quis commodo rhoncus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Praesent pellentesque dolor urna, in lacinia eros faucibus placerat. Curabitur molestie sagittis sapien, nec commodo ipsum tincidunt sit amet. In quis lacus tincidunt, auctor augue et, tincidunt nunc. Nulla id erat eget lorem tincidunt lobortis. Vestibulum rutrum libero vel justo euismod, eget scelerisque turpis euismod. Aliquam euismod felis sem, eget maximus orci dapibus a. Proin posuere venenatis purus, quis interdum augue mattis ut. Proin at arcu vitae nisi luctus porttitor sed non nunc. Nulla sapien est, bibendum ac sagittis dapibus, varius vitae dui. Donec porta accumsan est sed congue. Donec quis ex magna. Aliquam auctor fermentum ipsum et porttitor. Vestibulum lectus turpis, vulputate a semper ut, lobortis sit amet nisi. Quisque fringilla varius elit euismod dapibus. In volutpat lobortis elit, sed sodales velit elementum quis. Curabitur at felis vitae nisl pharetra aliquet.Curabitur eu suscipit libero, at convallis mauris. Aenean lacus justo, venenatis euismod consectetur at, gravida sodales nisl. Etiam quis egestas augue, nec hendrerit purus. Quisque commodo tincidunt augue eu fringilla. Nunc ante augue, hendrerit eget purus quis, viverra aliquam sem. Sed a eros et urna semper placerat ut non sem. Vestibulum feugiat tristique tristique. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec fermentum turpis. Nunc blandit lacus vitae ultrices lobortis. Duis quis sem laoreet, fringilla dui sed, maximus nisi. In quis urna tortor. Praesent sodales mollis massa ac pulvinar. Vestibulum ante quam, congue ac euismod non, eleifend ac odio. Maecenas eget bibendum ex. Pellentesque feugiat erat lectus, ut vestibulum neque volutpat sed. Donec condimentum blandit varius. Ut id purus nunc. Vivamus egestas iaculis ullamcorper. Quisque et sollicitudin massa. Quisque lorem ex, malesuada eget felis eu, semper tincidunt purus. Morbi lobortis sapien quis neque egestas, in dapibus ex egestas.In at mauris mollis, pretium sem vel, gravida est. Nullam nunc nisl, efficitur eu arcu et, sodales varius nunc. Donec vel erat vel nunc fermentum elementum vitae interdum nulla. Fusce non purus eget enim congue blandit at sed dui. Nam quis interdum sapien. Sed pulvinar ex vel metus hendrerit imperdiet. Integer a ligula quis nibh ultrices iaculis vitae quis metus.Fusce in purus nec metus condimentum consequat sit amet sed tellus. Vestibulum eu orci eget ex sagittis varius. Phasellus nec quam nec turpis mollis laoreet. Nunc fermentum vulputate convallis. Ut vitae libero eu risus viverra tristique. Mauris lacinia tristique porta. Nulla sodales odio eget purus egestas facilisis. Maecenas rutrum metus ac nunc rutrum, ac vulputate metus malesuada. Morbi accumsan felis non leo euismod, at vulputate lacus pharetra. Aenean a odio ex.";
        User testUser = new("Nathan", "img/something.png", description,
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());
    }

    [TestMethod]
    public void ResetPasswordTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.ResetPassword("password123", "hello123") != true) {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ResetPasswordInavlidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.ResetPassword("password124", "hello123") == true) {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ChangeNameTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.ResetPassword("password123", "Nathaniel") != true) {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ChangeNameInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.ChangeName("password124", "Nathaniel") == true) {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ChangeNameInvalidName() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.ChangeName("password123", " ") == true) {
            Assert.Fail();
        }
    }
}
