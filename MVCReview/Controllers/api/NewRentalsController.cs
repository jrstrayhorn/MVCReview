using MVCReview.Dtos;
using MVCReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCReview.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();    
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            // if using optimistic approach then dont use many if check blocks
            // defensive
            //if (newRentalDto.MovieIds.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            // load customer and movie on id with dto
            // for each movie, create new rental for customer and add to database
            // use SingleOrDefault for public apis
            // use Single and allow error to throw
            // defensive - use SingleOrDefault
            // optimistic - use Single
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            // defensive - if using public api for different applications and teams
            // lots of conditional statements, noise
            //if (customer == null)
            //    return BadRequest("CustomerId is not valid.");

            var moviesToRent = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            // defensive
            //if (moviesToRent.Count != newRentalDto.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            // iteration will execute the query no need for .ToList() call
            foreach (var movie in moviesToRent)
            {
                // defensive - keep this
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                _context.Rentals.Add(
                    new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    });
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
