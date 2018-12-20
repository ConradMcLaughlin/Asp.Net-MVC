using System;
using System.Web.Http;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto newRental)
        {
            throw new NotImplementedException();
        }
    }
}