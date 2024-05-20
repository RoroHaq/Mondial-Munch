using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;

namespace MondialMunchGUI.ViewModels {
  public class SearchResultViewModel : ViewModelBase {

    public ReactiveCommand<Recipe, Recipe> ViewRecipe { get; }

    public SearchResultViewModel(IEnumerable<Recipe> recipes) {

      Recipes = new ObservableCollection<Recipe>(recipes);

      ViewRecipe = ReactiveCommand.Create((Recipe recipe) => {
        return recipe;
      });
    }

    public ObservableCollection<Recipe> Recipes { get; }
  }
}
