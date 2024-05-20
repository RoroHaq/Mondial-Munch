using ReactiveUI;
using System;
using System.Reactive.Linq;
using MondialMunch;
using System.Collections.Generic;
using MondialMunchGUI.Views;
using Avalonia.Controls;
using System.Reactive;
using System.Collections.ObjectModel;
using System.Linq;

namespace MondialMunchGUI.ViewModels;

public class NewRecipeViewModel : ViewModelBase {
    private string _name;
    private string _description;
    private Country _country;
    private int _servingSize = 1;
    private double _prepTime;
    private double _cookTime;

    private string _newIngredientText;
    private int _newIngredientQuantity = 1;
    private string _newInstructionText;

    public string Name {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    public string Description {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    public Country Country {
        get => _country;
        set => this.RaiseAndSetIfChanged(ref _country, value);
    }
    public int ServingSize {
        get => _servingSize;
        set => this.RaiseAndSetIfChanged(ref _servingSize, value);
    }
    public double PrepTime {
        get => _prepTime;
        set => this.RaiseAndSetIfChanged(ref _prepTime, value);
    }
    public double CookTime {
        get => _cookTime;
        set => this.RaiseAndSetIfChanged(ref _cookTime, value);
    }
    public ObservableCollection<Ingredient> Ingredients { get; private set; }
    public ObservableCollection<RecipeInstruction> Instructions { get; private set; }

    public string NewIngredientText {
        get => _newIngredientText;
        set => this.RaiseAndSetIfChanged(ref _newIngredientText, value);
    }
    public int NewIngredientQuantity {
        get => _newIngredientQuantity;
        set => this.RaiseAndSetIfChanged(ref _newIngredientQuantity, value);
    }
    public string NewInstructionText {
        get => _newInstructionText;
        set => this.RaiseAndSetIfChanged(ref _newInstructionText, value);
    }

    public List<Country> Countries { get; }

    public ReactiveCommand<Unit, Unit> AddIngredient { get; }
    public ReactiveCommand<Ingredient, bool> RemoveIngredient { get; }

    public ReactiveCommand<Unit, Unit> AddInstruction { get; }
    public ReactiveCommand<RecipeInstruction, bool> RemoveInstruction { get; }
    public ReactiveCommand<Unit, Recipe> AddRecipe { get; }

    public NewRecipeViewModel() {
        Ingredients = new() { };
        Instructions = new() { };
        Countries = MondialMunchService.GetInstance().GetCountries();

        // Bindings for adding or removing an ingredient
        var canAddIngredient = this.WhenAnyValue(
            x => x.NewIngredientText,
            x => !string.IsNullOrWhiteSpace(x)
        );
        AddIngredient = ReactiveCommand.Create(() => {
            Ingredients.Add(new Ingredient(NewIngredientText, NewIngredientQuantity));
            NewIngredientText = "";
            NewIngredientQuantity = 1;
        }, canAddIngredient);
        RemoveIngredient = ReactiveCommand.Create((Ingredient i) => Ingredients.Remove(i));

        // Bindings for adding or removing an instruction
        var canAddInstruction = this.WhenAnyValue(
            x => x.NewInstructionText,
            x => !string.IsNullOrWhiteSpace(x)
        );
        AddInstruction = ReactiveCommand.Create(() => {
            Instructions.Add(new RecipeInstruction(NewInstructionText));
            NewInstructionText = "";
        }, canAddInstruction);
        RemoveInstruction = ReactiveCommand.Create((RecipeInstruction i) => Instructions.Remove(i));

        // Binding to create the recipe
        AddRecipe = ReactiveCommand.Create(() => {
            Recipe recipe = new(
                Name,
                MondialMunchService.GetInstance().CurrentUser!,
                Description, ServingSize, PrepTime, CookTime, Country,
                new List<RecipeInstruction>(Instructions),
                new List<Ingredient>(Ingredients));
            MondialMunchService.GetInstance().AddRecipe(recipe);
            return recipe;
        });
    }
}
