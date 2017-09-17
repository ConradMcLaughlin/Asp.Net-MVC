using System.Collections.Generic;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}