using System.Collections;
using System.Collections.Generic;

namespace MyApp.Data
{
    public class ConnectionStringSettingsCollection : IDictionary<string, ConnectionStringSettings>
    {
        private readonly Dictionary<string, ConnectionStringSettings> _connectionStrings;

        public ConnectionStringSettingsCollection()
        {
            _connectionStrings = new Dictionary<string, ConnectionStringSettings>();
        }

        public ConnectionStringSettingsCollection(int capacity)
        {
            _connectionStrings = new Dictionary<string, ConnectionStringSettings>(capacity);
        }

        #region IEnumerable methods
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_connectionStrings).GetEnumerator();
        }
        #endregion

        #region IEnumerable<> methods
        IEnumerator<KeyValuePair<string, ConnectionStringSettings>> IEnumerable<KeyValuePair<string, ConnectionStringSettings>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, ConnectionStringSettings>>)_connectionStrings).GetEnumerator();
        }
        #endregion

        #region ICollection<> methods
        void ICollection<KeyValuePair<string, ConnectionStringSettings>>.Add(KeyValuePair<string, ConnectionStringSettings> item)
        {
            ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)_connectionStrings).Add(item);
        }

        void ICollection<KeyValuePair<string, ConnectionStringSettings>>.Clear()
        {
            _connectionStrings.Clear();
        }

        bool ICollection<KeyValuePair<string, ConnectionStringSettings>>.Contains(KeyValuePair<string, ConnectionStringSettings> item)
        {
            return ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)_connectionStrings).Contains(item);
        }

        void ICollection<KeyValuePair<string, ConnectionStringSettings>>.CopyTo(KeyValuePair<string, ConnectionStringSettings>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)_connectionStrings).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, ConnectionStringSettings>>.Remove(KeyValuePair<string, ConnectionStringSettings> item)
        {
            return ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)_connectionStrings).Remove(item);
        }

        public int Count => _connectionStrings.Count;
        public bool IsReadOnly => ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)_connectionStrings).IsReadOnly;
        #endregion

        #region IDictionary<> methods
        public void Add(string key, ConnectionStringSettings value)
        {
            // NOTE only slight modification, we add back in the Name of connectionString here (since it is the key)
            value.Name = key;
            _connectionStrings.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _connectionStrings.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _connectionStrings.Remove(key);
        }

        public bool TryGetValue(string key, out ConnectionStringSettings value)
        {
            return _connectionStrings.TryGetValue(key, out value);
        }

        public ConnectionStringSettings this[string key]
        {
            get => _connectionStrings[key];
            set => Add(key, value);
        }

        public ICollection<string> Keys => _connectionStrings.Keys;
        public ICollection<ConnectionStringSettings> Values => _connectionStrings.Values;
        #endregion
    }
}