using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Models.Data
{
    class Headquater
    {

        private int _id;

        private string _city;

        private string _country;

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string City
        {
            get => _city;
            set {

                if (City != value)
                {
                    _city = value;
                }

            } 
        }

        public string Country
        {
            get => _country;
            set {

                if (_country != value)
                {
                    _country = value;
                }

            }
        }

        public Headquater(string city, string country)
        {
            _city = city;
            _country = country;
        }

        public Headquater(int id, string city, string country)
        {
            _id = id;
            _city = city;
            _country = country;
        }
    }
}
