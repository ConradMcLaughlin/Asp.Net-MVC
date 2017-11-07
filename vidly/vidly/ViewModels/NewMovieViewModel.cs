using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieFormViewModel
    {
        [Required]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string FormTitle
        {
            get
            {
                return (ID == null || ID == 0) ? "New Movie" : "Edit Movie";
            }
        }

        public MovieFormViewModel()
        {
            ID = 0;
            DateAdded = DateTime.Now;
        }

        public MovieFormViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            DateAdded = movie.DateAdded;
            GenreId = movie.GenreId;
        }

    }
}