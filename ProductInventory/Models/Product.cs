using System;
namespace ProductInventory.Models
{
    public class Product
    {
        public Product()
        {
            
        }


        public string ProductId { get; set; }

        public string Name { get; set; }

        public string BrandId { get; set; }

        public string BrandName { get; set; }

        public double Price { get; set; }

        public string SupplierId { get; set; }

        public string SupplierName { get; set; }


        public string Comments{ get; set; }
    }

}
