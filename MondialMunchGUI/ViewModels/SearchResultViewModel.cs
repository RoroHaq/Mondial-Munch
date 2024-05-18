using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;
using Splat;

namespace MondialMunchGUI.ViewModels {
  public class SearchResultViewModel {


    public SearchResultViewModel(IEnumerable<Ingredient> recipes) {

      Recipes = new ObservableCollection<Ingredient>(recipes);
    }

    public ObservableCollection<Ingredient> Recipes { get; }
  }
}
