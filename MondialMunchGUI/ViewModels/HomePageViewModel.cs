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

        private string? _search;
        public ReactiveCommand<Unit, Unit> LogOut { get; }
        public ObservableCollection<User> ListUsers { get; }

        public ReactiveCommand<Unit, IEnumerable<Recipe>> Search { get; }

        private bool _isPaneOpen;

        public bool IsPaneOpen {
            get => _isPaneOpen;
            set => _ = this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
        }

        public string SearchInput {
            get => _search!;
            set => _ = this.RaiseAndSetIfChanged(ref _search, value);
        }


        public void PanelToggle() {
            IsPaneOpen = !IsPaneOpen;
        }
        public HomePageViewModel() {

            var isValidSearch = this.WhenAnyValue(
                x => x.SearchInput,
                x => !string.IsNullOrWhiteSpace(x)
            );
            Search = ReactiveCommand.Create(() => {
                List<Recipe> RecipesFound = MondialMunchService.GetInstance().GetRecipes();
                RecipeList FilteredRecipe = new RecipeList(RecipesFound);
                FilteredRecipe.FilterByKeyword(SearchInput);

                return FilteredRecipe.Recipes;
            }, isValidSearch);
        }
    }
}
