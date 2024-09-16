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
        public string ShortTitle { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int DaysLeft { get; private set; }
        public string DaysLeftText => DaysLeft > 0 ? "days left" : "days ago";
        public string EventProgressCssString { get; }

        public EventPageViewModel(string shortEventTitle, string EventTitle, DateTime StartDate, DateTime DueDate, List<Country> EventCountries, string EventDescription) {

            ShortTitle = shortEventTitle;
            Title = EventTitle;
            Description = EventDescription;

            DateTime Today = DateTime.Today;
            DaysLeft = (DueDate - Today).Days;

            List<Country> CompletedCountries = new() { };
            List<Tuple<Country?, bool>> EventCountriesList = new List<Tuple<Country?, bool>>();

            foreach (Country c in EventCountries) {
                bool complete = false;
                foreach (CompletedRecipe r in MondialMunchService.GetInstance().CurrentUser!.CompletedRecipies) {
                    if (r.RecipeCompleted.Country == c &&
                        StartDate <= r.DateCompleted) {
                        complete = true;
                        CompletedCountries.Add(c);
                        break;
                    }
                }

                EventCountriesList.Add(new Tuple<Country?, bool>(c, complete));
            }

            EventProgressCssString = Country.MakeGuiMapCssForCountries(EventCountries, "#ffac40") + " "
                                    + Country.MakeGuiMapCssForCountries(CompletedCountries, "#005aff");

            ListCountries = new ObservableCollection<Tuple<Country?, bool>>(EventCountriesList);
        }
    }
}
