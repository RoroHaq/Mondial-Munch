using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;
using MondialMunchGUI.Views;
using Avalonia.Controls;
using System.Reactive;

namespace MondialMunchGUI.ViewModels;

public class PrimaryPageViewModel : ViewModelBase {
    private const int SIDEBAR_SIZE_OPEN = 200;

    private string? _search;
    private ViewModelBase _content = null!;
    private bool _isSideBarOpen = true;
    private GridLength _sideBarSize = new(SIDEBAR_SIZE_OPEN, GridUnitType.Pixel);

    public ReactiveCommand<Unit, bool> ToggleSideBar { get; }
    public ReactiveCommand<Unit, IEnumerable<Recipe>> Search { get; }
    public ReactiveCommand<Unit, Unit> SilkRoadButton { get; }
    public ReactiveCommand<Unit, Unit> BananaRepublicButton { get; }
    public ReactiveCommand<Unit, Unit> NewRecipe { get; }

    public ViewModelBase Content {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public bool IsSideBarOpen {
        get => _isSideBarOpen;
        private set => this.RaiseAndSetIfChanged(ref _isSideBarOpen, value);
    }

    public GridLength SideBarSize {
        get => _sideBarSize;
        private set => this.RaiseAndSetIfChanged(ref _sideBarSize, value);
    }

    public string SearchInput {
        get => _search!;
        set => this.RaiseAndSetIfChanged(ref _search, value);
    }

    public PrimaryPageViewModel() {
        Content = new HomePageViewModel();

        ToggleSideBar = ReactiveCommand.Create(
            () => {
                IsSideBarOpen = !IsSideBarOpen;
                SideBarSize = new(IsSideBarOpen ? SIDEBAR_SIZE_OPEN : 0, GridUnitType.Pixel);
                return IsSideBarOpen;
            }
        );

        var isValidSearch = this.WhenAnyValue(
            x => x.SearchInput,
            x => !string.IsNullOrWhiteSpace(x)
        );

        Search = ReactiveCommand.Create(() => {
            List<Recipe> RecipesFound = MondialMunchService.GetInstance().GetRecipes();
            RecipeList FilteredRecipe = new RecipeList(RecipesFound);
            FilteredRecipe.FilterByKeyword(SearchInput);
            IEnumerable<Recipe> recipes = FilteredRecipe.Recipes;

            SearchResultViewModel searchResult = new SearchResultViewModel(recipes);
            Content = searchResult;

            searchResult.ViewRecipe.Subscribe((recipe) => {
                RecipeViewModel CurrentRecipe = new RecipeViewModel(recipe);
                Content = CurrentRecipe;
            });


            return recipes;
        }, isValidSearch);

        SilkRoadButton = ReactiveCommand.Create(() => {
            List<string> SilkEventCountries = new List<string>(){
            "Italy", "Greece", "Turkey", "Iran", "India", "China", "Syria", "Lebanon", "Jordan", "Israel",
            };

            EventPageViewModel SilkEventPage = new EventPageViewModel("Silk Road Event!", new DateTime(2024, 05, 1), new DateTime(2024, 06, 1), SilkEventCountries, "The Silk Road was a series of routes  used for trade between Europe and Asia between the 2nd century BCE until the 15th. It spans ~6,500 kilometers and it played a central role in joining the East and West culturally, economically and religiously. To celebrate this major part of history, Mondial Munch's event this month is to make one recipe from every country on the silk road! Track your progress below and good luck!");

            Content = SilkEventPage;
        });

        BananaRepublicButton = ReactiveCommand.Create(() => {
            List<string> BananaEventCountries = new List<string>(){
                "Honduras", "Guatemala", "Costa Rica", "Panama", "Cuba"
            };

            EventPageViewModel BananaEventPage = new EventPageViewModel("Banana Republic Week!", new DateTime(2024, 05, 11), new DateTime(2024, 05, 25), BananaEventCountries, "The banana republics were (in some cases still are) politaclly and economically unstable countries where the government is in part or totally controlled by a private for-profit company, making the country an asset for the profit of it's ruling class. Some of these countries are being featured here as Mondial Munch's bi-weekly event to bring help bring some awareness to these regimes. Track your progress below and consider reading up some of the history of these countries.");

            Content = BananaEventPage;
        });

        NewRecipe = ReactiveCommand.Create(() => {
            NewRecipeViewModel newRecipePage = new NewRecipeViewModel();
            Content = newRecipePage;
            newRecipePage.AddRecipe.Subscribe((recipe) => {
                RecipeViewModel CurrentRecipe = new RecipeViewModel(recipe);
                Content = CurrentRecipe;
            });
        });
    }
}
