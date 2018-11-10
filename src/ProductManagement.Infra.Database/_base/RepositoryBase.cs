using System.Collections.Generic;
using ProductManagement.Domain._base;
using MongoDB.Driver;

namespace ProductManagement.Infra.Database._base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<T> Collection { get; }

        public RepositoryBase()
        {
            var cliente = new MongoClient("mongodb://localhost:27017");
            Database = cliente.GetDatabase("product-management");
            Collection = Database.GetCollection<T>(typeof(T).Name);
        }

        public void Save(T entity)
        {
            Collection.InsertOne(entity);
        }

        public void Update(T entity)
        {
            Collection.ReplaceOne(f => f.Id == entity.Id, entity);
        }

        public T GetById(string id)
        {
            var documents = Collection.Find("{ _id:'"+ id +"' }");

            if(documents != null && documents.Any())
                return documents.Single();

            return null;
        }

        public void Remove(T entity) {
            Collection.DeleteOne(f => f.Id == entity.Id);
        }
    }
}