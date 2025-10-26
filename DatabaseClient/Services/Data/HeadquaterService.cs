using DatabaseClient.Models.Data;
using DatabaseClient.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Services.Data
{
    class HeadquaterService
    {

        private readonly IHeadquatersRepository _headquatersRepository;

        public static event Action<Headquater>? OnheadquatersAdded;

        public HeadquaterService(IHeadquatersRepository headquatersRepository)
        {
            _headquatersRepository = headquatersRepository;
        }

        public int Create(Headquater headquater)
        {
            int result = _headquatersRepository.Create(headquater);

            OnheadquatersAdded?.Invoke(headquater);

            return result;
        }

        public List<Headquater> GetAll() => _headquatersRepository.GetAll();
    }
}
