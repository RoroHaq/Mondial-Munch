using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using MondialMunch;
using MondialMunchGUI.ViewModels;
using ReactiveUI;

namespace MondialMunchGUI.ViewModels;

public class ProfileViewModel : ViewModelBase {
    public string Name { get; }
    public string Description { get; }
    public string CountryOriginName { get; }

    public ProfileViewModel(User user) {
        Name = user.Name;
        Description = user.Description;
        CountryOriginName = user.CountryOrigin.Name;
    }
}
