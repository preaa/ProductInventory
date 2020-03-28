using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.DataContext;
using ProductInventory.Models;


namespace ProductInventory.Controllers
{
    public class ProductController : Controller
    {

        static private IDataContext DataContext = new FileDataContext("ProductInventoryData.json");
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            try
            {
                // return a list of available products, and ask for user to enter some values
                var productList = DataContext.GetData();
                return View(productList);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // Post: /<controller>/
        [HttpPost]
        public IActionResult Update(Product product)
        {
            try
            {

                var products = DataContext.GetData();

                // create a new list with this updated product
                // and write it back to the file

                var newProducts = new List<Product>();

                foreach (var p in products)
                {
                    if (p.ProductId == product.ProductId)
                    {
                        // copy the values
                        p.Name = product.Name;
                        p.Price = product.Price;
                        p.BrandId = product.BrandId;
                        p.BrandName = product.BrandName;
                        p.SupplierId = product.SupplierId;
                        p.SupplierName = product.SupplierName;
                        p.Comments = product.Comments;
                    }

                    newProducts.Add(p);

                }

                DataContext.SaveData(newProducts);

                return RedirectToAction("Index");

            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        [HttpGet]
        public IActionResult Edit(string productId)
        {
            try
            {

                var product = DataContext.GetProduct(productId);

                return View(product);
              
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}

