using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;
using System.Diagnostics;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        // GET: Movie
        public ActionResult Index1()
        {
            MovieDBHandler dbhandle = new MovieDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetMovie());
        }

        public ActionResult JM1()
        {
            MovieDBHandler dbhandle = new MovieDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetActorsStateCount());
        }

        public ActionResult JM2All()
        {
            MovieDBHandler sdb = new MovieDBHandler();
            return View(sdb.GetActorMoviesAll());
        }


        public ActionResult JM2(int id)
        {
            MovieDBHandler sdb = new MovieDBHandler();
            return View(sdb.GetActorMovies(id));
        }
        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MovieDBHandler sdb = new MovieDBHandler();
                    if (sdb.AddMovie(smodel))
                    {
                        ViewBag.Message = "Movie Details Added Successfully";
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
        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MovieDBHandler sdb = new MovieDBHandler();
            return View(sdb.GetMovie().Find(smodel => smodel.FilmID == id));
        }

        // POST: FilmProducer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie smodel)
        {
            try
            {
                MovieDBHandler sdb = new MovieDBHandler();
                sdb.UpdateDetails(smodel);
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
            try
            {
               MovieDBHandler sdb = new MovieDBHandler();
                if (sdb.DeleteMovie(id))
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
        // POST: Movie/Delete/5
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
