using System;
using MyApp.Core.Queries;

namespace MyApp.Movies.Queries.Genre
{
    public class GenreByIdQuery : IQuery<Models.Genre>, ILocalizedQuery
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Guid FallbackLanguageId { get; set; }
    }
}