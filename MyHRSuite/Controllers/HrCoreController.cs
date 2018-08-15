using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHRSuite.Controllers
{
    public class HrCoreController : Controller
    {
        // GET: HrCore
        public ActionResult Index()
        {
            var data = Common.DataIntegrity.GetIntegrity();
            ViewBag.hrCore = data;
            return View();
        }

        // GET: HrCore
        public ActionResult People()
        {
            var data = Common.DataIntegrity.GetPeople();
            ViewBag.people = data;
            return View();
        }

        // GET: HrCore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HrCore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HrCore/Create
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

        // GET: HrCore/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HrCore/Edit/5
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

        // GET: HrCore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HrCore/Delete/5
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
