using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using MondialMunch;
using MondialMunchGUI.ViewModels;
using ReactiveUI;

namespace MondialMunchGUI.ViewModels;

public class ProfileViewModel : ViewModelBase {
    private ObservableCollection<Recipe> _createdRecipes;
    private ObservableCollection<CompletedRecipe> _completedRecipes;

    public string Name { get; }
    public string Description { get; }
    public string CountryOriginName { get; }
    public string CompletedCountriesCssString { get; }

    public ObservableCollection<Recipe> CreatedRecipes {
        get => _createdRecipes;
        set => this.RaiseAndSetIfChanged(ref _createdRecipes, value);
    }
    public ObservableCollection<CompletedRecipe> CompletedRecipes {
        get => _completedRecipes;
        set => this.RaiseAndSetIfChanged(ref _completedRecipes, value);
    }

    public ProfileViewModel(User user) {
        Name = user.Name;
        Description = user.Description;
        CountryOriginName = user.CountryOrigin.Name;
        CreatedRecipes = new(user.PersonalRecipes);
        CompletedRecipes = new(user.CompletedRecipies);

        List<Country> completedCountries = MondialMunchService.GetInstance().GetCompletedCountriesForUser(user);
        CompletedCountriesCssString = Country.MakeGuiMapCssForCountries(completedCountries, "#005aff");
    }
}
