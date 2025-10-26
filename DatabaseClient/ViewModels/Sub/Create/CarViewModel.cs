using DatabaseClient.Commands;
using DatabaseClient.Models.Data;
using DatabaseClient.Repositorys;
using DatabaseClient.Services.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseClient.ViewModels.Sub.Create
{
    class CarViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<CarCompany> CarCompanies { get; } = new();

        private CarCompany _selectedCarCompany;

        private string _name = string.Empty;

        private int _pk = 0;

        private bool _isPkSelected = true;
        private bool _isKwSelected;

        public CarCompany SelectedCarCompany
        {
            get => _selectedCarCompany;
            set
            {
                if (_selectedCarCompany != value)
                {
                    _selectedCarCompany = value;
                    OnPropertyChanged(nameof(SelectedCarCompany));
                }
            }
        }

        public int PK
        {
            get => _pk;
            set
            {
                int pkValue = value;

                if (_isKwSelected)
                    pkValue = (int) Math.Round(value * 1.35962, 2); // KW -> PK

                _pk = pkValue;
                OnPropertyChanged();
            }
        }

        public bool IsPkSelected
        {
            get => _isPkSelected;
            set
            {
                if (_isPkSelected != value)
                {
                    _isPkSelected = value;
                    if (_isPkSelected) IsKwSelected = false;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsKwSelected
        {
            get => _isKwSelected;
            set
            {
                if (_isKwSelected != value)
                {
                    _isKwSelected = value;
                    if (_isKwSelected) IsPkSelected = false;
                    OnPropertyChanged();
                }
            }
        }


        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateCommand { get; }
        public ICommand ResetCommand { get; }

        private CarCompanyService _carCompanyService;
        private CarService _carService;

        private IServiceProvider _serviceProvider = App.AppHost.Services;

        public CarViewModel()
        {
            _carCompanyService = _serviceProvider.GetRequiredService<CarCompanyService>();
            _carService = _serviceProvider.GetRequiredService<CarService>();

            CreateCommand = new RelayCommand(OnCreate);

            CarCompanies = new(_carCompanyService.GetAll());
        }

        private void OnCreate(object obj)
        {
            Car car = new(_selectedCarCompany.ID, _name, PK);

            int result = _carService.Create(car);

            if (result == 1)
            {
                System.Windows.MessageBox.Show("Car added successfully!", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                OnReset(null);
            }
            else
            {
                System.Windows.MessageBox.Show("Error adding Car.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void OnReset(object? obj)
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
