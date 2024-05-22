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
    public List<MondialMunchEvent> CompletedEvents { get; }

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
        CompletedEvents = new List<MondialMunchEvent>();

        foreach (MondialMunchEvent e in MondialMunchService.GetInstance().GetMMEvents()) {
            bool complete_country = true;
            foreach (Country c in e.EventCountries) {
                bool complete_recipe = false;
                foreach (CompletedRecipe r in MondialMunchService.GetInstance().CurrentUser!.CompletedRecipies) {
                    if (r.RecipeCompleted.Country == c &&
                        e.StartDate <= r.DateCompleted) {
                        complete_recipe = true;
                        break;
                    }
                }
                if (!complete_recipe) {
                    complete_country = false;
                    break;
                }
            }
            if (complete_country) {
                CompletedEvents.Add(e);
            }
        }

        List<Country> completedCountries = MondialMunchService.GetInstance().GetCompletedCountriesForUser(user);
        CompletedCountriesCssString = Country.MakeGuiMapCssForCountries(completedCountries, "#005aff");
    }
}
