using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using MondialMunch;
using MondialMunchGUI.ViewModels;
using ReactiveUI;

namespace MondialMunchGUI.ViewModels;

public class RecipeViewModel : ViewModelBase {
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

    public int MyRating {
        get => _myRating;
        set => this.RaiseAndSetIfChanged(ref _myRating, value);
    }

    public string MyReview {
        get => _myReview;
        set => this.RaiseAndSetIfChanged(ref _myReview, value);
    }

    public ReactiveCommand<Unit, Unit> AddReview { get; }

    public RecipeViewModel(Recipe recipe) {
        Name = recipe.Name;
        Description = recipe.Description!;
        CreatorName = recipe.Creator.Name;
        ServingSize = recipe.Servings;
        PrepTime = recipe.PrepTime;
        CookTime = recipe.CookingTime;
        TotalTime = recipe.TotalTime;
        Ingredients = recipe.Ingredients;
        Instructions = recipe.Instructions;
        Stars = recipe.Stars;
        Reviews = new(recipe.Reviews);

        AddReview = ReactiveCommand.Create(() => {
            MondialMunchService.GetInstance().AddOrEditRecipeReview(recipe, MyRating, MyReview);
            Stars = recipe.Stars;
            Reviews = new(recipe.Reviews);
        });
    }
}
