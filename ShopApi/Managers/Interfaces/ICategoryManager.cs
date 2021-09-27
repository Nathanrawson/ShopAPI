using ShopApi.DatabaseLayer.Interfaces;
using ShopApi.Models;
using System.Collections.Generic;

namespace ShopApi.Managers.Interfaces
{
    public interface ICategoryManager : IBaseRepository<List<CategoryModel>>
    {
    }
}
