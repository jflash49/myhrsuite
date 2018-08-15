using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHRSuite.Controllers
{
    public class HrSupportController : Controller
    {
        // GET: HrSupport
        public ActionResult Index()
        {
            var data = Common.DataIntegrity.GetUserInfo();
            ViewBag.hrSupport = data;
            ViewBag.Total = data.Count();
            return View();
        }

        // GET: HrSupport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HrSupport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HrSupport/Create
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

        // GET: HrSupport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HrSupport/Edit/5
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

        // GET: HrSupport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HrSupport/Delete/5
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
