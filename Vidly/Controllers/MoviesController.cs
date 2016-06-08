using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            var customers = new List<Customer> 
            {
                new Customer {Name = "customer 1"},
                new Customer {Name = "Customer 2"}
            };


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //return Content("Hello world");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page=1, sortBy="Name"});
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        //movies
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Avengers 2"
                },
                new Movie
                {
                    Id = 2,
                    Name = "In Time"
                }
            };

            return View("List", movies);

        }

        public ActionResult Details(int id)
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Avengers 2"
                },
                new Movie
                {
                    Id = 2,
                    Name = "In Time"
                }
            };

            var movie = movies.SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{

        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("pageIdex={0}&sortBy={1}",pageIndex,sortBy));


        //}
        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}