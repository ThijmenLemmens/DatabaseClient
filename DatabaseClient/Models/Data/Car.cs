using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Models.Data
{
    class Car
    {

        private int _id;

        private int _fkCarCompany;

        private string _name;

        private int _pk;

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public int FkCarCompany
        {
            get => _fkCarCompany;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Pk
        {
            get => _pk;
            set => _pk = value;
        }

        public Car(int id, int fkCarCompany, string name, int pk)
        {
            _id = id;
            _fkCarCompany = fkCarCompany;
            _name = name;
            _pk = pk;
        }

        public Car(int fkCarCompany, string name, int pk)
        {
            _fkCarCompany = fkCarCompany;
            _name = name;
            _pk = pk;
        }


    }
}
