using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreApp.Entities;
using CoreApp.Models;
using CoreApp.Profiles;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Controllers
{
    public class ProductController : Controller
    {
      
        private readonly capstoneContext _context;
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public ProductController(capstoneContext context, IProductRepository repository, ICategoryRepository categoryRepository, IStoreRepository storeRepository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _categoryRepository = categoryRepository;
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        // GET: Category
        public IActionResult Index()
        {
            var productsFromRepository = _repository.GetProducts().ToList();
            //var productDto = _mapper.Map<ProductProfile>(productsFromRepository);
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_TablePartial", productsFromRepository);
            }

            return View(productsFromRepository);
        }

        //this will return a partialView which contain the modal
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "Id", "Name");
            ViewData["StoreId"] = new SelectList(_storeRepository.GetStores(), "Id", "Name");
            Products products = new Products();
            return PartialView("_CreateProductModalPartial", products);
        }

        [HttpPost]
        public IActionResult Create(Products product)
        {

            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "Id", "Name");
            ViewData["StoreId"] = new SelectList(_storeRepository.GetStores(), "Id", "Name");
            if (ModelState.IsValid)
            {
                _repository.Save(product);
                _context.SaveChanges();
                return PartialView("_CreateProductModalPartial", product);
            }

            return PartialView("_CreateProductModalPartial", product);

        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var product = _repository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return PartialView("_DetailProductModalPartial", product);
        }


        // GET: Category/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "Id", "Name");
            ViewData["StoreId"] = new SelectList(_storeRepository.GetStores(), "Id", "Name");
            var product = _repository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return PartialView("_EditProductModalPartial", product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Products product)
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "Id", "Name");
            ViewData["StoreId"] = new SelectList(_storeRepository.GetStores(), "Id", "Name");
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(product);
                    _context.SaveChanges();
                    return PartialView("_EditProductModalPartial", product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return PartialView("_EditProductModalPartial", product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productFromRepository = _repository.GetProduct(id);
            if (productFromRepository == null)
            {
                return NotFound();
            }
            return PartialView("_DeleteProductModalPartial", productFromRepository);
        }

        [HttpPost]
        public IActionResult Delete(Products product)
        {
            var productFromRepository = _repository.GetProduct(product.Id);
            if (productFromRepository == null)
            {
                return NotFound();
            }
            _repository.Delete(productFromRepository.Id);
            _context.SaveChanges();
            return PartialView("_DeleteProductModalPartial", product);
        }


        [HttpGet]
        public IActionResult AddStock(int id)
        {
            ProductViewModel productDto = new ProductViewModel();
            productDto.Id = id;
            return PartialView("_UpdateStocksModalPartial", productDto);
        }

        [HttpPost]
        public IActionResult AddStock(ProductViewModel productDto) {
            _repository.AddStocks(productDto);
            _context.SaveChanges();
            return PartialView("_UpdateStocksModalPartial", productDto);
        }

        [HttpGet]
        public IActionResult StockDetails(int id) 
        {
            var stocksFromRepository = _repository.GetStocks(id);
            return PartialView("_DetailStocksModalPartial", stocksFromRepository );
        }
    }
}
