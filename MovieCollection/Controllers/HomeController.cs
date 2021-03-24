using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using MovieCollection.Models.ViewModels;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieContext _context {get; set;}
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, MovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        [HttpGet]
        public IActionResult AddMovie() => View();

        [HttpPost]
        public IActionResult AddMovie(Movies movieResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieResponse);
                _context.SaveChanges();
            }
            return View("MovieList", _context.Movies);
        }

        [HttpGet]
        public IActionResult EditMovie(int MovieID)
        {
            Movies movies = _context.Movies.Where(x => x.MovieID == MovieID).FirstOrDefault();
            return View(movies);
        }

        [HttpPost]
        public IActionResult EditMovie(Movies editResponse, int MovieID)
        {
            if (ModelState.IsValid)
            {
                _context.Update(editResponse);
                _context.SaveChanges();
            }
            return View("MovieList", _context.Movies);
        }

        public IActionResult DeleteMovie(int MovieID)
        {
            var movie = _context.Movies.Where(x => x.MovieID == MovieID).FirstOrDefault();
            _context.Remove(movie);
            _context.SaveChanges();
            return View("MovieList", _context.Movies);
        }

        [HttpGet]
        public IActionResult MovieList() => View(_context.Movies);

        [HttpGet]
        public IActionResult Confirmation() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
