using System;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {

        ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var viewModel = new MoviesViewModel()
            {
                Movies = _context.Movies.Include(c => c.Genre).ToList()
            };
            return View(viewModel);
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.ID == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.ID == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.ID == movie.ID);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            
            return View("MovieForm", viewModel);
        }
    }
}