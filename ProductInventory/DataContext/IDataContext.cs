using System;
using System.Collections.Generic;
using ProductInventory.Models;

namespace ProductInventory.DataContext
{
    public interface IDataContext
    {
        public void SaveData(List<Product> products);

        public List<Product> GetData();

        public Product GetProduct(string productId);

        public void SaveProduct(Product product);
     }
}
