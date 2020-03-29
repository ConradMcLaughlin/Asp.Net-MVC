using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using vidly.Dtos;
using vidly.Models;
using System.Data.Entity;

namespace vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/Movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(c => c.Genre)
                .Where(c => c.NumberAvailable > 0);
            
            if (!String.IsNullOrWhiteSpace(query))
                movieQuery.ToList().Where(c => c.Name.Contains(query));

            var movieDtos = movieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        //GET api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
        
        //POST api/Movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.ID = movie.ID;

            return Created(new Uri(string.Format("{0}/{1}", Request.RequestUri, movie.ID)), movieDto);
        }

        //PUT api/Movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.ID == movieDto.ID);

            if (movieInDb == null)
                return NotFound();
            
            Mapper.Map(movieDto, movieInDb);
            
            return Ok(_context.SaveChanges());
        }

        //DELETE api/Movie/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);

            return Ok(_context.SaveChanges());
        }
    }
}