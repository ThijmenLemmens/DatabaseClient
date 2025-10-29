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

        private int _fkCountry;

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

        public int FkCountry
        {
            get => _fkCountry;
            set {

                if (_fkCountry != value)
                {
                    _fkCountry = value;
                }

            }
        }

        public Headquater(string city, int fkCountry)
        {
            _city = city;
            _fkCountry = fkCountry;
        }

        public Headquater(int id, string city, int fkCountry)
        {
            _id = id;
            _city = city;
            _fkCountry = fkCountry;
        }
    }
}
