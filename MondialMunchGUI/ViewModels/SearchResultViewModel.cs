using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;

namespace MondialMunchGUI.ViewModels {
  public class SearchResultViewModel : ViewModelBase {


    public SearchResultViewModel(IEnumerable<Recipe> recipes) {

      Recipes = new ObservableCollection<Recipe>(recipes);
    }

    public ObservableCollection<Recipe> Recipes { get; }
  }
}
