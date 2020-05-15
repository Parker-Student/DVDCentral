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
            if(Authenticate.IsAuthenticated())
            {
                movies = MovieManager.Load();
                ViewBag.Source = "Index";

                return View(movies);

            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });

            }
        }
        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            var programs = MovieManager.Load();
            return PartialView(programs);
        }
        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie Movie = MovieManager.LoadById(id);
            return View(Movie);
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
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });

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
                pdts.Movie = MovieManager.LoadById(id);
                pdts.Genres = GenreManager.Load();
                pdts.Directors = DirectorManager.Load();
                pdts.Ratings = RatingManager.Load();
                pdts.Formats = FormatManager.Load();

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
    }
}
