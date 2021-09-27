using System.Collections.Generic;

namespace ShopApi.DatabaseLayer.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetAll();

        T GetByName(string name);

        T GetById(int id);
    }
}
