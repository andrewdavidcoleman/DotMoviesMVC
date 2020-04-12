using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotMoviesMVC.Models
{
    public class ResultsViewModel
    {

        public ResultsViewModel()
        {

        }

        public IList<Movie> Movies { get; set; } = new List<Movie>();

        public bool IsTableView { get; set; } = false;
    }
}
