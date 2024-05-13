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
        public ReactiveCommand<Unit, Unit> LogOut { get; }
        public ObservableCollection<User> ListUsers { get; }

        private bool _isPaneOpen;

        public bool IsPaneOpen {
            get => _isPaneOpen;
            set => _ = this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
        }


        public void PanelToggle() {
            IsPaneOpen = !IsPaneOpen;
        }
        public HomePageViewModel() {
            greet = "Welcome to Mondial Munch " + MondialMunchService.GetInstance().CurrentUser!.Name + "!";
        }
    }
}
