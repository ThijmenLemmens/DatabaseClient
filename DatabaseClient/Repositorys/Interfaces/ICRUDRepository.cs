using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Repositorys.Interfaces
{
    public interface ICRUDRepository<T> where T : class
    {

        public int Create(T model);

        public T Read(int id);

        public void Update(T model);

        public int Delete(T model);

        public List<T> GetAll();

    }
}
