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
                //Movies = HelperTools.TestMovies()
                Movies = _context.Movies.Include(c => c.Genre).ToList()
            };
            return View(viewModel);
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.ID == id);
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

            //return View(movie);
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

    }


    #region "Old Code"
    //[Route("movies/details/{id}")]
    //public ActionResult Details(int? id)
    //{
    //    if (!id.HasValue)
    //        return RedirectToAction("Index");
    //    else
    //        return View(HelperTools.TestMovies()[(int)id - 1]);
    //}

    ////movies
    ////movies?pageIndex=3
    ////movies?pageIndex=3&sortBy=ReleaseDate
    ////movies?sortBy=Rating
    //public ActionResult Index(int? pageIndex, string sortBy)
    //{
    //    if (!pageIndex.HasValue)
    //        pageIndex = 1;

    //    if (String.IsNullOrEmpty(sortBy))
    //        sortBy = "Name";

    //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
    //}

    //partial class HelperTools
    //{
    //    internal static List<Movie> TestMovies()
    //    {
    //        return new List<Movie>
    //        {
    //            new Movie { ID = 1, Name = "Shrek"},
    //            new Movie { ID = 2, Name = "Wall-E"},
    //        };
    //    }
    //}

    #endregion


}