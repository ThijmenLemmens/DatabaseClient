using DatabaseClient.Models.Data;
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
