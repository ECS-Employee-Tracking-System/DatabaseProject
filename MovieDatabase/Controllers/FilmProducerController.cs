using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;


namespace MovieDatabase.Controllers
{
    public class FilmProducerController : Controller
    {
        // GET: FilmProducer
        public ActionResult Index()
        {
            FilmProducerDBHandler dbhandle = new FilmProducerDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetFilmProducer());
        }

        // GET: FilmProducer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmProducer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmProducer/Create
        [HttpPost]
        public ActionResult Create(FilmProducer smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FilmProducerDBHandler sdb = new FilmProducerDBHandler();
                    if (sdb.AddFilmProducer(smodel))
                    {
                        ViewBag.Message = "FilmProducer Details Added Successfully";
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

        // GET: FilmProducer/Edit/5
        public ActionResult Edit(int id)
        {
            FilmProducerDBHandler sdb = new FilmProducerDBHandler();
            return View(sdb.GetFilmProducer().Find(smodel => smodel.FilmID == id));
        }

        // POST: FilmProducer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FilmProducer smodel)
        {
            try
            {
                FilmProducerDBHandler sdb = new FilmProducerDBHandler();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmProducer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmProducer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                FilmProducerDBHandler sdb = new FilmProducerDBHandler();
                if (sdb.DeleteFilmProducer(id))
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
    }
}
