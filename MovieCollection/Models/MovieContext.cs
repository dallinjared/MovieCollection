using System;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        { }
        public DbSet<Movies> Movies { get; set; }
    }
}
