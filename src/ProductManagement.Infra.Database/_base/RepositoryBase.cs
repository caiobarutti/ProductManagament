using System.Collections.Generic;
using ProductManagement.Domain._base;
using MongoDB.Driver;
using System.Security.Authentication;

namespace ProductManagement.Infra.Database._base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<T> Collection { get; }

        public RepositoryBase()
        {
            var connectionString = EnviromentConfiguration.ConnectionString;
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            
            var cliente = new MongoClient(EnviromentConfiguration.ConnectionString);
            Database = cliente.GetDatabase("product-management");
            Collection = Database.GetCollection<T>(typeof(T).Name);
        }

        public void SaveAll(IEnumerable<T> list)
        {
            Collection.InsertMany(list);
        }

        public List<T> GetAll()
        {
            return Collection.Find("{}").ToList();
        }

        public void RemoveAll()
        {
            Database.DropCollection(typeof(T).Name);
        }
    }
}