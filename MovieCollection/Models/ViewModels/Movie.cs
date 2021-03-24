using System;
using System.Collections.Generic;

namespace MovieCollection.Models.ViewModels
{
    public class Movie
    {
        public Movie()
        {
        }
        public IEnumerable<Movies> SelectedMovie { get; set; }

    }
}
