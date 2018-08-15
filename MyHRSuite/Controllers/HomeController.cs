using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;


namespace MyHRSuite.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var data = Common.DataIntegrity.GetIntegrity();
            ViewBag.hrCore = data;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*protected JsonResult IntegrityCheck()
        {
            string details = null;

            try
            {
                

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "A problem occurred while trying to filter data. Please contact administrator");
            }

            return Json(details, JsonRequestBehavior.AllowGet);
        } */
    }
}