using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetCategories();

        Products GetCategory(int id);

        bool ProductExists(int id);
        
    }
}