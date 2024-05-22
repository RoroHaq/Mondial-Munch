using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;

namespace MondialMunchGUI.ViewModels {
    public class EventPageViewModel : ViewModelBase {

        public ReactiveCommand<Unit, User?> Login { get; }
        public ReactiveCommand<Unit, string?> Register { get; }
        private ObservableCollection<Tuple<Country?, bool>> _list_countries;
        public ObservableCollection<Tuple<Country?, bool>> ListCountries {
            get => _list_countries;
            set => this.RaiseAndSetIfChanged(ref _list_countries, value);
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int DaysLeft { get; private set; }
        public EventPageViewModel(string EventTitle, DateTime StartDate, DateTime DueDate, List<string> EventCountries, string EventDescription) {

            Title = EventTitle;
            Description = EventDescription;

            DateTime Today = DateTime.Today;
            DaysLeft = (DueDate - Today).Days;

            List<Tuple<Country?, bool>> EventCountriesList = new List<Tuple<Country?, bool>>();

            foreach (string c in EventCountries) {
                Country? NextCountry = MondialMunchService.GetInstance().GetCountryByName(c);
                bool complete = false;
                if (MondialMunchService.GetInstance().CurrentUser!.CompletedRecipies != null) {
                    foreach (CompletedRecipe r in MondialMunchService.GetInstance().CurrentUser!.CompletedRecipies) {
                        if (r.RecipeCompleted.Country == NextCountry &&
                            StartDate <= r.DateCompleted) {
                            complete = true;
                            break;
                        }
                    }
                }

                EventCountriesList.Add(new Tuple<Country?, bool>(NextCountry, complete));
            }

            ListCountries = new ObservableCollection<Tuple<Country?, bool>>(EventCountriesList);
        }
    }
}
