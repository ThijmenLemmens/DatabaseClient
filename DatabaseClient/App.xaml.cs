using DatabaseClient.Repositorys;
using DatabaseClient.Repositorys.Interfaces;
using DatabaseClient.Services;
using DatabaseClient.Services.Data;
using DatabaseClient.ViewModels.Sub;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace DatabaseClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   // Register your services and viewmodels here
                   services.AddSingleton<MainWindow>();

                   // Services
                   services.AddSingleton(new DatabaseService());

                   services.AddScoped<IHeadquatersRepository, HeadquatersRepository>();
                   services.AddScoped<HeadquaterService>();

                   services.AddScoped<ICarCompanyRepository, CarCompanyRepository>();
                   services.AddScoped<CarCompanyService>();

                   services.AddScoped<ICarRepository, CarRepository>();
                   services.AddScoped<CarService>();
               })
               .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            AppHost.Dispose();
            base.OnExit(e);
        }

    }

}
