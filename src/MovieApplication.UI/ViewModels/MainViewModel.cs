using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MovieApplication.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;

    public MainViewModel(AllMoviesViewModel allMoviesViewModel, MovieDetailViewModel movieDetailViewModel)
    {
        AllMoviesViewModel = allMoviesViewModel;
        MovieDetailViewModel = movieDetailViewModel;

        CurrentViewModel = allMoviesViewModel;

        ShowAllMoviesViewCommand = new RelayCommand(() => CurrentViewModel = allMoviesViewModel);
        ShowMovieDetailViewCommand = new RelayCommand(() => CurrentViewModel = MovieDetailViewModel);

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


    public ViewModelBase AllMoviesViewModel { get; }
    public ViewModelBase MovieDetailViewModel { get; }

    public ICommand ShowAllMoviesViewCommand { get; }
    public ICommand ShowMovieDetailViewCommand { get; }
}