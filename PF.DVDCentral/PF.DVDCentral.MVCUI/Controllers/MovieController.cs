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
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
