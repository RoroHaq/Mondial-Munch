using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using MondialMunch;
using MondialMunchGUI.ViewModels;
using ReactiveUI;

namespace MondialMunchGUI.ViewModels;

public class RecipeViewModel : ViewModelBase {
    public string Name { get; }
    public string Description { get; }
    public string CreatorName { get; }
    public int ServingSize { get; }
    public double PrepTime { get; }
    public double CookTime { get; }
    public double TotalTime { get; }
    public List<Ingredient> Ingredients { get; }
    public List<RecipeInstruction> Instructions { get; }

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
    }
}
