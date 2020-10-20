using CoreApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    //implements the interface
    public class ProductRepository : IProductRepository
    {

        //initialize the db context
        capstoneContext _capstoneContext;

        //constructor
        public ProductRepository(capstoneContext capstoneContext)
        {
            _capstoneContext = capstoneContext;
        }

        //get all 
        public IEnumerable<Products> GetCategories()
        {
            return _capstoneContext.Products.ToList();
        }

        //get specific by id
        public Products GetCategory(int id)
        {
            return _capstoneContext.Products
                .FirstOrDefault(x => (x.Id == id));
        }

       public bool ProductExists(int id)
        {
            return _capstoneContext.Products
                .Any(x => x.Id == id);
        }

    }
}
