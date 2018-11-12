using System.Collections.Generic;

namespace ProductManagement.Domain._base
{
    public interface IJsonRepositoryBase<T> where T : Entity
    {
        void SaveAll(IEnumerable<T> list);
        void RemoveAllJson(string entityName);
    }
}