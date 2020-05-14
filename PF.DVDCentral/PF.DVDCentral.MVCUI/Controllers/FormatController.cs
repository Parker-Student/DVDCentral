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
    public class FormatController : Controller
    {
        #region "Pre-WebAPI"
        List<Format> formats;
        // GET: Format
        public ActionResult Index()
        {
            ViewBag.Title = "Degree Types";
            formats = FormatManager.Load();
            return View(formats);
        }

        // GET: Format/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";

            Format format = new Format();
            format = FormatManager.LoadById(id);
            return View(format);
        }

        // GET: Format/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            Format format = new Format();
            return View(format);
        }

        // POST: Format/Create
        [HttpPost]
        public ActionResult Create(Format format)
        {
            try
            {
                // TODO: Add insert logic here
                FormatManager.Insert(format);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Format/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";

            Format format = new Format();
            format = FormatManager.LoadById(id);
            return View(format);

        }

        // POST: Format/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Format format)
        {
            try
            {
                // TODO: Add update logic here
                FormatManager.Update(format);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Format/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";

            Format format = new Format();
            format = FormatManager.LoadById(id);
            return View(format);

        }

        // POST: Format/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Format format)
        {
            try
            {
                FormatManager.Delete(id);

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
