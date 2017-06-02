using System;

namespace vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public DateTime Added {get; set; }
        
        public int NumberInStock {get; set;}
    }
}