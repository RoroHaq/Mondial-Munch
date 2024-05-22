using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using MondialMunch;
using MondialMunchGUI.ViewModels;
using ReactiveUI;

namespace MondialMunchGUI.ViewModels;

public class ProfileEditViewModel : ViewModelBase {
    private ObservableCollection<Recipe> _createdRecipes;

    private string _name;
    private string _description;
    private Country _countryOrigin;
    private Country _countryLive;
    private string _oldPassword;
    private string _newPassword;


    public string Name {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    public string Description {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    public Country CountryOrigin {
        get => _countryOrigin;
        set => this.RaiseAndSetIfChanged(ref _countryOrigin, value);
    }
    public Country CountryLive {
        get => _countryLive;
        set => this.RaiseAndSetIfChanged(ref _countryLive, value);
    }
    public string OldPassword {
        get => _oldPassword;
        set => this.RaiseAndSetIfChanged(ref _oldPassword, value);
    }
    public string NewPassword {
        get => _newPassword;
        set => this.RaiseAndSetIfChanged(ref _newPassword, value);
    }
    public ObservableCollection<Recipe> CreatedRecipes {
        get => _createdRecipes;
        set => this.RaiseAndSetIfChanged(ref _createdRecipes, value);
    }

    public ReactiveCommand<Unit, Unit> EditGeneral { get; }
    public ReactiveCommand<Unit, Unit> ChangePassword { get; }

    public List<Country> Countries { get; }
    public ProfileEditViewModel() {
        Countries = MondialMunchService.GetInstance().GetCountries();

        EditGeneral = ReactiveCommand.Create(() => {
            MondialMunchService.GetInstance().UpdateUserProfile(Description, CountryOrigin, CountryLive);
        });
    }
}
