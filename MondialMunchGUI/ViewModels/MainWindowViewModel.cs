using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;

namespace MondialMunchGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel() {
        // var service = new MondialMunchService(new MondialMunchContext());
        List<User> Users = new(){
            new("Nathan", "img/something.png", "Hello!, I'm Nathan.",
                                new Country("Canada"), new Country("Canada"), "password123", User.GenerateSalt()),
            new("Andrew", "img/something.png", "This is Andrew.",
                                new Country("Canada"), new Country("United States"), "password123", User.GenerateSalt()),
            new("Safin", "img/something.png", "I am Safin.",
                                new Country("Mexico"), new Country("Canada"), "password123", User.GenerateSalt())
        };
        UserList = new LoginPageViewModel(Users);
        _contentViewModel = UserList;
    }

    public LoginPageViewModel UserList { get; }

    public ViewModelBase ContentViewModel {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }
}
