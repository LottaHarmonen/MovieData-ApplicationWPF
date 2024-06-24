using MovieApplication.Models;
using MovieApplication.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MovieApplication.UI.ViewModels;

public class AllMoviesViewModel : ViewModelBase
{
    private readonly IMovieService _movieService;

    public AllMoviesViewModel(IMovieService movieService)
    {
        _movieService = movieService;
        //LoadMovies();
    }

    private ObservableCollection<Movie> _movies;
    public ObservableCollection<Movie> Movies
    {
        get => _movies;
        set => SetField(ref _movies, value);
    }

    private async Task LoadMovies()
    {
        var movieList = await _movieService.GetTopMoviesAsync();
        Movies = new ObservableCollection<Movie>(movieList);
    }
}