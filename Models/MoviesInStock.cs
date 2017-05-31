using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class MoviesInStock : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            
            if(movie.NumberInStock == 0 || movie.NumberInStock > 20)
            {
                return new ValidationResult("Number must be between 1 and 20");
            }

            return ValidationResult.Success;

        }
    }
}