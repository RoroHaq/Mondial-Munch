using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using MondialMunchGUI.ViewModels;
using ReactiveUI;

namespace MondialMunchGUI.ViewModels;

public class PrimaryPageViewModel : ViewModelBase {
    private const int SIDEBAR_SIZE_OPEN = 200;

    private ViewModelBase _content;
    private bool _isSideBarOpen = true;
    private GridLength _sideBarSize = new(SIDEBAR_SIZE_OPEN, GridUnitType.Pixel);

    public ReactiveCommand<Unit, bool> ToggleSideBar { get; }

    public ViewModelBase Content {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public bool IsSideBarOpen {
        get => _isSideBarOpen;
        private set => this.RaiseAndSetIfChanged(ref _isSideBarOpen, value);
    }

    public GridLength SideBarSize {
        get => _sideBarSize;
        private set => this.RaiseAndSetIfChanged(ref _sideBarSize, value);
    }

    public PrimaryPageViewModel() {
        Content = new HomePageViewModel();

        ToggleSideBar = ReactiveCommand.Create(
            () => {
                IsSideBarOpen = !IsSideBarOpen;
                SideBarSize = new(IsSideBarOpen ? SIDEBAR_SIZE_OPEN : 0, GridUnitType.Pixel);
                return IsSideBarOpen;
            }
        );
    }
}
