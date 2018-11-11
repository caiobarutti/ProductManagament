using System;

namespace ProductManagement.Infra.Database._base
{
    public static class DatabaseConfiguration
    {
        public static string ConnectionString { get; set; }

        public static void Configure(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}