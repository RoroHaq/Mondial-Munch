using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;
using System.Linq;


namespace MondialMunchGUI.ViewModels {
    public class HomePageViewModel : ViewModelBase {
        public ReactiveCommand<Unit, Unit> LogOut { get; }
        public ObservableCollection<User> ListUsers { get; }

        public HomePageViewModel() {
        }
    }
}
