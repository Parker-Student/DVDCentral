using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.BL;
//using PF.DVDCentral.MVCUI.ViewModels;
using System.IO;
//using PF.DVDCentral.MVCUI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BDF.ProgramDec.MVCUI.Controllers
{
    public class RatingController : Controller
    {
        #region "Pre-WebAPI"
        List<Rating> ratings;
        // GET: Rating
        public ActionResult Index()
        {
            ViewBag.Title = "Degree Types";
            ratings = RatingManager.Load();
            return View(ratings);
        }

        // GET: Rating/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";

            Rating rating = new Rating();
            rating = RatingManager.LoadById(id);
            return View(rating);
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            Rating rating = new Rating();
            return View(rating);
        }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(Rating rating)
        {
            try
            {
                // TODO: Add insert logic here
                RatingManager.Insert(rating);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";

            Rating rating = new Rating();
            rating = RatingManager.LoadById(id);
            return View(rating);

        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Rating rating)
        {
            try
            {
                // TODO: Add update logic here
                RatingManager.Update(rating);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";

            Rating rating = new Rating();
            rating = RatingManager.LoadById(id);
            return View(rating);

        }

        // POST: Rating/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Rating rating)
        {
            try
            {
                RatingManager.Delete(id);

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
