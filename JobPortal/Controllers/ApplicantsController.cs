using JobPortal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace JobPortal.Controllers
{
    public class ApplicantsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // Get applicants for specific jobs
        public ActionResult Index(int jobid)
        {

            var id = User.Identity.GetUserId();
            var jobs = db.Applied.Include(c => c.Jobs).Where(c=>c.JobId == jobid).ToList();
            return View(jobs);
        }
        //Reject applicant
        public ActionResult Reject(int id)
        {

            var jobs = db.Applied.Where(c => c.Id == id).SingleOrDefault();
            jobs.Status = "Rejected";
            db.SaveChanges();
            return RedirectToAction("Index",new { jobid = jobs.JobId});
        }
        //Accept applicant
        public ActionResult Accept(int id)
        {

            var jobs = db.Applied.Where(c => c.Id == id).SingleOrDefault();

            jobs.Status = "Accepted";
            db.SaveChanges();
            return RedirectToAction("Index", new { jobid = jobs.JobId });
        }

    }
}