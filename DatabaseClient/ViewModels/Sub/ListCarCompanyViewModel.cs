using DatabaseClient.Commands;
using DatabaseClient.Models.Data;
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

namespace DatabaseClient.ViewModels.Sub
{
    class ListCarCompanyViewModel : INotifyPropertyChanged
    {

        public static event Action<CarCompany>? ChangedCarCompany;

        public ObservableCollection<CarCompany> CarCompanies { get; } = new();

        private CarCompany _selectedCarCompany;

        public CarCompany SelectedCarCompany
        {
            get => _selectedCarCompany;
            set
            {
                if (_selectedCarCompany != value)
                {
                    _selectedCarCompany = value;
                    OnPropertyChanged(nameof(SelectedCarCompany));
                    ChangedCarCompany?.Invoke(value);
                }
            }
        }

        private CarCompanyService _carCompanyService;

        private IServiceProvider _serviceProvider = App.AppHost.Services;

        public ListCarCompanyViewModel()
        {
            _carCompanyService = _serviceProvider.GetRequiredService<CarCompanyService>();

            CarCompanyService.OnCarCompanyAdded += OnAddCarCompany;

            CarCompanies = new(_carCompanyService.GetAll());
        }

        public void OnAddCarCompany(CarCompany carCompany) => CarCompanies.Add(carCompany);

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
