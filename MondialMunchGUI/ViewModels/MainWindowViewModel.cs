using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;

namespace MondialMunchGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel() {

        // MondialMunchContext context = new();
        // MondialMunchService service = new(context);

        // List<User> Users2 = service.GetUsers();
        List<User> Users2 = new(){
            new User("Nathan", "w", "d", new Country("Canadia"), new Country("Canadia"), "Hello", User.GenerateSalt())
        };

        LoginPage = new LoginPageViewModel(Users2);
        RegisterPage = new RegisterPageViewModel(Users2);

        LoginPage.Login.Subscribe(user => {
            if (user != null) {
                User? loggedInUser = new("Nathan", "w", "d", new Country("Canadia"), new Country("Canadia"), "Hello", User.GenerateSalt());
                //service.GetUserByUsername(user.Name);
                LoginUser(loggedInUser);
            }
        });

        LoginPage.Register.Subscribe((u) => {
            ContentViewModel = RegisterPage;
        });

        RegisterPage.Register.Subscribe((user) => {
            if (user != null) {
                // service.AddUser(user);
                LoginUser(user);
            }
        });

        RegisterPage.Back.Subscribe((u) => {
            ContentViewModel = LoginPage;
        });

        ContentViewModel = LoginPage;
    }

    public LoginPageViewModel LoginPage { get; }
    public RegisterPageViewModel RegisterPage { get; }

    public ViewModelBase ContentViewModel {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void LoginUser(User user) {
        HomePageViewModel homePage = new HomePageViewModel(user);

        ContentViewModel = homePage;
    }
}



