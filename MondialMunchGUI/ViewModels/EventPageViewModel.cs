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
        public ObservableCollection<Tuple<Country, bool>> ListCountries { get; }
        public int DaysLeft { get; private set; }
        public List<Tuple<Country, bool>> EventCountries = new List<Tuple<Country, bool>>(){
                new Tuple<Country, bool>(new("Italy"), false),
                new Tuple<Country, bool>(new("Greece"), false),
                new Tuple<Country, bool>(new("Turkey"), false),
                new Tuple<Country, bool>(new("Iran"), false),
                new Tuple<Country, bool>(new("India"), false),
                new Tuple<Country, bool>(new("China"), false),
                new Tuple<Country, bool>(new("Syria"), false),
                new Tuple<Country, bool>(new("Lebannon"), false),
                new Tuple<Country, bool>(new("Jordan"), false),
                new Tuple<Country, bool>(new("Israel"), false)
        };

        public EventPageViewModel() {

            DateTime Today = DateTime.Today;
            DateTime DueDate = new DateTime(2024, 06, 1);
            DaysLeft = (DueDate - Today).Days;

            ListCountries = new ObservableCollection<Tuple<Country, bool>>(EventCountries);
        }
    }
}
