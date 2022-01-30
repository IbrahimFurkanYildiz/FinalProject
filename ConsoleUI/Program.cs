﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //IoC Container
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var product in productManager.GetByUnitPrice(22, 50))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
