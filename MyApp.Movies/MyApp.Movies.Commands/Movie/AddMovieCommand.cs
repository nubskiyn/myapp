using System;
using MyApp.Core.Commands;

namespace MyApp.Movies.Commands.Movie
{
    public class AddMovieCommand : ICommand
    {
        public Guid Id { get; set; }
        public byte AgeFrom { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}