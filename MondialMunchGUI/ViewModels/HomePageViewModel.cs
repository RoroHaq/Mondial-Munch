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

        public HomePageViewModel() {
            greet = "Welcome to Mondial Munch " + MondialMunchService.GetInstance().CurrentUser!.Name + "!";
        }
    }
}
