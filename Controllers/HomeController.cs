using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotMoviesMVC.Models;
using DotMoviesMVC.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DotMoviesMVC.Services;

namespace DotMoviesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DotMoviesMVCService _service;

        public HomeController(DotMoviesMVCService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Results(string title, bool isTableView)
        {
            ResultsViewModel model = new ResultsViewModel();
            model.Movies = await _service.Search(title);
            model.IsTableView = isTableView;
            return View(model);
        }

        public async Task<IActionResult> Saved(bool isTableView)
        {
            SavedViewModel model = new SavedViewModel();
            model.Movies = await _service.Get();
            model.IsTableView = isTableView;
            return View(model);
        }

        public async Task<IActionResult> Detail(string id)
        {
            DetailViewModel model = new DetailViewModel();
            model.Movie = await _service.Get(id);
            return View(model);
        }

        public async Task<Movie> Save(string id)
        {
            Movie movie = await _service.Get(id);
            return await _service.Save(movie);
        }

        public async Task<Movie> Delete(string id)
        {
            Movie movie = await _service.Get(id);
            return await _service.Delete(id);
        }

    }
}
