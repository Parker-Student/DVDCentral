using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using PF.DVDCentral.MVCUI.ViewModels;

namespace PF.DVDCentral.MVCUI.Controllers
{
    public class MovieController : Controller
    {
        #region Pre-WebAPI
        List<Movie> movies;

        // GET: Movie

        public ActionResult Index()
        {


            if (Authenticate.IsAuthenticated())
            {
                movies = MovieManager.Load();
                ViewBag.Source = "Index";

                return View(movies);

            }
            else
            {
                return RedirectToAction("Login", "User");

            }
        }
        
        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = MovieManager.LoadById(id);
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {


            if (Authenticate.IsAuthenticated())
            {

                MovieGenresDirectorsRaitingsFormats pdts = new MovieGenresDirectorsRaitingsFormats();

                pdts.Genres = GenreManager.Load();
                pdts.Directors = DirectorManager.Load();
                pdts.Ratings = RatingManager.Load();
                pdts.Formats = FormatManager.Load();
                pdts.Movie = new Movie();

                return View(pdts);
            }
            else
            {
                return RedirectToAction("Login", "User");

            }
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieGenresDirectorsRaitingsFormats pdts)
        {
            try
            {
                if (pdts.File != null)
                {
                    pdts.Movie.ImagePath = pdts.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(pdts.File.FileName));
                    if (!System.IO.File.Exists(target))
                    {
                        pdts.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully...";
                    }
                    else
                    {
                        ViewBag.Message = "File Already Exists...";
                    }
                }

                // TODO: Add insert logic here
                MovieManager.Insert(pdts.Movie);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pdts);
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {



            if (Authenticate.IsAuthenticated())
            {
                MovieGenresDirectorsRaitingsFormats pdts = new MovieGenresDirectorsRaitingsFormats();
                pdts.Genres = GenreManager.Load();
                pdts.Directors = DirectorManager.Load();
                pdts.Ratings = RatingManager.Load();
                pdts.Formats = FormatManager.Load();
                pdts.Movie = MovieManager.LoadById(id);

                return View(pdts);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });

            }
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieGenresDirectorsRaitingsFormats pdts)
        {
            try
            {
                if (pdts.File != null)
                {
                    pdts.Movie.ImagePath = pdts.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(pdts.File.FileName));
                    if (!System.IO.File.Exists(target))
                    {
                        pdts.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully...";
                    }
                    else
                    {
                        ViewBag.Message = "File Already Exists...";
                    }
                }
                // TODO: Add update logic here
                MovieManager.Update(pdts.Movie);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pdts);
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                Movie movie = MovieManager.LoadById(id);
                return View(movie);
            }


            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });


            }
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                MovieManager.Delete(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
        #region "WebAPI"
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50409/api/");
            return client;
        }

        public ActionResult Get()
        {
            HttpClient client = InitializeClient();


            //Do the actual call to the WebAPI
            HttpResponseMessage response = client.GetAsync("Movie").Result;

            //Parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //Parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);

            //Parse the items into a list of movie
            List<Movie> movies = items.ToObject<List<Movie>>();

            ViewBag.Source = "Get";
            return View("Index", movies);
        }

        public ActionResult GetOne(int id)
        {
            HttpClient client = InitializeClient();


            //Do the actual call to the WebAPI
            HttpResponseMessage response = client.GetAsync("Movie/" + id).Result;

            //Parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //Parse the result into generic objects
            Movie movie = JsonConvert.DeserializeObject<Movie>(result);

            return View("Details", movie);
        }

        public ActionResult Insert()
        {
            HttpClient client = InitializeClient();

            MovieGenresDirectorsRaitingsFormats pdts = GetDegreeTypes(client);

            pdts.Movie = new Movie();

            return View("Create", pdts);
        }
        [HttpPost]
        public ActionResult Insert(MovieGenresDirectorsRaitingsFormats pdts)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Movie", pdts.Movie).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Create", pdts);
            }


        }
        public ActionResult Update(int id)
        {
            HttpClient client = InitializeClient();

            MovieGenresDirectorsRaitingsFormats pdts = GetDegreeTypes(client);

            HttpResponseMessage response = client.GetAsync("Movie/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Movie movie = JsonConvert.DeserializeObject<Movie>(result);

            return View("Edit", pdts);

        }

        private static MovieGenresDirectorsRaitingsFormats GetDegreeTypes(HttpClient client)
        {
            MovieGenresDirectorsRaitingsFormats pdts = new MovieGenresDirectorsRaitingsFormats();
            pdts.Genres = new List<Genre>();
            HttpResponseMessage response = client.GetAsync("Genres").Result;
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            pdts.Genres = items.ToObject<List<Genre>>();
            return pdts;
        }

        [HttpPost]
        public ActionResult Update(MovieGenresDirectorsRaitingsFormats pdts, int id)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Movie/" + id, pdts.Movie).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Edit", pdts);
            }

        }

        public ActionResult Remove(int id)
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Movie/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Movie movie = JsonConvert.DeserializeObject<Movie>(result);
            return View("Delete", movie);
        }

        [HttpPost]
        public ActionResult Remove(int id, Movie movie)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.DeleteAsync("Movie/" + id).Result;
                return RedirectToAction("Get");


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Delete", movie);
            }
        }
        #endregion
    }
}
