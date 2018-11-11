using System.Collections.Generic;

namespace ProductManagement.Domain._base
{
    public interface IRepositoryBase<T> where T : Entity
    {
        void Save(T Entity);
        void Update(T Entity);
        T GetById(string id);    
        void Remove(T Entity);
        List<T> GetAll();
    }
}