using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using DotMoviesMVC.Models;

namespace DotMoviesMVC.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }

        public static readonly HttpClient OMDB = new HttpClient();

        public DbSet<Movie> Saved { get; set; }
    }
}