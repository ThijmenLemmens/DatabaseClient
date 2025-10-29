using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Models.Data
{
    internal class Country
    {

        private int _id;

        private string _country;

        public string CountryName
        {
            get => _country; 
            set => _country = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public Country(int id, string country)
        {
            _id = id;
            _country = country;
        }

        public Country(string country)
        {
            _country = country;
        }
    }
}
