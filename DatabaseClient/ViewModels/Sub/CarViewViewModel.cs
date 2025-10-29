using DatabaseClient.Models.Data;
using DatabaseClient.Services.Data;
using DatabaseClient.ViewModels.Sub.Create;
using Microsoft.Extensions.DependencyInjection;
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

        public CarCompany CarCompany
        {
            get => _carCompany;
            set
            {
                if (_carCompany != value)
                {
                    _carCompany = value;
                    OnPropertyChanged(nameof(CarCompany));
                }
            }
        }

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

        private int _pk = 0;
        private int _kw = 0;

        private bool _isPkSelected = true;
        private bool _isKwSelected;

        public int PK
        {
            get => _pk;
            set
            {
                if (_pk != value)
                {
                    _pk = value;
                    _kw = (int) Math.Round(_pk * 0.7355); 
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(KW));
                    OnPropertyChanged(nameof(DisplayValue));
                }
            }
        }

        public int KW
        {
            get => _kw;
            set
            {
                if (_kw != value)
                {
                    _kw = value;
                    _pk = (int) Math.Round(_kw / 0.7355);
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PK));
                    OnPropertyChanged(nameof(DisplayValue));
                }
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
                    if (value) IsKwSelected = false;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DisplayValue));
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
                    if (value) IsPkSelected = false;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DisplayValue));
                }
            }
        }

        /// <summary>
        /// De waarde die de gebruiker ziet en bewerkt — afhankelijk van de selectie.
        /// </summary>
        public int DisplayValue
        {
            get => IsPkSelected ? PK : KW;
            set
            {
                if (IsPkSelected)
                    PK = value;
                else
                    KW = value;
            }
        }


        private CarService _carService;
        private CarCompanyService _carCompanyService;
        private HeadquaterService _headquaterService;

        private IServiceProvider _serviceProvider = App.AppHost.Services;

        public CarViewViewModel()
        {
            _carCompanyService = _serviceProvider.GetRequiredService<CarCompanyService>();

            ListCarViewModel.ChangedCar += OnCarChanged;
        }

        public void OnCarChanged(Car car)
        {
            if (car == null)
            {
                Car = null;
                DisplayValue = 0;
                return;
            }

            Car = car;
            PK = car.Pk;
            CarCompany = _carCompanyService.Read(Car.FkCarCompany); 
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
