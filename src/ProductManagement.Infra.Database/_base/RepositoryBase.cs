using System.Collections.Generic;
using ProductManagement.Domain._base;
using MongoDB.Driver;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace ProductManagement.Infra.Database._base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<T> Collection { get; }

        protected string DiskPath { get; }

        public RepositoryBase()
        {
            var connectionString = EnviromentConfiguration.ConnectionString;
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            
            var cliente = new MongoClient(EnviromentConfiguration.ConnectionString);
            Database = cliente.GetDatabase("product-management");
            Collection = Database.GetCollection<T>(typeof(T).Name);
        }

        public void Save(T entity)
        {
            Collection.InsertOne(entity);
            RepositoryBaseJson.SaveJson(entity);
        }

        public List<T> GetAll()
        {
            return Collection.Find("{}").ToList();
        }

        public void RemoveAll()
        {
            Collection.DeleteMany("{}");
            RepositoryBaseJson.RemoveAllJson(typeof(T).Name);
        }
    }
}