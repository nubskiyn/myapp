using System;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace MyApp.Data
{
    public class DbConnectionFactoryConfiguration
    {
        /// <summary>
        /// Регистрирует фабрику 
        /// </summary>
        /// <param name="invariant">Уникальное имя провайдера данных</param>
        /// <param name="factory"></param>
        public static void RegisterFactory(string invariant, DbProviderFactory factory)
        {
            if (DbConnectionFactory.Factories.ContainsKey(invariant))
                throw new InvalidOperationException($"{invariant} is already registered.");

            DbConnectionFactory.Factories.Add(invariant, factory);
        }

        /// <summary>
        /// Получает настройки подключений
        /// </summary>
        /// <param name="configuration">Настройки приложения</param>
        public static void LoadConnectionStrings(IConfiguration configuration)
        {
            var connectionStringCollection = configuration.GetSection("ConnectionStrings").Get<ConnectionStringSettingsCollection>();
            DbConnectionFactory.ConnectionStrings = connectionStringCollection ?? new ConnectionStringSettingsCollection();
        }
    }
}