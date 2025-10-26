using DatabaseClient.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Repositorys.Interfaces
{
    internal interface ICarRepository : ICRUDRepository<Car>
    {

        public List<Car> GetAllCarsFromCompany(int carCompanyId);

    }
}
