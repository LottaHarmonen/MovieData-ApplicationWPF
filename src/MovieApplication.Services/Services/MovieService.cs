using MovieApplication.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using MovieApplication.Models;

namespace MovieApplication.Services.Services;

public class MovieService : IMovieService
{
    private readonly HttpClient _httpClient;

    public MovieService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("RapidApiClient");
    }


    public async Task<List<MovieModel>?> GetTopMoviesAsync()
    {
        var response = await _httpClient.GetAsync(String.Empty);
        response.EnsureSuccessStatusCode();

        var movieList = await response.Content.ReadFromJsonAsync<List<MovieModel>>();

        return movieList;
    }
}