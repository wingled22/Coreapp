using AutoMapper;
using CoreApp.Entities;
using CoreApp.Models;
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
        public IEnumerable<Products> GetProducts()
        {
            return _capstoneContext.Products.Include(p => p.Category).Include(p => p.Store).ToList();
        }

        //public IEnumerable<ProductDto> GetProductDTO()
        //{
     

        //    var productDto = new List<ProductDto>();
        //    var prod = _capstoneContext.Products.Include(p => p.Category).Include(p => p.Store).ToList();
            
        //    pro

        //    return ;
        //}

        //get specific by id
        public Products GetProduct(int id)
        {
            return _capstoneContext.Products
                .FirstOrDefault(x => (x.Id == id));
        }

       public bool ProductExists(int id)
        {
            return _capstoneContext.Products
                .Any(x => x.Id == id);
        }

        public void Save(Products products)
        {
            _capstoneContext.Add(products);

        }

        public void Update(Products products)
        {
            _capstoneContext.Update(products);
        }

        public void Delete(int id)
        {
            var productFromRepository = _capstoneContext.Products.Find(id);
            _capstoneContext.Products.Remove(productFromRepository);
        }

        public void AddStocks(ProductViewModel productDto) {

            var stocksToBeAdded = productDto.StocksToAdd;
            var productId = productDto.Id;

            bool stockExist = _capstoneContext.Stocks.Any(p => p.ProductId == productId);
            if (!stockExist)
            {
                Stocks stockToAdd = new Stocks() { ProductId = productId, TotalStocks = 0 };
                _capstoneContext.Stocks.Add(stockToAdd);
                _capstoneContext.SaveChanges();
                var recentAddedStock = _capstoneContext.Stocks.OrderByDescending(p => p.Id).FirstOrDefault();

                StocksHistory stocksHistory = new StocksHistory() { StockId = recentAddedStock.Id, DateAdded = DateTime.Now };
                _capstoneContext.StocksHistory.Update(stocksHistory);
                _capstoneContext.SaveChanges();

                recentAddedStock.TotalStocks = recentAddedStock.TotalStocks + stocksToBeAdded;
                _capstoneContext.Stocks.Update(recentAddedStock);
            }
            else
            {
                var recentAddedStock = _capstoneContext.Stocks.Where(p => p.ProductId == productId).OrderByDescending(p => p.Id).FirstOrDefault();

                StocksHistory stocksHistory = new StocksHistory() { StockId = recentAddedStock.Id, DateAdded = DateTime.Now };
                _capstoneContext.StocksHistory.Update(stocksHistory);
                _capstoneContext.SaveChanges();

                recentAddedStock.TotalStocks = recentAddedStock.TotalStocks + stocksToBeAdded;
                _capstoneContext.Stocks.Update(recentAddedStock);
            }
           



            

        }

        public Stocks GetStocks(int id) {
            return _capstoneContext.Stocks.Where(p => p.ProductId == id).FirstOrDefault();
        }
    }
}
