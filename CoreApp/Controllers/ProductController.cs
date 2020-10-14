using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreApp.Models;

namespace CoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly CoreContext _context;

        public ProductController(CoreContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            //get all the products
            var coreContext = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Store);
            return View(await coreContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            //data to populate the selectlist
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,QuantityPerUnit,CategoryId,StoreId,Available")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Description", products.CategoryId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Address", products.StoreId);
            return View(products);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {   
            //validate if null 
            if (id == null)
            {
                return NotFound();
            }

            //get the product with the specified id of the request
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            //to populate the select list items
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", products.CategoryId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Name", products.StoreId);
            
            return View(products);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,QuantityPerUnit,CategoryId,StoreId,Available")] Products products)
        {
            //validate if the product id is null
            if (id != products.Id)
            {
                return NotFound();
            }

            //check if the state is valid
            if (ModelState.IsValid)
            {
                try
                {
                    //update
                    _context.Update(products);
                    //save changes
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Description", products.CategoryId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Address", products.StoreId);
            return View(products);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
