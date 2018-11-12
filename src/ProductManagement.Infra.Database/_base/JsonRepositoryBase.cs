using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProductManagement.Domain._base;

namespace ProductManagement.Infra.Database._base
{
    public class JsonRepositoryBase<T> : IJsonRepositoryBase<T> where T : Entity
    {
        public string EntityName { get; }

        public JsonRepositoryBase(string entityName)
        {
            EntityName = entityName;
        }

        public void SaveAll(IEnumerable<T> list)
        {
            Directory.CreateDirectory(EnviromentConfiguration.RootPath);
            var entityFileName = $"{EntityName}.json";
            var fullFilePath = $"{EnviromentConfiguration.RootPath}/{entityFileName}";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            File.WriteAllText(fullFilePath, json);
        }

        public void RemoveAllJson(string entityName)
        {
            Directory.CreateDirectory(EnviromentConfiguration.RootPath);
            var entityFileName = $"{entityName}.json";
            var fullFilePath = $"{EnviromentConfiguration.RootPath}/{entityFileName}";

            File.Delete(fullFilePath);
        }
    }
}