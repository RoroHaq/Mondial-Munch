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

    public ViewModelBase ContentViewModel {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }
    public MainWindowViewModel() {
        LoginPage = new LoginPageViewModel();
        RegisterPage = new RegisterPageViewModel();

        LoginPage.Login.Subscribe(user => {
            if (user != null) {
                User? loggedInUser = MondialMunchService.GetInstance().GetUserByUsername(user.Name);
                if (loggedInUser == null) return;
                LoginUser(loggedInUser);
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
                LoginUser(user);
            }
        });

        RegisterPage.Back.Subscribe((u) => {
            LoginPage.Password = null!;
            ContentViewModel = LoginPage;
        });

        ContentViewModel = LoginPage;
    }

    public void LoginUser(User user) {
        MondialMunchService.GetInstance().CurrentUser = user;
        PrimaryPageViewModel MainPage = PrimaryPageViewModel.GetInstance();
        MainPage.LogOut.Subscribe((u) => {
            MondialMunchService.GetInstance().CurrentUser = null;
            PrimaryPageViewModel.ClearInstance();
            LoginPage.Username = null;
            LoginPage.Password = null;
            ContentViewModel = LoginPage;
        });

        ContentViewModel = MainPage;
    }
}
