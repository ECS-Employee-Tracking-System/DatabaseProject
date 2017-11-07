using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            GenreDBHandler dbhandle = new GenreDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetGenre());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        public ActionResult Create(Genre smodel)
        {
            try 
            {
                if (ModelState.IsValid)
                { 
                    GenreDBHandler sdb = new GenreDBHandler();
                    if (sdb.AddGenre(smodel))
                    {
                        ViewBag.Message = "Genre Details Added Successfully";
                     ModelState.Clear();
                    }
            }
            return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            GenreDBHandler sdb = new GenreDBHandler();
            return View(sdb.GetGenre().Find(smodel => smodel.GenreID == id));
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre smodel)
        {
            try
            {
                GenreDBHandler sdb = new GenreDBHandler();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                GenreDBHandler sdb = new GenreDBHandler();
                if (sdb.DeleteGenre(id))
                {
                    ViewBag.AlertMsg = "Genre Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Genre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
