using System;
using MyApp.Core.Commands;

namespace MyApp.Movies.Commands.Movie
{
    public class DeleteMovieCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}