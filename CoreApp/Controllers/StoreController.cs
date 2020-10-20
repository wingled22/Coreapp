using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Entities;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Controllers
{
    public class StoreController : Controller
    {
      
        private readonly capstoneContext _context;
        private readonly IStoreRepository _repository;

        public StoreController(capstoneContext context, IStoreRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: Category
        public IActionResult Index()
        {
            var storesFromRepository = _repository.GetStores().ToList();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_TablePartial", storesFromRepository);
            }

            return View(storesFromRepository);
        }

        //this will return a partialView which contain the modal
        [HttpGet]
        public IActionResult Create()
        {
            Store store = new Store();
            return PartialView("_CreateStoreModalPartial", store);
        }

        [HttpPost]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(store);
                _context.SaveChanges();
                return PartialView("_CreateStoreModalPartial", store);
            }

            return PartialView("_CreateStoreModalPartial", store);

        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var category = _repository.GetStore(id);
            if (category == null)
            {
                return NotFound();
            }
            return PartialView("_DetailStoreModalPartial", category);
        }


        // GET: Category/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _repository.GetStore(id);
            if (category == null)
            {
                return NotFound();
            }
            return PartialView("_EditStoreModalPartial", category);
        }

        [HttpPost]
        public IActionResult Edit(int id, Store store)
        {
            if (id != store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(store);
                    _context.SaveChanges();
                    return PartialView("_EditStoreModalPartial", store);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.StoreExists(store.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return PartialView("_EditStoreModalPartial", store);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _repository.GetStore(id);
            if (category == null)
            {
                return NotFound();
            }
            return PartialView("_DeleteStoreModalPartial", category);
        }

        [HttpPost]
        public IActionResult Delete(Store store)
        {
            var storeFromRepository = _repository.GetStore(store.Id);
            if (storeFromRepository == null)
            {
                return NotFound();
            }
            _repository.Delete(storeFromRepository.Id);
            _context.SaveChanges();
            return PartialView("_DeleteStoreModalPartial", store);
        }

    }
}
