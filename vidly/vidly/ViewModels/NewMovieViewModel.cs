using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string FormTitle
        {
            get
            {
                return (Movie == null || Movie.ID == 0) ? "New Movie" : "Edit Movie";
            }
        }
    }
}