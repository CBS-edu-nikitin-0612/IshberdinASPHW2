﻿using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductReader _reader;

        // ВНИМАНИЕ.
        // Каждый запрос обрабатывает новый экземпляр контроллера.
        // Конструктор будет вызываться перед вызовом метода List и метода Details
        // После обработки запроса, экземпляр контроллера будет удален из памяти
        public ProductsController()
        {
            _reader = new ProductReader();
        }


        public IActionResult List(string param)
        {
            List<Product> products = _reader.ReadFromFile(); ;
            if (param != null)
                products = products.Where(p => p.Category.ToUpper() == param.ToUpper()).ToList();
            else 
                products = products.ToList();
            // Возврат представления List и передача представлению модели в виде коллекции products
            // Получить доступ к коллекции в представлении можно будет через свойство представления Model
            return View(products);
        }

        // Products/Details/1
        public IActionResult Details(int param)
        {
            List<Product> products = _reader.ReadFromFile();
            Product product = products.Where(x => x.Id == param).FirstOrDefault();

            if (product != null)
            {
                // Возврат представления с именем Details и передача представлению экземпляра product
                // В представление доступ к экземпляру можно получить через свойство представления Model
                return View(product);
            }
            else
            {
                // Возврат ошибки 404
                return NotFound();
            }
        }
    }
}