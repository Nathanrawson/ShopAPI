using System;

namespace ShopApi.Models
{
    public class ProductModel
    {
        public int SKU { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int CategoryId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal Price { get; set; }
    }
}
