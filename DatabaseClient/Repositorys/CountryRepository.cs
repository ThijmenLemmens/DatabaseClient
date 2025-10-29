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
    internal class CountryRepository : ICountryRepository
    {

        private readonly DatabaseService _databaseService;

        public CountryRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public int Create(Country model)
        {
            SqlParameter sqlParameterCountryName = new("@Name", model.CountryName);

            SqlParameter sqlParameterId = new("@NewId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            int result = _databaseService.ExecuteNonQuery("sp_CreateCountry", sqlParameterCountryName, sqlParameterId);

            model.ID = (int) sqlParameterId.Value;

            return result;
        }

        public int Delete(Country model)
        {
            throw new NotImplementedException();
        }

        public List<Country> GetAll()
        {
            using SqlDataReader reader = _databaseService.ExecuteReader("sp_GetAllCountries");

            List<Country> headquaters = new();

            while (reader.Read())
                headquaters.Add(new(reader.GetInt32(0), reader.GetString(1)));

            return headquaters;
        }

        public Country GetCountry(string name)
        {
            //SqlParameter sqlParameterCountryName = new("@Name", name);

            //using SqlDataReader reader = _databaseService.ExecuteReader("sp_GetAllCountries");

            return null;

            //return headquaters;
        }

        public Country Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Country model)
        {
            throw new NotImplementedException();
        }
    }
}
