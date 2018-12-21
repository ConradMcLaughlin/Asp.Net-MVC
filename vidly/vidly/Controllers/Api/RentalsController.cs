using System;
using System.Linq;
using System.Web.Http;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //Need to dispose the context.
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto newRental)
        {
            //1) Load Customer and Movies
            //2) For each Movie add a new Rental Object with the Customer and that Movie
            //   then add to the Database
            //3) Use PostMan to test that the method works

            var customer = _context.Customers.Single(
                c => c.ID == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.ID));

            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}