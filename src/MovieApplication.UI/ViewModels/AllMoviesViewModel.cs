using MovieApplication.Models;
using MovieApplication.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieApplication.UI.ViewModels;

public class AllMoviesViewModel : ViewModelBase
{
    private readonly IMovieService _movieService;

    private ObservableCollection<MovieModel> _movies;
    public ObservableCollection<MovieModel> Movies
    {
        get => _movies;
        set
        {
            _movies = value;
            OnPropertyChanged();
        }
    }

    public AllMoviesViewModel(IMovieService movieService)
    {
        _movieService = movieService;
        LoadMovies();
    }

    private async Task LoadMovies()
    {
        var movieList = await _movieService.GetTopMoviesAsync();
        Movies = new ObservableCollection<MovieModel>(movieList);
    }
}