using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class ProducerController : Controller
    {
        // GET: Producer
        public ActionResult Index()
        {
            ProducerDBHandler dbhandle = new ProducerDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetProducer());
        }

        // GET: Producer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producer/Create
        [HttpPost]
        public ActionResult Create(Producer smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProducerDBHandler sdb = new ProducerDBHandler();
                    if (sdb.AddProducer(smodel))
                    {
                        ViewBag.Message = "Producer Details Added Successfully";
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

        // GET: Producer/Edit/5
        public ActionResult Edit(int id)
        {
            ProducerDBHandler sdb = new ProducerDBHandler();
            return View(sdb.GetProducer().Find(smodel => smodel.ProducerID == id));
        }

        // POST: Producer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Producer smodel)
        {
            try
            {
                ProducerDBHandler sdb = new ProducerDBHandler();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producer/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ProducerDBHandler sdb = new ProducerDBHandler();
                if (sdb.DeleteProducer(id))
                {
                    ViewBag.AlertMsg = "Producer Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Producer/Delete/5
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
