using CoreApp.Entities;
using CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts();

        Products GetProduct(int id);

        bool ProductExists(int id);

        void Save(Products products);

        void Update(Products products);

        void Delete(int id);
        void AddStocks(ProductViewModel productDto);

        Stocks GetStocks(int id);

    }
}