using DotMoviesMVC.Data;
using DotMoviesMVC.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotMoviesMVC.Services
{
    public class DotMoviesMVCService
    {
        private readonly MoviesDbContext _context;

        public DotMoviesMVCService(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Get(string id)
        {
            //Dummy data from OMDB
            string json = await MoviesDbContext.OMDB.GetStringAsync($"http://www.omdbapi.com/?apikey=3877efa0&i={id}&plot=full");
            Movie movie = JsonConvert.DeserializeObject<Movie>(json);

            List<Movie> savedMovies = await _context.Saved.ToListAsync();
            if (savedMovies.Any(m => m.imdbId == movie.imdbId))
            {
                movie.Saved = true;
            }

            return movie;
        }

        public async Task<List<Movie>> Search(string title)
        {

            if (title == null)
            {
                title = "";
            }

            //Dummy data from OMDB
            string json = await MoviesDbContext.OMDB.GetStringAsync($"http://www.omdbapi.com/?apikey=3877efa0&s={title}");
            OMDBResponse omdb = JsonConvert.DeserializeObject<OMDBResponse>(json);

            List<Movie> savedMovies = await _context.Saved.ToListAsync();

            foreach (Movie movie in omdb.Search)
            {
                if (savedMovies.Any(m => m.imdbId == movie.imdbId))
                {
                    movie.Saved = true;
                }
            }
            await _context.SaveChangesAsync();

            return omdb.Search;
        }

        public async Task<List<Movie>> Get()
        {
            return await _context.Saved.ToListAsync();
        }

        public async Task<Movie> Save(Movie movie)
        {
            movie.Saved = true;
            _context.Saved.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> Delete(string id)
        {
            var movie = await _context.Saved.FindAsync(id);
            _context.Saved.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

    }
}
