using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotMoviesMVC.Models
{
    public class OMDBResponse
    {
        public List<Movie> Search { get; set; } = new List<Movie>();
        public int totalResults { get; set; }
        public bool Response { get; set; }
    }
}
