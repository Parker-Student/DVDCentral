using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.BL;


namespace PF.DVDCentral.API.Controllers
{
    public class MovieController : ApiController
    {
        // GET: api/Movie
        // GET: api/Movie
        public IEnumerable<Movie> Get()
        {
            List<Movie> movies = MovieManager.Load();
            return movies;
        }

        // GET: api/Movie/5
        public Movie Get(int id)
        {
            Movie movie = MovieManager.LoadById(id);
            return movie;
        }

        // POST: api/Movie
        public void Post([FromBody]Movie movie)
        {
            MovieManager.Insert(movie);

        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]Movie movie)
        {
            MovieManager.Update(movie);
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
            MovieManager.Delete(id);
        }
    }
}
