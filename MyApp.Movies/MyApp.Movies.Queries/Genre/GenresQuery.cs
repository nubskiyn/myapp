using System;
using System.Collections.Generic;
using MyApp.Core.Queries;

namespace MyApp.Movies.Queries.Genre
{
    public class GenresQuery: IQuery<IEnumerable<Models.Genre>>, ILocalizedQuery
    {
        public Guid LanguageId { get; set; }
        public Guid FallbackLanguageId { get; set; }
    }
}