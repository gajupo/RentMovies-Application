﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewmodel = new MoviesFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", viewmodel);
        }
        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek" };
        //    //ViewData["Movie"] = movie;
        //    //ViewBag.Movie = movie;

        //    var customers = new List<Customer> 
        //    {
        //        new Customer {Name = "customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };


        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);

        //    //return Content("Hello world");
        //    //return HttpNotFound();
        //    //return new EmptyResult();
        //    //return RedirectToAction("Index", "Home", new { page=1, sortBy="Name"});
        //}
        //movies
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View("List");

        }

        public ActionResult Details(int id)
        {

            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);

            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MoviesFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}