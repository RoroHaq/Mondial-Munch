using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;

namespace MondialMunchGUI.ViewModels {
  public class ViewRecipeViewModel : ViewModelBase {

    public string Name { get; }

    public ViewRecipeViewModel(Recipe recipe) {

      Name = recipe.Name;

    }

  }
}
