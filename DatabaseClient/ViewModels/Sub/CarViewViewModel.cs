using DatabaseClient.Models.Data;
using DatabaseClient.Services.Data;
using DatabaseClient.ViewModels.Sub.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.ViewModels.Sub
{
    class CarViewViewModel : INotifyPropertyChanged
    {

        private Car _car;

        private CarCompany _carCompany;

        private Headquater _headquater;

        public Car Car
        {
            get => _car;
            set
            {
                if (_car != value)
                {
                    _car = value;
                    OnPropertyChanged(nameof(Car));
                }
            }
        }

        private CarService _carService;
        private CarCompanyService _carCompanyService;
        private HeadquaterService _headquaterService;

        public CarViewViewModel()
        {
            ListCarViewModel.ChangedCar += OnCarChanged;
        }

        public void OnCarChanged(Car car)
        {
            Car = _car;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
