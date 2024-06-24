using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Net.Http.Headers;
using System.Windows;
using MovieApplication.Services.Interfaces;
using MovieApplication.Services.Services;
using MovieApplication.UI.ViewModels;
using System;

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
            services.AddHttpClient("RapidApiClient", client =>
            {
                client.BaseAddress = new Uri("https://imdb-top-100-movies.p.rapidapi.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-rapidapi-key",
                    Environment.GetEnvironmentVariable("RAPIDAPI_KEY"));
                client.DefaultRequestHeaders.Add("x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com");
            });

            services.AddSingleton<IMovieService, MovieService>();
            services.AddTransient<AllMoviesViewModel>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();

            mainWindow.DataContext = serviceProvider.GetService<AllMoviesViewModel>();

            mainWindow.Show();
        }


    }
}
