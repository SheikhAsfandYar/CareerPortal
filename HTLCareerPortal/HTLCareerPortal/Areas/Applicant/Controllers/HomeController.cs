using HTLCareerPortal.Areas.Applicant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTLCareerPortal.Areas.Applicant.Controllers
{
    [HandleError()]
    public class HomeController : Controller
    {
        // GET: Applicant/Home
        Profile data = new Profile();
        public ActionResult Index()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return RedirectToAction("JobList", "Job");
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
         } 
        public ActionResult AppliedJobs() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int id = Convert.ToInt32(Session["App_Id"]);
                return View(data.appliedjobs(id));
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult RemoveAppliedJob(int id)
        {
            HTLCareerEntities db = new HTLCareerEntities();
            var obj = db.jobApplyings.SingleOrDefault(x => x.pk == id);
            db.jobApplyings.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("AppliedJobs");
            
        }
        public ActionResult UpdateProfile()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult AccountSetting()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return RedirectToAction("AccountDetail", "Account");
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
            
        }
        public ActionResult CompleteProfile()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return RedirectToAction("ProfileView", "Profile");
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
    }
}