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
    class HeadquatersRepository : IHeadquatersRepository
    {

        private readonly DatabaseService _databaseService;

        public HeadquatersRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public int Create(Headquater model)
        {
            SqlParameter sqlParameterCity = new("@City", model.City);
            SqlParameter sqlParameterCountry = new("@FKCountry", model.City);

            SqlParameter sqlParameterId = new("@NewId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            int result = _databaseService.ExecuteNonQuery("sp_CreateHeadquater", sqlParameterCity, sqlParameterCountry, sqlParameterId);

            model.ID = (int) sqlParameterId.Value;

            return result;
        }

        public int Delete(Headquater model)
        {
            throw new NotImplementedException();
        }

        public List<Headquater> GetAll()
        {
            using SqlDataReader reader = _databaseService.ExecuteReader("sp_GetAllHeadquaters");

            List<Headquater> headquaters = new();

            while (reader.Read())
                headquaters.Add(new(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));

            return headquaters;
        }

        public Headquater Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Headquater model)
        {
            throw new NotImplementedException();
        }
    }
}
