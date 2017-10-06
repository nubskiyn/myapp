using System;

namespace MyApp.Core.Queries
{
    /// <summary>
    /// Переводимый запрос
    /// </summary>
    public interface ILocalizedQuery
    {
        /// <summary>
        /// Идентификатор языка
        /// </summary>
        Guid LanguageId { get; set; }

        /// <summary>
        /// Идентификатор языка по умолчанию
        /// </summary>
        Guid FallbackLanguageId { get; set; }
    }
}