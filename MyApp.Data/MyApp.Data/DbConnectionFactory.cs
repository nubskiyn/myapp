using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MyApp.Data
{
    public static class DbConnectionFactory
    {
        internal static Dictionary<string, DbProviderFactory> Factories { get; set; } = new Dictionary<string, DbProviderFactory>();
        internal static ConnectionStringSettingsCollection ConnectionStrings { get; set; } = new ConnectionStringSettingsCollection();

        /// <summary>
        /// Возвращает соединение с БД
        /// </summary>
        /// <param name="connectionStringName">Название подключения</param>
        /// <returns>Соединение с БД</returns>
        public static IDbConnection GetConnection(string connectionStringName)
        {
            if (!ConnectionStrings.TryGetValue(connectionStringName, out var settings))
                throw new KeyNotFoundException($"Connection string with name '{connectionStringName}' doesn't exist.");

            if (!Factories.TryGetValue(settings.ProviderName, out var factory))
                throw new KeyNotFoundException($"Provider '{settings.ProviderName}' is not registered.");

            var connection = factory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;

            return connection;
        }

        /// <summary>
        /// Возвращает соединение с БД
        /// </summary>
        /// <param name="nameOrConnectionString">Строка подключения или название подключения</param>
        /// <param name="providerName">Название провайдера</param>
        /// <returns>Соединение с БД</returns>
        public static IDbConnection GetConnection(string nameOrConnectionString, string providerName)
        {
            if (!Factories.TryGetValue(providerName, out var factory))
                throw new KeyNotFoundException($"Provider '{providerName}' is not registered.");

            var connection = factory.CreateConnection();
            connection.ConnectionString =
                ConnectionStrings[nameOrConnectionString]?.ConnectionString ?? nameOrConnectionString;

            return connection;
        }
    }
}
