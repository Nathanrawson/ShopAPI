using System.Collections.Generic;

namespace ShopApi.Models
{
    public class ProductsModel
    {
      public List<ProductModel> Products { get; set;  } = new List<ProductModel>();
    }
}
