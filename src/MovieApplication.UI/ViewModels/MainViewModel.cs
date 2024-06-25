using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MovieApplication.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;

    public MainViewModel(AllMoviesViewModel allMoviesViewModel)
    {
        CurrentViewModel = allMoviesViewModel;  

        ShowAllMoviesViewCommand = new RelayCommand(() => CurrentViewModel = allMoviesViewModel);
    }

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

    public ICommand ShowAllMoviesViewCommand { get; }
}