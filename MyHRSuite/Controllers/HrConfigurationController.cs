using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHRSuite.Objects;


namespace MyHRSuite.Controllers
{
    public class HrConfigurationController : Controller
    {
        // GET: HrConfiguration
        public ActionResult Index()
        {
            var overall = Common.DataIntegrity.GetHR();
            ViewBag.overall = overall;
            return View();
        }

        // GET: HrConfiguration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HrConfiguration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HrConfiguration/Create
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

        // GET: HrConfiguration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HrConfiguration/Edit/5
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

        // GET: HrConfiguration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HrConfiguration/Delete/5
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
        public static Overall GetHR()
        {
            String connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            HRCore hRCore = new HRCore();
            Overall overall = new Overall();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("select (select count(*) from [196.3.190.28].[gippreprod2016].[dbo].gippromo a" +
                "where a.codfunci not in (select codfunci from[196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'funcisit'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].giprotac a" +
                "where a.codfunci not in (select codfunci from[196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'post'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipcashb a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'benefits'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipfalta a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'leave'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipemvac a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'entitlements'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipmedex a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'medicalinfo'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipmedif a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'medicaladd'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipbenef a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'beneficiaries'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipmedal a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'awards'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipdisci a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'disciplinary'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipemmem a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'unions'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipanexo a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'attachments'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipaentr a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'allowances'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipdscnt a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'deduction'," +
                "(select count(*) from[196.3.190.28].[gippreprod2016].[dbo].gipempbk a" +
                "where a.codfunci not in (select codfunci from [196.3.190.28].[gippreprod2016].[dbo].gipfunci b where codfunci is not null)) as 'banks';", con);
            try
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        overall.FuncSit = int.Parse(reader["funcisit"].ToString());
                        overall.Posts = int.Parse(reader["post"].ToString());
                        overall.Benefits = int.Parse(reader["benefits"].ToString());
                        overall.Leave = int.Parse(reader["leave"].ToString());
                        overall.Entitlements = int.Parse(reader["entitlements"].ToString());
                        overall.MedicalInfo = int.Parse(reader["medicalinfo"].ToString());
                        overall.MedicalAdd = int.Parse(reader["medicaladd"].ToString());
                        overall.Beneficiaries = int.Parse(reader["beneficiaries"].ToString());

                        overall.Awards = int.Parse(reader["awards"].ToString());
                        overall.DisciplinaryAction = int.Parse(reader["disciplinary"].ToString());
                        overall.Unions = int.Parse(reader["unions"].ToString());
                        overall.Attachments = int.Parse(reader["attachments"].ToString());
                        overall.Allowances = int.Parse(reader["allowances"].ToString());
                        overall.Deductions = int.Parse(reader["deduction"].ToString());
                        overall.BankAccounts = int.Parse(reader["banks"].ToString());

                        overall.HRCore = Common.DataIntegrity.GetIntegrity();

                    }
                }

                con.Close();
                return overall;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return overall;
        }
    }
}
