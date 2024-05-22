using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using MondialMunch;
using MondialMunchGUI.ViewModels;
using ReactiveUI;

namespace MondialMunchGUI.ViewModels;

public class RecipeViewModel : ViewModelBase {
    private string _favoriteButtonText;
    private string _todoButtonText;
    private string _completeButtonText;

    private int _myRating;
    private string _myReview;

    private double _stars;
    private ObservableCollection<RecipeReview> _reviews;

    public string Name { get; }
    public string Description { get; }
    public string CreatorName { get; }
    public int ServingSize { get; }
    public double PrepTime { get; }
    public double CookTime { get; }
    public double TotalTime { get; }
    public bool CanDelete { get; }
    public Country Country { get; }
    public List<Ingredient> Ingredients { get; }
    public List<RecipeInstruction> Instructions { get; }

    public double Stars {
        get => _stars;
        set => this.RaiseAndSetIfChanged(ref _stars, value);
    }
    public ObservableCollection<RecipeReview> Reviews {
        get => _reviews;
        set => this.RaiseAndSetIfChanged(ref _reviews, value);
    }

    public string FavoriteButtonText {
        get => _favoriteButtonText;
        set => this.RaiseAndSetIfChanged(ref _favoriteButtonText, value);
    }
    public string ToDoButtonText {
        get => _todoButtonText;
        set => this.RaiseAndSetIfChanged(ref _todoButtonText, value);
    }
    public string CompleteButtonText {
        get => _completeButtonText;
        set => this.RaiseAndSetIfChanged(ref _completeButtonText, value);
    }

    public int MyRating {
        get => _myRating;
        set => this.RaiseAndSetIfChanged(ref _myRating, value);
    }
    public string MyReview {
        get => _myReview;
        set => this.RaiseAndSetIfChanged(ref _myReview, value);
    }

    public ReactiveCommand<Unit, Unit> AddReview { get; }
    public ReactiveCommand<Unit, Unit> FavoriteButton { get; }
    public ReactiveCommand<Unit, Unit> ToDoButton { get; }
    public ReactiveCommand<Unit, Unit> CompleteButton { get; }
    public ReactiveCommand<Unit, bool> DeleteRecipe { get; }

    public RecipeViewModel(Recipe recipe) {
        Name = recipe.Name;
        Description = recipe.Description!;
        CreatorName = recipe.Creator.Name;
        ServingSize = recipe.Servings;
        PrepTime = recipe.PrepTime;
        CookTime = recipe.CookingTime;
        TotalTime = recipe.TotalTime;
        Country = recipe.Country;
        CanDelete = recipe.Creator == MondialMunchService.GetInstance().CurrentUser;
        Ingredients = recipe.Ingredients;
        Instructions = recipe.Instructions;
        Stars = recipe.Stars;
        Reviews = new(recipe.Reviews);
        FavoriteButtonText = MondialMunchService.GetInstance().IsRecipeFavorited(recipe) ? "Unfavorite" : "Favorite";
        ToDoButtonText = MondialMunchService.GetInstance().IsRecipeToDo(recipe) ? "Unmark ToDo" : "Mark ToDo";
        CompleteButtonText = MondialMunchService.GetInstance().IsRecipeComplete(recipe) ? "Unmark Complete" : "Mark Complete";

        AddReview = ReactiveCommand.Create(() => {
            MondialMunchService.GetInstance().AddOrEditRecipeReview(recipe, MyRating, MyReview);
            Stars = recipe.Stars;
            Reviews = new(recipe.Reviews);
        });

        FavoriteButton = ReactiveCommand.Create(() => {
            bool isFavorited = MondialMunchService.GetInstance().ToggleRecipeFavorite(recipe);
            FavoriteButtonText = isFavorited ? "Unfavorite" : "Favorite";
        });

        ToDoButton = ReactiveCommand.Create(() => {
            bool isToDo = MondialMunchService.GetInstance().ToggleRecipeToDo(recipe);
            ToDoButtonText = isToDo ? "Unmark ToDo" : "Mark ToDo";
        });

        CompleteButton = ReactiveCommand.Create(() => {
            bool isComplete = MondialMunchService.GetInstance().ToggleRecipeComplete(recipe);
            CompleteButtonText = isComplete ? "Unmark Complete" : "Mark Complete";
        });

        DeleteRecipe = ReactiveCommand.Create(() => {
            MondialMunchService.GetInstance().DeleteRecipe(recipe);
            return true;
        });
    }
}
