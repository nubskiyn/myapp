namespace MyApp.Core.Queries
{
    /// <summary>
    /// Запрос с пагинацией
    /// </summary>
    public interface IPagedQuery
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Количество записей на странице
        /// </summary>
        int PageSize { get; set; }
    }
}