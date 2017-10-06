using System;
using MyApp.Core.Queries;

namespace MyApp.Movies.Queries.Movie
{
    public class MovieById : IQuery<Models.Movie>, ILocalizedQuery
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Guid FallbackLanguageId { get; set; }
    }
}