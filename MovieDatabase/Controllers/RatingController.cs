using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            RatingDBHandler dbhandle = new RatingDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetRating());
        }

        // GET: Rating/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(Rating smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RatingDBHandler sdb = new RatingDBHandler();
                    if (sdb.AddRating(smodel))
                    {
                        ViewBag.Message = "Rating Details Added Successfully";
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

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            RatingDBHandler sdb = new RatingDBHandler();
            return View(sdb.GetRating().Find(smodel => smodel.RatingID == id));
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Rating smodel)
        {
            try
            {
                RatingDBHandler sdb = new RatingDBHandler();
                sdb.UpdateDetails(smodel);
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
            try
            {
                RatingDBHandler sdb = new RatingDBHandler();
                if (sdb.DeleteRating(id))
                {
                    ViewBag.AlertMsg = "Rating Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Rating/Delete/5
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

