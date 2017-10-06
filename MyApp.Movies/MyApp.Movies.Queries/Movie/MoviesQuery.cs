using System;
using System.Collections.Generic;
using MyApp.Core.Queries;

namespace MyApp.Movies.Queries.Movie
{
    public class MoviesQuery : IQuery<IEnumerable<Models.Movie>>, ILocalizedQuery, IPagedQuery, IOrderedQuery
    {
        public string Title { get; set; }
        public byte AgeFrom { get; set; }
        public DateTime ReleaseDateFrom { get; set; }
        public DateTime ReleaseDateTo { get; set; }
        public IEnumerable<Guid> GenreIds { get; set; }
        public IEnumerable<Guid> CountryIds { get; set; }

        public Guid LanguageId { get; set; }
        public Guid FallbackLanguageId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IDictionary<string, SortOrder> Order { get; set; }
    }
}