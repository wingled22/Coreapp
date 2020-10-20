using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();

        Category GetCategory(int id);

        void Save(Category category);

        void Update(Category category);

        void Delete(int id);

        bool CategoryExists(int id);
        
    }
}