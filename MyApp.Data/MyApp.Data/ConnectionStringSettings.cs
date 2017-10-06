namespace MyApp.Data
{
    /// <summary>
    /// Настройки строки подключения
    /// </summary>
    public class ConnectionStringSettings
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Строка подключения
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Название провайдера данных
        /// </summary>
        public string ProviderName { get; set; }

        protected bool Equals(ConnectionStringSettings other)
        {
            return string.Equals(Name, other.Name) && string.Equals(ConnectionString, other.ConnectionString) && string.Equals(ProviderName, other.ProviderName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ConnectionStringSettings)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConnectionString != null ? ConnectionString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProviderName != null ? ProviderName.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return !Equals(left, right);
        }
    }
}