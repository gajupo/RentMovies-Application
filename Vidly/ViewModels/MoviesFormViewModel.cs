using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesFormViewModel
    {
        /*
         * We copy some properties from the original model and put them as nullable add ? at the end the data type
         * whit this we will avoid default values to this propoerties like 0 for integers and the dafault date time fields
         */
        public IEnumerable<Genre> Genres { get; set; }
        
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MoviesFormViewModel()
        {
            //ensure that the @Html.HiddenFor(m => m.Id) is equal to 0 when a new moview is created
            Id = 0;
        }

        public MoviesFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}