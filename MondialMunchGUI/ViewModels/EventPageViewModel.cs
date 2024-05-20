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
            // List<Country> EventCountries = new List<Country>(){
            //     new Country("Italy"),
            //     new Country("Greece"),
            //     new Country("Turkey"),
            //     new Country("Iran"),
            //     new Country("India"),
            //     new Country("China"),
            //     new Country("Syria"),
            //     new Country("Lebannon"),
            //     new Country("Jordan"),
            //     new Country("Israel"),
            // };

            ListCountries = new ObservableCollection<Tuple<Country, bool>>(EventCountries);
        }
    }
}
