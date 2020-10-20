using CoreApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    //implements the interface
    public class StoreRepository : IStoreRepository
    {

        //initialize the db context
        capstoneContext _capstoneContext;

        //constructor
        public StoreRepository(capstoneContext capstoneContext)
        {
            _capstoneContext = capstoneContext;
        }

        //get all 
        public IEnumerable<Store> GetStores()
        {
            return _capstoneContext.Store.ToList();
        }

        //get specific by id
        public Store GetStore(int id)
        {
            return _capstoneContext.Store
                .FirstOrDefault(x => (x.Id == id));
        }

       public bool StoreExists(int id)
        {
            return _capstoneContext.Store
                .Any(x => x.Id == id);
        }


        public void Save(Store store)
        {
            _capstoneContext.Add(store);

        }

        public void Update(Store store)
        {
            _capstoneContext.Update(store);
        }

        public void Delete(int id)
        {
            var storeFromRepository = _capstoneContext.Store.Find(id);
            _capstoneContext.Store.Remove(storeFromRepository);
        }


    }
}
