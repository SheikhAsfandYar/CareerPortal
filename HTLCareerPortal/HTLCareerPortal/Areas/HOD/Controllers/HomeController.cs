using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace HTLCareerPortal.Areas.HOD.Controllers
{
    public class HomeController : Controller
    {
        HTLCareerEntities db = new HTLCareerEntities();
        // GET: HOD/Home
        public ActionResult Index(string check = "")
        {
            if (Session["App_Id"] != null  && Session["UserType"].ToString() =="Hod")
            {

                int id = Convert.ToInt32(Session["App_Id"]);
                var data = db.tbl_SignUp.Where(x => x.ApplicantId == id).SingleOrDefault();
                if (check == "True")
                {
                    ViewBag.check = check;
                    ModelState.AddModelError("", "Applicant has been sent to Admin & Shortlisted");
                }
                if (check == "False")
                {
                    ModelState.AddModelError("", "Applicant has been sent to Admin & REJECTED");
                }
                return View(db.tbl_AdminToHod.Where(x => x.DepId == data.Dep_Id).ToList());
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }

        public ActionResult Jobs() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Hod")
            {
                int id = Convert.ToInt32(Session["App_Id"]);
                var data = db.tbl_SignUp.Where(x => x.ApplicantId == id).SingleOrDefault();

                return View(db.JobSetups.Where(x => x.Department == data.Dep_Id).ToList());
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult AddJob() {
           if (Session["App_Id"] != null && Session["UserType"].ToString() == "Hod")
            {
            JobSetup pro = new JobSetup();
            ViewBag.city = new SelectList(db.citySetups, "cityCode", "cityName", pro.JobLocation);
            return View();
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult AddJob(JobSetup data)
        {
            int id = Convert.ToInt32(Session["App_Id"]);
            var info = db.tbl_SignUp.Where(x => x.ApplicantId == id ).SingleOrDefault();
            JobSetup pro = new JobSetup();
            ViewBag.city = new SelectList(db.citySetups, "cityCode", "cityName", pro.JobLocation);
            ViewBag.dep = new SelectList(db.tbl_Department, "DepId", "DepName", pro.Department);
            if (data.JobTitle == null || data.JobTitle == "")
            {
                ModelState.AddModelError("", "Please Enter Job Title ");
                return View();
            }
            else if (data.TotalPosition == null || Convert.ToInt32(data.TotalPosition) == 0)
            {
                ModelState.AddModelError("", "Please Enter Total Number Of Positions ");
                return View();
            }
            else if (data.JobType == null || data.JobType == "")
            {
                ModelState.AddModelError("", "Please Select Job Type. ");
                return View();
            }
            else if (data.Education == null || data.Education == "")
            {
                ModelState.AddModelError("", "Please Enter Education Detail. ");
                return View();
            }
            //else if (data.Department == null)
            //{
            //    ModelState.AddModelError("", "Please Select Department. ");
            //    return View();
            //}
            else if (data.JobRequirements == null || data.JobRequirements == "")
            {
                ModelState.AddModelError("", "Please Enter Job Requirements Detail. ");
                return View();
            }
            else if (data.SkillsRequired == null || data.SkillsRequired == "")
            {
                ModelState.AddModelError("", "Please Enter Required Skills Detail. ");
                return View();
            }
            else if (data.JobOpeningDate == null)
            {
                ModelState.AddModelError("", "Please Select Job Opening Date. ");
                return View();
            }
            else if (data.JobClosingDate == null)
            {
                ModelState.AddModelError("", "Please Select Job Closing Date. ");
                return View();
            }
            else if (data.JobStatus == null)
            {
                ModelState.AddModelError("", "Please Select Job Status. ");
                return View();
            }
            else if (data.JobLocation == null)
            {
                ModelState.AddModelError("", "Please Select Job Location. ");
                return View();
            }
            else if (data.ScopeOfResponsibility == null)
            {
                ModelState.AddModelError("", "Please Enter Scope Of Responsibility Detail. ");
                return View();
            }
            else if (data.Experience == null)
            {
                ModelState.AddModelError("", "Please Enter Experience Detail. ");
                return View();
            }
            else if (data.CompensationBenefits == null)
            {
                ModelState.AddModelError("", "Please Enter Compensation Benefits Detail. ");
                return View();
            }

            else
            {
                data.Department = info.Dep_Id;
                db.JobSetups.Add(data);
                db.SaveChanges();
                return RedirectToAction("jobs");
            }
        }
        public ActionResult UpdateJob(int id)
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Hod")
            {
                int appid = Convert.ToInt32(Session["App_Id"]);
                var data = db.tbl_SignUp.Where(x => x.ApplicantId == appid).SingleOrDefault();
                var emp = db.JobSetups.Include(e => e.citySetup).SingleOrDefault(e => e.pk == id && e.Department == data.Dep_Id);
                if (emp == null)
                {
                    return HttpNotFound();
                }
                ViewBag.city = new SelectList(db.citySetups, "cityCode", "cityName", emp.JobLocation);
                return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }

        }
        [HttpPost]
        public ActionResult UpdateJob(JobSetup data)
        {
            int id = Convert.ToInt32(Session["App_Id"]);
            var values = db.tbl_SignUp.Where(x => x.ApplicantId == id).SingleOrDefault();
            JobSetup pro = new JobSetup();
            ViewBag.city = new SelectList(db.citySetups, "cityCode", "cityName", pro.JobLocation);
            ViewBag.dep = new SelectList(db.tbl_Department, "DepId", "DepName", pro.Department);
            if (data.JobTitle == null || data.JobTitle == "")
            {
                ModelState.AddModelError("", "Please Enter Job Title ");
                return View(data);
            }
            else if (data.TotalPosition == null || Convert.ToInt32(data.TotalPosition) == 0)
            {
                ModelState.AddModelError("", "Please Enter Total Number Of Positions ");
                return View(data);
            }
            else if (data.JobType == null || data.JobType == "")
            {
                ModelState.AddModelError("", "Please Select Job Type. ");
                return View(data);
            }
            else if (data.Education == null || data.Education == "")
            {
                ModelState.AddModelError("", "Please Enter Education Detail. ");
                return View(data);
            }
            //else if (dep == 0)
            //{
            //    ModelState.AddModelError("", "Please Select Department. ");

            //    return View(data);
            //}
            else if (data.JobRequirements == null || data.JobRequirements == "")
            {
                ModelState.AddModelError("", "Please Enter Job Requirements Detail. ");
                return View(data);
            }
            else if (data.SkillsRequired == null || data.SkillsRequired == "")
            {
                ModelState.AddModelError("", "Please Enter Required Skills Detail. ");
                return View(data);
            }
            else if (data.JobOpeningDate == null)
            {
                ModelState.AddModelError("", "Please Select Job Opening Date. ");
                return View(data);
            }
            else if (data.JobClosingDate == null)
            {
                ModelState.AddModelError("", "Please Select Job Closing Date. ");
                return View(data);
            }
            else if (data.JobStatus == null)
            {
                ModelState.AddModelError("", "Please Select Job Status. ");
                return View(data);
            }
            else if (data.JobLocation == null)
            {
                ModelState.AddModelError("", "Please Select Job Location. ");
                return View(data);
            }
            else if (data.ScopeOfResponsibility == null)
            {
                ModelState.AddModelError("", "Please Enter Scope Of Responsibility Detail. ");
                return View(data);
            }
            else if (data.Experience == null)
            {
                ModelState.AddModelError("", "Please Enter Experience Detail. ");
                return View(data);
            }
            else if (data.CompensationBenefits == null)
            {
                ModelState.AddModelError("", "Please Enter Compensation Benefits Detail. ");
                return View(data);
            }

            else
            {

                var info = db.JobSetups.Where(x => x.pk.Equals(data.pk)).SingleOrDefault();
                //data.JobLocation = city;
                info.JobTitle = data.JobTitle;
                info.TotalPosition = data.TotalPosition;
                info.JobType = data.JobType;
                info.Education = data.Education;
                info.Department = values.Dep_Id;
                info.JobRequirements = data.JobRequirements;
                info.SkillsRequired = data.SkillsRequired;
                info.JobOpeningDate = data.JobOpeningDate;
                info.JobClosingDate = data.JobClosingDate;
                info.JobStatus = data.JobStatus;
                info.JobLocation = data.JobLocation;
                info.ScopeOfResponsibility = data.ScopeOfResponsibility;
                info.Experience = data.Experience;
                info.CompensationBenefits = data.CompensationBenefits;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("jobs");
            }
        }
        public ActionResult DetailJob(int id) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Hod")
            {
                int appid = Convert.ToInt32(Session["App_Id"]);
                var data = db.tbl_SignUp.Where(x => x.ApplicantId == appid).SingleOrDefault();
                return View(db.JobSetups.Where(x => x.pk == id && x.Department== data.Dep_Id).SingleOrDefault());
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult RemoveJob(int id)
        {
            var data = db.JobSetups.SingleOrDefault(x => x.pk.Equals(id));
            db.JobSetups.Remove(data);
            db.SaveChanges();
            return RedirectToAction("jobs");
        }
        public ActionResult ReturnToAdmin(Boolean status , int id =0) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Hod")
            {
                var data = db.tbl_AdminToHod.Where(x => x.ATHid == id).SingleOrDefault();
                data.Status = status;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { check = status.ToString() });
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult SentToAdmin() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Hod")
            {
                int id = Convert.ToInt32(Session["App_Id"]);
                var data = db.tbl_SignUp.Where(x => x.ApplicantId == id).SingleOrDefault();

                return View(db.tbl_AdminToHod.Where(x => x.DepId == data.Dep_Id).ToList());
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
    }
}