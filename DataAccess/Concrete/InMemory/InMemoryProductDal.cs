﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // naming convension // Alt çizgi ile tanımlama global değişken olduğunu belirtmektedir. 
        public InMemoryProductDal()
        {
            //Oracle, SQL Server, Postgre, MongoDb
            _products = new List<Product>
            {
                new Product{ProductID = 1,CategoryId=1,ProductName = "Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductID = 2,CategoryId=1,ProductName = "Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductID = 3,CategoryId=2,ProductName = "Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductID = 4,CategoryId=2,ProductName = "Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductID = 5,CategoryId=2,ProductName = "Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID); // LINQ : foreach döngüsünün kısa metot versiyonudur. 

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderilen ürün Id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
