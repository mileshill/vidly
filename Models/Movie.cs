using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Added {get; set; }
        
        [Required]
        public int NumberInStock {get; set;}
        
    }
}