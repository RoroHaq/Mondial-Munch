using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;
using MondialMunchGUI.Views;

namespace MondialMunchGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    private ViewModelBase _contentViewModel;

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
            ContentViewModel = RegisterPage;
        });

        RegisterPage.Register.Subscribe((user) => {
            if (user != null) {
                MondialMunchService.GetInstance().AddUser(user);
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
        MondialMunchService.GetInstance().CurrentUser = user;
        PrimaryPageViewModel mainPage = new();
        ContentViewModel = mainPage;
    }
}



