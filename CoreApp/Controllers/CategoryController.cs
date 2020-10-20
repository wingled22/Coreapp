using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreApp.Services;
using CoreApp.Entities;

namespace CoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly capstoneContext _context;
        private readonly ICategoryRepository _repository;

        public CategoryController(capstoneContext context, ICategoryRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: Category
        public IActionResult Index()
        {
            var categoriesFromRepository = _repository.GetCategories().ToList();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_TablePartial", categoriesFromRepository);
            }

            return View(categoriesFromRepository);
        }

        //this will return a partialView which contain the modal
        [HttpGet]
        public IActionResult Create()
        {
            Category category = new Category();
            return PartialView("_CategoryModalPartial", category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(category);
                _context.SaveChanges();
                return PartialView("_CategoryModalPartial", category);
            }

            return PartialView("_CategoryModalPartial", category);

        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var category = _repository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return PartialView("_DetailCategoryModalPartial", category);
        }


        // GET: Category/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _repository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return PartialView("_EditCategoryModalPartial", category);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(category);
                    _context.SaveChanges();
                    return PartialView("_EditCategoryModalPartial", category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return PartialView("_EditCategoryModalPartial", category);
            }
    
            return PartialView("_EditCategoryModalPartial", category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _repository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return PartialView("_DeleteCategoryModalPartial", category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            var categoryFromRepository = _repository.GetCategory(category.Id);
            if (categoryFromRepository == null)
            {
                return NotFound();
            }
            _repository.Delete(categoryFromRepository.Id);
            _context.SaveChanges();
            return PartialView("_DeleteCategoryModalPartial", category);
        }

    }
}
