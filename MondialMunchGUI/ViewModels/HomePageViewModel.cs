using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;


namespace MondialMunchGUI.ViewModels {
    public class HomePageViewModel : ViewModelBase {

        public string greet { get; set; }

        public HomePageViewModel(User user) {
            greet = "Welcome to Mondial Munch " + user.Name + "!";

            ListUsers = new(){
            new User("Nathan", "w", "d", new Country("Canadia"), new Country("Canadia"), "Hello", User.GenerateSalt()),
            new User("John", "w", "d", new Country("Canadia"), new Country("Canadia"), "Hello", User.GenerateSalt()),
            new User("Pauk", "w", "d", new Country("Canadia"), new Country("Canadia"), "Hello", User.GenerateSalt()),
            new User("Among Us", "w", "d", new Country("Canadia"), new Country("Canadia"), "Hello", User.GenerateSalt()),
            new User("Cath", "w", "d", new Country("Canadia"), new Country("Canadia"), "Hello", User.GenerateSalt())
      };
        }

        public ObservableCollection<User> ListUsers { get; }
    }
}
