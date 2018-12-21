using AutoMapper;
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
            //Defensive programming can add noise/pollution to code

            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.SingleOrDefault(
                c => c.ID == newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.ID)).ToList();

            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

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