using System.Collections.Generic;

namespace ProductManagement.Domain._base
{
    public interface IRepositoryBase<T> where T : Entity
    {
        void Save(T Entity);
        List<T> GetAll();
        void RemoveAll();
    }
}