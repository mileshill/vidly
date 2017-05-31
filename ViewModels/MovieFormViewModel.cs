using System.Collections.Generic;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public List<string> Genres { get; set; }
        public Movie Movie { get; set; }

    }
}