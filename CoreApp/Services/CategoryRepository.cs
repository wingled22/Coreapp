using CoreApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    //implements the interface
    public class CategoryRepository : ICategoryRepository
    {

        //initialize the db context
        capstoneContext _capstoneContext;
        
        //constructor
        public CategoryRepository(capstoneContext capstoneContext)
        {
            _capstoneContext = capstoneContext;
        }

        //get all 
        public IEnumerable<Category> GetCategories()
        {
            return _capstoneContext.Category.ToList();
        }

        //get specific by id
        public Category GetCategory(int id)
        {
            return _capstoneContext.Category
                .Where(x => (x.Id == id))
                .FirstOrDefault();
        }


        public void Save(Category category)
        {
            _capstoneContext.Add(category);
            
        }

        public void Update(Category category)
        {
            _capstoneContext.Update(category);
        }

        public void Delete(int id)
        {
            var categoryFromRepository = _capstoneContext.Category.Find(id);
            _capstoneContext.Category.Remove(categoryFromRepository);
        }

        public bool CategoryExists(int id)
        {
            return _capstoneContext.Category
                .Any(x => x.Id == id);
        }

    }
}
