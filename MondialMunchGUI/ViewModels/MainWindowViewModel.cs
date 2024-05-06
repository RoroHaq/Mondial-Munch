using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;

namespace MondialMunchGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel() {

        MondialMunchContext context = new();
        MondialMunchService service = new(context);

        List<User> Users2 = service.GetUsers();
        LoginPage = new LoginPageViewModel(Users2);
        RegisterPage = new RegisterPageViewModel(Users2);

        LoginPage.Login.Subscribe(user => {
            if (user != null) {
                User? loggedInUser = service.GetUserByUsername(user.Name);
                LoginUser(loggedInUser);
            }
        });

        LoginPage.Register.Subscribe((u) => {
            ContentViewModel = RegisterPage;
        });

        RegisterPage.Register.Subscribe((user) => {
            if (user != null) {
                service.AddUser(user);
                LoginUser(user);
            }
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



