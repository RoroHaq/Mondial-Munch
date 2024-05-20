using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;
using MondialMunchGUI.Views;

namespace MondialMunchGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    private ViewModelBase _contentViewModel = null!;
    public LoginPageViewModel LoginPage { get; }
    public RegisterPageViewModel RegisterPage { get; }

    public HomePageViewModel HomePage { get; }

    public ViewModelBase ContentViewModel {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }
    public MainWindowViewModel() {
        LoginPage = new LoginPageViewModel();
        RegisterPage = new RegisterPageViewModel();
        HomePage = new HomePageViewModel();

        LoginPage.Login.Subscribe(user => {
            if (user != null) {
                User? loggedInUser = MondialMunchService.GetInstance().GetUserByUsername(user.Name);
                if (loggedInUser == null) return;
                LoginUser(loggedInUser, HomePage);
            }
        });

        LoginPage.Register.Subscribe((u) => {
            RegisterPage.Username = null!;
            RegisterPage.Password = null!;
            RegisterPage.CheckPassword = null!;
            RegisterPage.Description = null!;
            RegisterPage.CountryOrigin = null!;
            RegisterPage.CountryCurrent = null!;
            ContentViewModel = RegisterPage;
        });

        RegisterPage.Register.Subscribe((user) => {
            if (user != null) {
                MondialMunchService.GetInstance().AddUser(user);
                LoginUser(user, HomePage);
            }
        });

        RegisterPage.Back.Subscribe((u) => {
            LoginPage.Password = null!;
            ContentViewModel = LoginPage;
        });

        ContentViewModel = LoginPage;
    }
    public void LoginUser(User user, ViewModelBase model) {
        MondialMunchService.GetInstance().CurrentUser = user;
        PrimaryPageViewModel mainPage = new();
        ContentViewModel = mainPage;
    }

}



