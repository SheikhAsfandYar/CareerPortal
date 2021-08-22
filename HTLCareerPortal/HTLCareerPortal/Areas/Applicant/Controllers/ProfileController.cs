using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using HTLCareerPortal.Areas.Applicant.Models;

namespace HTLCareerPortal.Areas.Applicant.Controllers
{
    [HandleError()]
    public class ProfileController : Controller
    {
        HTLCareerEntities db = new HTLCareerEntities();
        Profile Data = new Profile();
        // GET: Applicant/Profile
        public ActionResult ProfileView()
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
        public JsonResult SignUp() {
            int id = Convert.ToInt32(Session["App_Id"]);
           
            return Json(Data.GeneralInfo(id), JsonRequestBehavior.AllowGet);
        }
    
        public JsonResult PersonalInfo()
        {
            int id = Convert.ToInt32(Session["App_Id"]);

            return Json(Data.CompleteInfo(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Education()
        {
            int id = Convert.ToInt32(Session["App_Id"]);

            return Json(Data.Education(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Experience()
        {
            int id = Convert.ToInt32(Session["App_Id"]);

            return Json(Data.Experience(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult JobSalary()
        {
            int id = Convert.ToInt32(Session["App_Id"]);

            return Json(Data.JobSalary(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProfessionalReference()
        {

            int id = Convert.ToInt32(Session["App_Id"]);

            return Json(Data.ProfessionalReferenceData(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Image()
        {
            int id = Convert.ToInt32(Session["App_Id"]);

            return Json(Data.Image(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CareerObjective()
        {
            int id = Convert.ToInt32(Session["App_Id"]);

            return Json(Data.CareerObj(id), JsonRequestBehavior.AllowGet);
        }
    }
}