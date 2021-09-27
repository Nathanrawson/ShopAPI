using ShopApi.DatabaseLayer.Interfaces;
using ShopApi.Models;

namespace ShopApi.Managers.Interfaces
{
    public interface IProductsManager: IBaseRepository<ProductsModel>
    {
        ProductsModel GetByCategoryId(int categoryId);
    }
}
