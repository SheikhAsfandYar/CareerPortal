using HTLCareerPortal.Areas.Applicant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTLCareerPortal.Areas.Applicant.Controllers
{
    [HandleError()]
    public class JobController : Controller
    {
        Profile Data = new Profile();
        HTLCareerEntities db = new HTLCareerEntities();
        // GET: Applicant/Job
        public ActionResult Joblist()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return View(Data.Jobs());
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult Joblist(string jobsearch)
        {

            return View(Data.JobSearch(jobsearch));
        }
        public ActionResult JobDetail(int id, string error)
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {

                if (error == "yes")
            {
                ModelState.AddModelError("", "You Already had been applied for this job. !");
            }
            if (error == "profile")
            {
                ViewBag.ERROR = "error";
                ModelState.AddModelError("", "Please go to Update Profile Page and atleast Upload Your CV, Update Personel Detail, Education Detail, Job Salary Preference and General Information To Apply for this job.!");
            }
            if (error == "sucess")
            {
                ModelState.AddModelError("", "Sucessfuly Applied !");

            }
           
                return View(Data.JobDetail(id));

            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult ApplyJob(int Jobid) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                HTLCareerEntities db = new HTLCareerEntities();
                int appId = Convert.ToInt32(Session["App_Id"]);
                var checkResume = db.tbl_Resumes.Where(x => x.AppId == appId).SingleOrDefault();
                var CheckPersonelDet = db.tbl_PersonalInfo.Where(x => x.App_Id == appId).SingleOrDefault();
                var checkEducation = db.tbl_Education.Where(x => x.App_Id == appId);
                var checkJsp = db.tbl_JobSalaryPreference.Where(x => x.App_Id == appId).SingleOrDefault();
                var checkGI = db.tbl_GeneralInfo.Where(x => x.App_Id == appId).SingleOrDefault();

                if (checkResume != null && CheckPersonelDet !=null && checkEducation != null && checkJsp != null && checkGI != null)
                {

                    jobApplying obj = new jobApplying();
                    var data = db.jobApplyings.Where(x => x.JobId.Equals(Jobid) && x.App_Id.Equals(appId)).FirstOrDefault();
                    if (data == null)
                    {
                        obj.App_Id = appId;
                        obj.JobId = Jobid;
                        obj.ApplyDate = DateTime.Now;
                        db.jobApplyings.Add(obj);
                        db.SaveChanges();
                        return RedirectToAction("JobDetail", new { id = Jobid, error = "sucess" });
                    }
                    else
                    {

                        return RedirectToAction("JobDetail", new { id = Jobid, error = "yes" });
                    }
                }
                else {
                    return RedirectToAction("JobDetail", new { id = Jobid, error = "profile" });
                }

            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
       } 
      
        }
}