using DatabaseClient.Commands;
using DatabaseClient.Models.Data;
using DatabaseClient.Services.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseClient.ViewModels.Sub.Create
{
    class CreateHeadquatersViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Country> Countries { get; } = new();

        private string _city = string.Empty;
        private Country _country;

        public string City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        public Country Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateCommand { get; }
        public ICommand ResetCommand { get; }

        private HeadquaterService _headquaterService;
        private CountryService _countryService; 

        private IServiceProvider _serviceProvider = App.AppHost.Services;

        public CreateHeadquatersViewModel()
        {
            _headquaterService = _serviceProvider.GetRequiredService<HeadquaterService>();
            _countryService = _serviceProvider.GetRequiredService<CountryService>();

            CreateCommand = new RelayCommand(OnCreate);
            ResetCommand = new RelayCommand(OnReset);

            Countries = new ObservableCollection<Country>(_countryService.GetAll());
        }

        private void OnCreate(object obj)
        {
            Headquater headquater = new(_city, _country.ID);

            int result = _headquaterService.Create(headquater);

            if (result == 1)
            {
                System.Windows.MessageBox.Show("Headquarter added successfully!", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                OnReset(null);
            }
            else
            {
                System.Windows.MessageBox.Show("Error adding headquarter.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void OnReset(object? obj)
        {
            City = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
