using DatabaseClient.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Repositorys.Interfaces
{
    internal interface ICountryRepository : ICRUDRepository<Country>
    {

        public Country GetCountry(string name);

    }
}
