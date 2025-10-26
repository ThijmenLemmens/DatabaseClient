using DatabaseClient.Models.Data;
using DatabaseClient.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace DatabaseClient.Services.Data
{
    internal class CarCompanyService
    {

        private readonly ICarCompanyRepository _carCompanyRepository;

        public static event Action<CarCompany> OnCarCompanyAdded;

        public CarCompanyService(ICarCompanyRepository carCompanyRepository)
        {
            _carCompanyRepository = carCompanyRepository;
        }

        public int Create(CarCompany carCompany)
        {
            int result = _carCompanyRepository.Create(carCompany);

            OnCarCompanyAdded?.Invoke(carCompany);

            return result;
        }

        public List<CarCompany> GetAll() => _carCompanyRepository.GetAll();
    }
}
