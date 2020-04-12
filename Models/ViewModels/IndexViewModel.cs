using DotMoviesMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotMoviesMVC.Models
{
    public class IndexModel
    {
        private readonly MoviesDbContext _context;

        public IndexModel(MoviesDbContext context)
        {
            _context = context;
        }
    }
}
