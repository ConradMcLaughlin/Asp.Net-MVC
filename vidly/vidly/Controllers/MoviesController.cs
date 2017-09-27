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

        //Movies/Edit/1
        //Movies/Edit?id=1
        public ActionResult Edit(int id)
        {
            return Content(string.Format("id = {0}", id));
        }



        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("year={0}&month={1}", year, month));
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek", ID = 1 };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
        }

    }
}