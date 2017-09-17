using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}