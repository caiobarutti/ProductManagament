using System;

namespace ProductManagement.Infra.Database._base
{
    public static class EnviromentConfiguration
    {
        public static string ConnectionString { get; set; }
        public static string RootPath { get; set; }

        public static void Configure(string connectionString, string rootPath)
        {
            ConnectionString = connectionString;
            RootPath = rootPath;
        }
    }
}