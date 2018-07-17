using MVCReview.Models;
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

            return View(movie);
        }
    }
}