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
    public class DirectorController : Controller
    {
        #region "Pre-WebAPI"
        List<Director> directors;
        // GET: Director
        public ActionResult Index()
        {
            ViewBag.Title = "Degree Types";
            directors = DirectorManager.Load();
            return View(directors);
        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";

            Director director = new Director();
            director = DirectorManager.LoadById(id);
            return View(director);
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            Director director = new Director();
            return View(director);
        }

        // POST: Director/Create
        [HttpPost]
        public ActionResult Create(Director director)
        {
            try
            {
                // TODO: Add insert logic here
                DirectorManager.Insert(director);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";

            Director director = new Director();
            director = DirectorManager.LoadById(id);
            return View(director);

        }

        // POST: Director/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Director director)
        {
            try
            {
                // TODO: Add update logic here
                DirectorManager.Update(director);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";

            Director director = new Director();
            director = DirectorManager.LoadById(id);
            return View(director);

        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Director director)
        {
            try
            {
                DirectorManager.Delete(id);

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
