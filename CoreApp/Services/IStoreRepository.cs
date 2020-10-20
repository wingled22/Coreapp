using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetStores();

        Store GetStore(int id);

        bool StoreExists(int id);

        void Save(Store store);

        void Update(Store store);

        void Delete(int id);

    }
}