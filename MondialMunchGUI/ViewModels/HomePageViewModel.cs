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
        public string CompletedCountriesCssString { get; }

        public HomePageViewModel() {
            User currentUser = MondialMunchService.GetInstance().CurrentUser!;
            List<Country> completedCountries = MondialMunchService.GetInstance().GetCompletedCountriesForUser(currentUser);
            CompletedCountriesCssString = Country.MakeGuiMapCssForCountries(completedCountries, "#005aff");
        }
    }
}
