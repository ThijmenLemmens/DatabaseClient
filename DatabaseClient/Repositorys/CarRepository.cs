using DatabaseClient.Models.Data;
using DatabaseClient.Repositorys.Interfaces;
using DatabaseClient.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Repositorys
{
    class CarRepository : ICarRepository
    {

        private readonly DatabaseService _databaseService;

        public CarRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public int Create(Car model)
        {
            SqlParameter sqlParameterName = new("@Name", model.Name);
            SqlParameter sqlParameterPk = new("@Pk", model.Pk);
            SqlParameter sqlParameterFkCarCompany = new("@FkCarCompany", model.FkCarCompany);
            SqlParameter sqlParameterId = new("@NewId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            int result = _databaseService.ExecuteNonQuery("sp_CreateCar", sqlParameterName, sqlParameterPk, sqlParameterFkCarCompany, sqlParameterId);

            model.ID = (int)sqlParameterId.Value;

            return result;
        }

        public Car Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Car model)
        {
            throw new NotImplementedException();
        }
        
        public List<Car> GetAllCarsFromCompany(int carCompanyId)
        {
            SqlParameter sqlParameterCarCompanyId = new("@CarCompanyId", carCompanyId);

            using SqlDataReader reader = _databaseService.ExecuteReader("sp_GetCarsByCompanyId", sqlParameterCarCompanyId);

            List<Car> cars = new();

            while (reader.Read())
                cars.Add(new(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3)));

            return cars;
        }

        public List<Car> GetAll()
        {
            using SqlDataReader reader = _databaseService.ExecuteReader("sp_GetAllCars");

            List<Car> cars = new();

            //while (reader.Read())
            //    cars.Add(new(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetSqlBytes(3).Value));

            return cars;
        }

    }
}
