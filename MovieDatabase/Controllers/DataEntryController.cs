using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDatabase.Controllers
{
    public class DataEntryController : Controller
    {
        // GET: DataEntry
        public ActionResult Index()
        {
            return View();
        }

        // GET: DataEntry/Details/5
        public ActionResult movie(int id)
        {
            return View();
        }

        // GET: DataEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataEntry/Create
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

        // GET: DataEntry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataEntry/Edit/5
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

        // GET: DataEntry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataEntry/Delete/5
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
