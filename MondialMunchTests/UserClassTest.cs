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

        Assert.IsTrue(testUser.ResetPassword("password123", "hello123"));
    }

    [TestMethod]
    public void ResetPasswordInavlidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.ResetPassword("password124", "hello123") == true);
    }

    [TestMethod]
    public void ChangeNameTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsTrue(testUser.ChangeName("password123", "Nathaniel"));
    }

    [TestMethod]
    public void ChangeNameInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.ChangeName("password124", "Nathaniel"));
    }

    [TestMethod]
    public void ChangeNameInvalidName() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.ChangeName("password123", " "));
    }

    [TestMethod]
    public void ChangeDescriptionTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsTrue(testUser.ChangeDescription("password123", "Frankly I'm just very tired."));
    }

    [TestMethod]
    public void ChangeDescriptionInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.ChangeDescription("password124", "Frankly I'm just very tired."));
    }

    [TestMethod]
    public void ChangeDescriptionInvalidDescription() {
        string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam ligula eros, sollicitudin ut sapien ac, viverra posuere justo. Aenean blandit, felis pellentesque vulputate eleifend, est lorem hendrerit ligula, eu dapibus urna enim at mi. Aliquam eu ligula placerat, molestie urna nec, finibus neque. Praesent imperdiet risus purus, sed egestas velit ultricies quis. Mauris quam ligula, euismod et ornare et, tristique in nisl. Morbi blandit commodo libero. Nullam tristique scelerisque massa ut vestibulum. Nulla a tortor quam. Maecenas egestas augue vitae venenatis tristique. Fusce a felis non erat facilisis tristique. Phasellus nec dui et tellus aliquam commodo. Morbi nisl nulla, mattis eget dui id, cursus ultricies justo. Nulla non eros hendrerit, rutrum orci vel, blandit dolor. Phasellus sit amet nisl laoreet, cursus nisi vitae, vehicula neque. Duis iaculis lorem eget laoreet vestibulum. Suspendisse consectetur tellus in consequat rhoncus. Sed lacus massa, volutpat vel consectetur sed, lacinia sit amet lacus. In tincidunt nunc velit, eu bibendum sapien sollicitudin at. Nulla pharetra fermentum accumsan. Nunc id sem quis nisl tristique imperdiet sit amet eu magna. Curabitur feugiat sem ipsum, aliquet porttitor enim varius a. Aliquam vestibulum mi sit amet leo iaculis, vitae luctus risus pulvinar. Mauris a mauris non ex vestibulum aliquet. Quisque nec turpis euismod, aliquam sapien eu, ultrices risus. Quisque ullamcorper tristique tempus. Pellentesque interdum ullamcorper viverra. Aliquam erat volutpat. Nullam sit amet lorem sit amet lorem dictum dictum. Vestibulum fermentum ultricies elementum. Ut eget lorem vel mauris egestas volutpat ac non orci. Vestibulum gravida mollis enim eu feugiat. Nunc nulla nisl, accumsan id mauris in, tristique lacinia dolor. Duis luctus, ipsum eget pharetra dignissim, ipsum ex consequat metus, sed molestie odio eros non nisl. Praesent dolor ante, ultrices eget mi egestas, molestie dignissim purus. Morbi id lectus et lorem consequat tempus at ut risus. Mauris scelerisque dui nisl, non gravida libero tincidunt a. Fusce porta aliquet metus ornare ultricies. Nulla sed odio risus. Nunc eget mollis metus, non posuere ante. Nunc finibus dui id elit vehicula, eu varius leo scelerisque. Nam odio ex, faucibus sit amet iaculis id, luctus at turpis. Donec in ultricies elit, ac ullamcorper metus. Duis congue ligula vitae sagittis commodo. Mauris id blandit orci. Vivamus a sapien lectus. Fusce auctor, urna eu volutpat tristique, orci ex vehicula lacus, a rhoncus ex mi eget libero. Vivamus feugiat iaculis dui. Quisque pharetra turpis quis commodo rhoncus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Praesent pellentesque dolor urna, in lacinia eros faucibus placerat. Curabitur molestie sagittis sapien, nec commodo ipsum tincidunt sit amet. In quis lacus tincidunt, auctor augue et, tincidunt nunc. Nulla id erat eget lorem tincidunt lobortis. Vestibulum rutrum libero vel justo euismod, eget scelerisque turpis euismod. Aliquam euismod felis sem, eget maximus orci dapibus a. Proin posuere venenatis purus, quis interdum augue mattis ut. Proin at arcu vitae nisi luctus porttitor sed non nunc. Nulla sapien est, bibendum ac sagittis dapibus, varius vitae dui. Donec porta accumsan est sed congue. Donec quis ex magna. Aliquam auctor fermentum ipsum et porttitor. Vestibulum lectus turpis, vulputate a semper ut, lobortis sit amet nisi. Quisque fringilla varius elit euismod dapibus. In volutpat lobortis elit, sed sodales velit elementum quis. Curabitur at felis vitae nisl pharetra aliquet.Curabitur eu suscipit libero, at convallis mauris. Aenean lacus justo, venenatis euismod consectetur at, gravida sodales nisl. Etiam quis egestas augue, nec hendrerit purus. Quisque commodo tincidunt augue eu fringilla. Nunc ante augue, hendrerit eget purus quis, viverra aliquam sem. Sed a eros et urna semper placerat ut non sem. Vestibulum feugiat tristique tristique. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec fermentum turpis. Nunc blandit lacus vitae ultrices lobortis. Duis quis sem laoreet, fringilla dui sed, maximus nisi. In quis urna tortor. Praesent sodales mollis massa ac pulvinar. Vestibulum ante quam, congue ac euismod non, eleifend ac odio. Maecenas eget bibendum ex. Pellentesque feugiat erat lectus, ut vestibulum neque volutpat sed. Donec condimentum blandit varius. Ut id purus nunc. Vivamus egestas iaculis ullamcorper. Quisque et sollicitudin massa. Quisque lorem ex, malesuada eget felis eu, semper tincidunt purus. Morbi lobortis sapien quis neque egestas, in dapibus ex egestas.In at mauris mollis, pretium sem vel, gravida est. Nullam nunc nisl, efficitur eu arcu et, sodales varius nunc. Donec vel erat vel nunc fermentum elementum vitae interdum nulla. Fusce non purus eget enim congue blandit at sed dui. Nam quis interdum sapien. Sed pulvinar ex vel metus hendrerit imperdiet. Integer a ligula quis nibh ultrices iaculis vitae quis metus.Fusce in purus nec metus condimentum consequat sit amet sed tellus. Vestibulum eu orci eget ex sagittis varius. Phasellus nec quam nec turpis mollis laoreet. Nunc fermentum vulputate convallis. Ut vitae libero eu risus viverra tristique. Mauris lacinia tristique porta. Nulla sodales odio eget purus egestas facilisis. Maecenas rutrum metus ac nunc rutrum, ac vulputate metus malesuada. Morbi accumsan felis non leo euismod, at vulputate lacus pharetra. Aenean a odio ex.";

        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.ChangeDescription("password123", description));
    }

    [TestMethod]
    public void ChangeProfilePictureTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.ChangeProfilePicture("password123", "img/somethingelse.png") == true) {
            Assert.AreEqual("img/somethingelse.png", testUser.ProfilePicturePath);
        }
        else {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ChangeProfilePictureInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.ChangeProfilePicture("password124", "img/somethingelse.png"));
    }

    [TestMethod]
    public void RemoveDescriptionTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.RemoveDescription("password123") != true) {
            Assert.Fail();
        }

        Assert.AreEqual(null, testUser.Description);
    }

    [TestMethod]
    public void RemoveDescriptionInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.RemoveDescription("password124"));
    }

    [TestMethod]
    public void RemoveProfilePictureTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.RemoveProfilePicture("password123") != true) {
            Assert.Fail();
        }

        Assert.AreEqual(null, testUser.ProfilePicturePath);
    }

    [TestMethod]
    public void RemoveProfilePictureInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.RemoveProfilePicture("password124"));
    }

    [TestMethod]
    public void ChangeCurrentCountryPictureTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        if (testUser.ChangeCurrentCountry("password123", Country.United_States) != true) {
            Assert.Fail();
        }

        Assert.AreEqual(Country.United_States, testUser.CountryCurrent);
    }

    [TestMethod]
    public void ChangeCurrentCountryInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.ChangeCurrentCountry("password124", Country.United_States));
    }

    [TestMethod]
    public void SamePasswordTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsTrue(testUser.SamePassword("password123"));
    }

    [TestMethod]
    public void SamePasswordInvalidLength() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.SamePassword(""));
    }

    [TestMethod]
    public void SamePasswordInvalidPassword() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        Assert.IsFalse(testUser.SamePassword("password124"));
    }

    [TestMethod]
    public void AddToFavouriteRecipiesTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        List<string> steps = new() {
            "1. Get out your meat",
            "2. Add in seasoning"
        };

        List<Ingredient> ingredients = new() {
            new Ingredient("Groudn Beef", 2),
            new Ingredient("Taco seasoning", 1)
        };

        Recipe recipe = new("Tacos", testUser, "made in the depths of hell", 5, 3, 15,
                            Country.Mexico, steps, ingredients);

        testUser.AddToFavouriteRecipies(recipe);

        Assert.AreEqual(true, testUser.FavouriteRecipies.Contains(recipe));
    }

    [TestMethod]
    public void RemoveFromFavouriteRecipiesTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        List<string> steps = new() {
            "1. Get out your meat",
            "2. Add in seasoning"
        };

        List<Ingredient> ingredients = new() {
            new Ingredient("Groudn Beef", 2),
            new Ingredient("Taco seasoning", 1)
        };

        Recipe recipe = new("Tacos", testUser, "made in the depths of hell", 5, 3, 15,
                            Country.Mexico, steps, ingredients);

        testUser.AddToFavouriteRecipies(recipe);
        testUser.RemoveFromFavouriteRecipies(recipe);

        Assert.AreEqual(false, testUser.FavouriteRecipies.Contains(recipe));
    }

    [TestMethod]
    public void AddToTodoRecipiesTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        List<string> steps = new() {
            "1. Get out your meat",
            "2. Add in seasoning"
        };

        List<Ingredient> ingredients = new() {
            new Ingredient("Groudn Beef", 2),
            new Ingredient("Taco seasoning", 1)
        };

        Recipe recipe = new("Tacos", testUser, "made in the depths of hell", 5, 3, 15,
                            Country.Mexico, steps, ingredients);

        testUser.AddToTodoRecipies(recipe);

        Assert.AreEqual(true, testUser.TodoRecipies.Contains(recipe));
    }

    [TestMethod]
    public void RemoveFromTodoRecipiesTest() {
        User testUser = new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                            Country.Canada, Country.Canada, "password123", User.GenerateSalt());

        List<string> steps = new() {
            "1. Get out your meat",
            "2. Add in seasoning"
        };

        List<Ingredient> ingredients = new() {
            new Ingredient("Groudn Beef", 2),
            new Ingredient("Taco seasoning", 1)
        };

        Recipe recipe = new("Tacos", testUser, "made in the depths of hell", 5, 3, 15,
                            Country.Mexico, steps, ingredients);

        testUser.AddToTodoRecipies(recipe);
        testUser.RemoveFromTodoRecipies(recipe);

        Assert.AreEqual(false, testUser.TodoRecipies.Contains(recipe));
    }
}
