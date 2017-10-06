using System;
using MyApp.Core.Commands;

namespace MyApp.Movies.Commands.Movie
{
    public class AddMovieTranslationCommand : ICommand
    {
        public Guid MovieId { get; set; }
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}