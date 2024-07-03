using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Net.Http.Headers;
using System.Windows;
using MovieApplication.Services.Interfaces;
using MovieApplication.Services.Services;
using MovieApplication.UI.ViewModels;
using System;
using System.Net.Http;
using MovieApplication.Models;

namespace MovieApplication.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;


        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            string apiKey = Environment.GetEnvironmentVariable("RAPIDAPI_KEY");

            services.AddHttpClient("RapidApiClient", client =>
            {
                client.BaseAddress = new Uri("https://imdb-top-100-movies.p.rapidapi.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-rapidapi-key",
                    apiKey);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com");
            });

            services.AddSingleton<IMovieService, MovieService>();
            services.AddTransient<AllMoviesViewModel>();
            services.AddTransient<MovieDetailViewModel>();
            services.AddSingleton<MainViewModel>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();


            mainWindow.DataContext = mainViewModel;
            mainWindow.Show(); 
        }


    }
}
