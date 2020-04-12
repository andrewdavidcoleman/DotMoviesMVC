using DotMoviesMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotMoviesMVC.Models
{
    public class SavedViewModel
    {

        public SavedViewModel()
        {

        }

        public IList<Movie> Movies { get; set; }

        public bool IsTableView { get; set; } = false;
    }
}
