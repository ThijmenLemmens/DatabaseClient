using DatabaseClient.Models.Data;
using DatabaseClient.Repositorys.Interfaces;
using DatabaseClient.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Repositorys
{
    internal class CarCompanyRepository : ICarCompanyRepository
    {

        private readonly DatabaseService _databaseService;

        public CarCompanyRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public int Create(CarCompany model)
        {
            SqlParameter sqlParameterName = new("@Name", model.Name);
            SqlParameter sqlParameterLogo = new("@Logo", model.LogoData);
            SqlParameter sqlParameterFkHeadquaters = new("@FkHeadquaters", model.FkHeadquaters);
            SqlParameter sqlParameterId = new("@NewId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            int result = _databaseService.ExecuteNonQuery("sp_CreateCarCompany", sqlParameterName, sqlParameterLogo, sqlParameterFkHeadquaters, sqlParameterId);
            
            model.ID = (int) sqlParameterId.Value;

            return result;
        }

        public CarCompany Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CarCompany model)
        {
            _databaseService.ExecuteNonQuery(
                "sp_UpdateCarCompany",
                new SqlParameter("@Id", model.ID),
                new SqlParameter("@FkHeadquaters", model.FkHeadquaters),
                new SqlParameter("@Name", model.Name),
                new SqlParameter("@Logo", model.Logo)
            );
        }

        public int Delete(CarCompany model)
        {
            SqlParameter sqlParameterID = new("@Id", model.ID);

            return _databaseService.ExecuteNonQuery("sp_DeleteCarCompany", sqlParameterID);
        }

        public List<CarCompany> GetAll()
        {
            using SqlDataReader reader = _databaseService.ExecuteReader("sp_GetAllCarCompanys");

            List<CarCompany> carCompanies = new();

            while (reader.Read())
                carCompanies.Add(new(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetSqlBytes(3).Value));

            return carCompanies;
        }
    }
}
