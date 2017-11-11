using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public ActionResult Index()
        {
            FilmDBHandler dbhandle = new FilmDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetFilm());
        }

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(Film smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FilmDBHandler sdb = new FilmDBHandler();
                    if (sdb.AddFilm(smodel))
                    {
                        ViewBag.Message = "Film Details Added Successfully";
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

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            FilmDBHandler sdb = new FilmDBHandler();
            return View(sdb.GetFilm().Find(smodel => smodel.FilmID == id));
        }

        // POST: Film/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Film smodel)
        {
            try
            {
                FilmDBHandler sdb = new FilmDBHandler();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                FilmDBHandler sdb = new FilmDBHandler();
                if (sdb.DeleteRating(id))
                {
                    ViewBag.AlertMsg = "Film Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Film/Delete/5
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


