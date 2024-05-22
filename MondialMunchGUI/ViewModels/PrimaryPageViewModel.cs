using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;
using MondialMunchGUI.Views;
using Avalonia.Controls;
using System.Reactive;
using System.Diagnostics.Tracing;
using System.Linq;

namespace MondialMunchGUI.ViewModels;

public class PrimaryPageViewModel : ViewModelBase {
    private const int SIDEBAR_SIZE_OPEN = 200;

    private string? _search;
    private ViewModelBase _content = null!;
    private bool _isSideBarOpen = true;
    private GridLength _sideBarSize = new(SIDEBAR_SIZE_OPEN, GridUnitType.Pixel);

    public ReactiveCommand<Unit, bool> ToggleSideBar { get; }
    public ReactiveCommand<Unit, IEnumerable<Recipe>> Search { get; }
    public ReactiveCommand<MondialMunchEvent, Unit> EventButton { get; }
    public ReactiveCommand<Unit, Unit> NewRecipe { get; }
    public ReactiveCommand<string, Unit> OpenPage { get; }

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

    public IEnumerable<MondialMunchEvent> Events { get; set; }

    public PrimaryPageViewModel() {
        Content = new HomePageViewModel();

        Events = MondialMunchService.GetInstance().GetMMEvents().Where(e => e.DueDate >= DateTime.Today);

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

            RecipeListViewModel searchResult = new RecipeListViewModel(recipes);
            Content = searchResult;

            searchResult.ViewRecipe.Subscribe((recipe) => {
                RecipeViewModel CurrentRecipe = new RecipeViewModel(recipe);
                Content = CurrentRecipe;
            });


            return recipes;
        }, isValidSearch);

        EventButton = ReactiveCommand.Create((MondialMunchEvent e) => {

            EventPageViewModel SpecificEventPage = new EventPageViewModel(e.ShortTitle, e.Title, e.StartDate, e.DueDate, e.EventCountries, e.Description);

            Content = SpecificEventPage;
        });

        NewRecipe = ReactiveCommand.Create(() => {
            NewRecipeViewModel newRecipePage = new NewRecipeViewModel();
            Content = newRecipePage;
            newRecipePage.AddRecipe.Subscribe((recipe) => {
                RecipeViewModel CurrentRecipe = new RecipeViewModel(recipe);
                Content = CurrentRecipe;
            });
        });

        OpenPage = ReactiveCommand.Create((string page) => {
            Content = page switch {
                "home" => new HomePageViewModel(),
                // "profile" => 
                "todo" => new RecipeListViewModel(MondialMunchService.GetInstance().CurrentUser!.TodoRecipies),
                "favorites" => new RecipeListViewModel(MondialMunchService.GetInstance().CurrentUser!.FavouriteRecipies),
                "myRecipes" => new RecipeListViewModel(MondialMunchService.GetInstance().CurrentUser!.PersonalRecipes),
                _ => Content
            };
        });
    }
}
