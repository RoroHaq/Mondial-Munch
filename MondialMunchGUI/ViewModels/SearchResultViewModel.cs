using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using System;
using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive;

namespace MondialMunchGUI.ViewModels {
    public class SearchResultViewModel : ViewModelBase {
        public ReactiveCommand<Recipe, Recipe> ViewRecipe { get; }

        private List<Recipe> _recipes;
        private Country _country;
        private int _minServings;

        private int _maxServing;
        private double _minTime;
        private double _maxTime;



        public Country Country {
            get => _country;
            set => this.RaiseAndSetIfChanged(ref _country, value);
        }

        public int MinServing {
            get => _minServings;
            set => this.RaiseAndSetIfChanged(ref _minServings, value);
        }

        public int MaxServing {
            get => _maxServing;
            set => this.RaiseAndSetIfChanged(ref _maxServing, value);
        }

        public double MinTime {
            get => _minTime;
            set => this.RaiseAndSetIfChanged(ref _minTime, value);
        }

        public double MaxTime {
            get => _maxTime;
            set => this.RaiseAndSetIfChanged(ref _maxTime, value);
        }

        public List<Recipe> Recipes {
            get => _recipes;
            set => this.RaiseAndSetIfChanged(ref _recipes, value);
        }

        public List<Country> Countries { get; }
        public List<User> Users;

        public List<string> Usernames = new List<string>();

        public List<string> CountryNames = new List<string>();
        public ReactiveCommand<Unit, Unit> Filter { get; }

        public SearchResultViewModel(IEnumerable<Recipe> recipes) {

            Countries = MondialMunchService.GetInstance().GetCountries();

            Users = MondialMunchService.GetInstance().GetUsers();

            foreach (User user in Users) {
                Usernames.Add(user.Name);
            }

            foreach (Country country in Countries) {
                CountryNames.Add(country.Name);
            }

            Recipes = new List<Recipe>(recipes);

            ViewRecipe = ReactiveCommand.Create((Recipe recipe) => {
                return recipe;
            });

            Filter = ReactiveCommand.Create(() => {
                List<Recipe> RecipesFound = MondialMunchService.GetInstance().GetRecipes();
                RecipeList FilteredRecipe = new RecipeList(RecipesFound);

                if (MinServing > 0) {
                    FilteredRecipe.FilterByMinServings(MinServing);
                }
                if (MaxServing > 0) {
                    FilteredRecipe.FilterByMaxServings(MaxServing);
                }
                if (MinTime > 0) {
                    FilteredRecipe.FilterByMinTime(MinTime);
                }
                if (MaxTime > 0) {
                    FilteredRecipe.FilterByMaxTime(MaxTime);
                }

                Recipes = new(FilteredRecipe.Recipes);
            });
        }
    }
}
