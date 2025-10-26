using DatabaseClient.Commands;
using DatabaseClient.Models.Data;
using DatabaseClient.Services.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseClient.ViewModels.Sub.Create
{
    class CreateCarCompanyViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Headquater> Headquaters { get; }

        private Headquater _selectedHeadquater;

        private string _name = string.Empty;

        private string _path = string.Empty;

        public Headquater SelectedHeadquarter
        {
            get => _selectedHeadquater;
            set
            {
                if (_selectedHeadquater != value)
                {
                    _selectedHeadquater = value;
                    OnPropertyChanged(nameof(SelectedHeadquarter));
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
        public ICommand BrowseCommand { get; }

        private CarCompanyService _carCompanyService;
        private HeadquaterService _headquaterService;

        private IServiceProvider _serviceProvider = App.AppHost.Services;

        public CreateCarCompanyViewModel()
        {
            _carCompanyService = _serviceProvider.GetRequiredService<CarCompanyService>();
            _headquaterService = _serviceProvider.GetRequiredService<HeadquaterService>();

            CreateCommand = new RelayCommand(OnCreate);
            BrowseCommand = new RelayCommand(OnBrowse);

            Headquaters = new ObservableCollection<Headquater>(_headquaterService.GetAll());
        }

        private void OnCreate(object obj)
        {

            byte[] imageBytes = File.ReadAllBytes(_path);

            CarCompany carCompany = new(_selectedHeadquater.ID, _name, imageBytes);

            int result = _carCompanyService.Create(carCompany);

            if (result == 1)
            {
                System.Windows.MessageBox.Show("Car Company added successfully!", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                OnReset(null);
            }
            else
            {
                System.Windows.MessageBox.Show("Error adding Car Company.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void OnBrowse(object obj)
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "Select an image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == true)
                _path = openFileDialog.FileName;
        }

        private void OnReset(object? obj)
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
