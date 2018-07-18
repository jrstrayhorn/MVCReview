using MVCReview.Models;
using MVCReview.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReview.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            // real world model would come from database
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //// another way to pass data is with view dictionary
            //// every controller has ViewData property
            //ViewData["Movie"] = movie;

            //// this property is added at run time because ViewBag is dynamic
            //// so we don't get compile time safety/checking
            //ViewBag.Movie = movie;

            // DONT USE VIEWDATA OR VIEWBAG results in fragile code

            //return View();

            //// Under the hood, MVC stores movie as a property of ViewData.Model
            //// ViewData is a ViewDataDictionary and can also be used as key, value
            //// pair.... using return View(movie) - automatically places object as ViewData.Model
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model

            // this is the one better way to pass data to a view
            //return View(movie);

            // going to send the view model now
            return View(viewModel);

            //return Content("Hello World!");
            //return HttpNotFound();
            // empty result
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        // attribute routing
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}