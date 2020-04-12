using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotMoviesMVC.Models
{
    public class DetailViewModel
    {

        public DetailViewModel()
        {

        }

        public Movie Movie { get; set; } = new Movie();
    }
}
