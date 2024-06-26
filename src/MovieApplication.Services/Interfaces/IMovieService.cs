﻿using MovieApplication.Models;

namespace MovieApplication.Services.Interfaces;

public interface IMovieService
{
    Task<List<MovieModel>?> GetTopMoviesAsync();

}