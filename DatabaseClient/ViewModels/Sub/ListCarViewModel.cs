using DatabaseClient.Models.Data;
using DatabaseClient.Services.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.ViewModels.Sub
{
    class ListCarViewModel : INotifyPropertyChanged
    {

        public static event Action<Car>? ChangedCar;

        public ObservableCollection<Car> Cars { set; get; } = new();

        private Car _selectedCar;

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                if (_selectedCar != value)
                {
                    _selectedCar = value;
                    OnPropertyChanged(nameof(SelectedCar));
                    ChangedCar?.Invoke(value);
                }
            }
        }

        private CarService _carService;

        private IServiceProvider _serviceProvider = App.AppHost.Services;

        public ListCarViewModel()
        {
            _carService = _serviceProvider.GetRequiredService<CarService>();

            ListCarCompanyViewModel.ChangedCarCompany += OnChangedCarCompany;
        }

        public void OnChangedCarCompany(CarCompany carCompany)
        {
            Cars.Clear();
            
            foreach (Car car in _carService.GetCarsByCompanyId(carCompany))
                Cars.Add(car);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
