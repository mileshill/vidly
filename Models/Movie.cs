using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie title")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Please enter release date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Added {get; set; }
        
        [Required(ErrorMessage = "Please enter number in stock")]
        [Display(Name = "Number In Stock")]

        [MoviesInStock]
        public int NumberInStock {get; set;}
        
    }
}