using System.Collections.Generic;

namespace MyApp.Core.Queries
{
    /// <summary>
    /// Сортируемый запрос
    /// </summary>
    public interface IOrderedQuery
    {
        /// <summary>
        /// Порядок сортировки полей
        /// </summary>
        IDictionary<string, SortOrder> Order { get; set; }
    }
}