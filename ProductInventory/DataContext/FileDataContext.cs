using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ProductInventory.Models;

namespace ProductInventory.DataContext
{
    public class FileDataContext : IDataContext
    {
        private IFileReadWrite fileReadWrite;
        private string filePath;

        public FileDataContext(string filePath)
        {
            this.fileReadWrite = new FileReadWrite(filePath);
            this.filePath = filePath;
        }

        public void SaveData(List<Product> products)
        {
            var productJson = JsonConvert.SerializeObject(products);

            JsonSerializer jsonSerializer = new JsonSerializer();
            File.WriteAllText(this.filePath, productJson);
        }

        public List<Product> GetData()
        {
            // if there is no data - the file is yet to be created, seed data right now
            if (!File.Exists(this.filePath))
            {
                var seedData = this.SeedData();
                this.SaveData(seedData);
            }

            var jsonText = File.ReadAllText(this.filePath);

            var products
                = JsonConvert.DeserializeObject<List<Product>>(jsonText);

            return products;

        }

        private List<Product> SeedData()
        {
            var products = new List<Product>();

            products.Add(new Product()
            {
                BrandId = "Brand1",
                BrandName = "ALDI",
                Name = "DamenSneakers",
                Price = 0,
                ProductId = "Product1",
                SupplierId = "Supplier1",
                SupplierName = "Supplier1",
                Comments = string.Empty
            });

            products.Add(new Product()
            {
                BrandId = "Brand1",
                BrandName = "ALDI",
                Name = "DamenBallerina",
                Price = 0,
                ProductId = "Product2",
                SupplierId = "Supplier1",
                SupplierName = "Supplier1",
                Comments = string.Empty
            });

            products.Add(new Product()
            {
                BrandId = "Brand3",
                BrandName = "ALDI",
                Name = "DamenSocken",
                Price = 0,
                ProductId = "Product3",
                SupplierId = "Supplier3",
                SupplierName = "Supplier3",
                Comments = string.Empty
            });

            return products;
        }

        public Product GetProduct(string productId)
        {

            var jsonText = File.ReadAllText(this.filePath);

            var products
                = JsonConvert.DeserializeObject<List<Product>>(jsonText);

            return products.Find(x => x.ProductId == productId);

        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
