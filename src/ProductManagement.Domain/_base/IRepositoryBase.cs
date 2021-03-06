using System.Collections.Generic;

namespace ProductManagement.Domain._base
{
    public interface IRepositoryBase<T> where T : Entity
    {
        void SaveAll(IEnumerable<T> list);
        List<T> GetAll();
        void RemoveAll();
    }
}