using DatabaseClient.Models.Data;
using DatabaseClient.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Services.Data
{
    class CarService
    {

        private readonly ICarRepository _carRepository;

        public static event Action<Car>? OnCarAdded;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public int Create(Car car)
        {
            int result = _carRepository.Create(car);

            OnCarAdded?.Invoke(car);

            return result;
        }

        public List<Car> GetCarsByCompanyId(CarCompany carCompany) => _carRepository.GetAllCarsFromCompany(carCompany.ID);
    }
}
