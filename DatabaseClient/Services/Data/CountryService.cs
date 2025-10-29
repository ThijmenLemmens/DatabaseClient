using DatabaseClient.Models.Data;
using DatabaseClient.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Services.Data
{
    internal class CountryService
    {

        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public int Create(Country country)
        {
            int result = _countryRepository.Create(country);

            return result;

        }

        public List<Country> GetAll() => _countryRepository.GetAll();

    }
}
