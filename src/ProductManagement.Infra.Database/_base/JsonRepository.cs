using System.IO;
using System.Linq;

namespace ProductManagement.Infra.Database._base
{
    public static class JsonRepository
    {
        public static void SaveJson<T>(T entity)
        {
            Directory.CreateDirectory(EnviromentConfiguration.RootPath);
            var entityFileName = $"{typeof(T).Name}.json";
            var fullFilePath = $"{EnviromentConfiguration.RootPath}/{entityFileName}";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(entity);

            var lines = File.Exists(fullFilePath) ? File.ReadAllLines(fullFilePath) : new string[0];

            File.WriteAllLines(fullFilePath, lines.Any() ? lines.Take(lines.Length - 1).ToArray() : new[] {"["});

            using (var file = File.AppendText(fullFilePath))
            {
                file.WriteLine($"{json},");
                file.WriteLine("]");
            }
        }

        public static void RemoveAllJson(string entityName)
        {
            Directory.CreateDirectory(EnviromentConfiguration.RootPath);
            var entityFileName = $"{entityName}.json";
            var fullFilePath = $"{EnviromentConfiguration.RootPath}/{entityFileName}";

            File.Delete(fullFilePath);
        }
    }
}