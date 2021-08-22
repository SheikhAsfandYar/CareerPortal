using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace HTLCareerPortal.Areas.Applicant.Controllers
{
    //[HandleError()]
    public class UpdateProfileController : Controller
    {
        HTLCareerEntities db = new HTLCareerEntities();
        // GET: Applicant/UpdateProfile
        public ActionResult PersonalDetail()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int id = Convert.ToInt32(Session["App_Id"]);
                return View(db.tbl_PersonalInfo.Where(x => x.App_Id == id));
            }
            else {
                return RedirectToAction("login", "Home",new {area= ""});
            }

        }
        public ActionResult Create() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult Create(tbl_PersonalInfo info)
        {
            if (info.FirstName == null)
            {
                ModelState.AddModelError("", "Please Enter Your First Name.");
            }
            else if (info.MiddleName == null)
            {
                ModelState.AddModelError("", "Please Enter Your Middle Name.");
            }
            else if (info.LastName == null)
            {
                ModelState.AddModelError("", "Please Enter Your Last Name.");
            }
            else if (info.Company == null)
            {
                ModelState.AddModelError("", "Please Enter Your Company Name.");
            }
            else if (info.CurrentDesignation == null)
            {
                ModelState.AddModelError("", "Please Enter Your Current Designation.");
            }
            else if (info.CNIC == null)
            {
                ModelState.AddModelError("", "Please Enter Your CNIC No.");
            }
            else if (info.DOB == null)
            {
                ModelState.AddModelError("","Enter Date in Correct Format MM-DD-YYYY");
                return View(info);
            }
            else if (info.PostalCode == null)
            {
                ModelState.AddModelError("", "Please Enter Postal Code.");
            }
            else if (info.PlaceOfBirth == null)
            {
                ModelState.AddModelError("", "Please Enter Your Place of Birth.");
            }
            else if (info.MaritalStatus == null)
            {
                ModelState.AddModelError("", "Please Select Your Marital Status.");
            }
            else
            {
                info.App_Id = Convert.ToInt32(Session["App_Id"]);
                db.tbl_PersonalInfo.Add(info);
                db.SaveChanges();
                return RedirectToAction("PersonalDetail");
            }
            return View(info);
        }
        public ActionResult UpdatePersonalInfo(int? id) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int appid =Convert.ToInt32( Session["App_Id"]);
                var emp = db.tbl_PersonalInfo.SingleOrDefault(e => e.PI_Id == id && e.App_Id == appid);
                if (emp == null)
                {
                    return HttpNotFound();
                }
                return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult UpdatePersonalInfo(tbl_PersonalInfo info) {
            if (info.FirstName == null)
            {
                ModelState.AddModelError("", "Please Enter Your First Name.");
            }
            else if (info.LastName == null)
            {
                ModelState.AddModelError("", "Please Enter Your Last Name.");
            }
            else if (info.CurrentDesignation == null)
            {
                ModelState.AddModelError("", "Please Enter Your Current Designation.");
            }
            else
            {
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PersonalDetail");
            }
            return View(info);

        }

        //---------------------------------------------------EDUCATION DETAIL---------------------------------------------
        public ActionResult EducationDetail() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                //int PIID = Convert.ToInt32(Session["PI_Id"]);
                int AppId = Convert.ToInt32(Session["App_Id"]);
            return View(db.tbl_Education.Where(x => x.App_Id == AppId));
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult AddEducation() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return View();
        }
            else {
                return RedirectToAction("login", "Home",new {area= ""});
            }
        }
        [HttpPost]
        public ActionResult AddEducation(tbl_Education edu) {
            if (edu.Degree == null)
            {
                ModelState.AddModelError("", "Please Enter Your Degree Name.");
            }
            else if (edu.Institute == null)
            {
                ModelState.AddModelError("", "Please Enter Institute Name.");
            }
            else if (edu.CompletionYear == null)
            {
                ModelState.AddModelError("", "Please Enter Completion Year.");
            }
            else if (edu.Specialization == null)
            {
                ModelState.AddModelError("", "Please Enter Your Degree Specialization .");
            }
            else if (edu.CGPA == null)
            {
                ModelState.AddModelError("", "Please Enter Your CGPA OR Percentage % .");
            }
            else
            {
                edu.App_Id = Convert.ToInt32(Session["App_Id"]);
                db.tbl_Education.Add(edu);
                db.SaveChanges();
                return RedirectToAction("EducationDetail");
            }
            return View(edu);  
        }

        public ActionResult UpdateEducation(int? id) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int appid = Convert.ToInt32(Session["App_Id"]);
                var emp = db.tbl_Education.SingleOrDefault(e => e.Edu_Id == id && e.App_Id==appid);
                if (emp == null)
                {
                    return HttpNotFound();
                }
                return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult UpdateEducation(tbl_Education edu) {
            if (edu.Degree == null)
            {
                ModelState.AddModelError("", "Please Enter Your Degree Name.");
            }
            else if (edu.Institute == null)
            {
                ModelState.AddModelError("", "Please Enter Institute Name.");
            }
            else if (edu.CompletionYear == null)
            {
                ModelState.AddModelError("", "Please Enter Completion Year.");
            }
            else if (edu.Specialization == null)
            {
                ModelState.AddModelError("", "Please Enter Your Degree Specialization .");
            }
            else if (edu.CGPA == null)
            {
                ModelState.AddModelError("", "Please Enter Your CGPA OR Percentage % .");
            }
            else
            {
                db.Entry(edu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EducationDetail");
            }
            return View(edu);
        }

        public ActionResult RemoveEducation(int? id) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                var obj = db.tbl_Education.SingleOrDefault(x => x.Edu_Id == id);
                db.tbl_Education.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("EducationDetail");
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }

        //---------------------------------------------------Experience DETAIL---------------------------------------------

        public ActionResult ExperienceDetail() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int AppId = Convert.ToInt32(Session["App_Id"]);
            return View(db.tbl_Experience.Where(x => x.App_Id == AppId));
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult AddExperience() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                return View();
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult AddExperience(tbl_Experience exp) {
            if (exp.CompanyName == null)
            {
                ModelState.AddModelError("", "Please Enter Company Name !");
            }
            else if (exp.CompanyAddress == null)
            {
                ModelState.AddModelError("", "Please Enter Company Address !");
            }
            else if (exp.Industry == null)
            {
                ModelState.AddModelError("", "Please Enter Industry !");
            }
            else if (exp.PhoneNo == null)
            {
                ModelState.AddModelError("", "Please Enter Company Phone No. !");
            }
            else if (exp.JobSpecialization == null)
            {
                ModelState.AddModelError("", "Please Enter Job Specialization !");
            }
            else
            {
                exp.App_Id = Convert.ToInt32(Session["App_Id"]);
                exp.PI_Id = Convert.ToInt32(Session["PI_Id"]);
                db.tbl_Experience.Add(exp);
                db.SaveChanges();
                return RedirectToAction("ExperienceDetail");
            }
            return View(exp);
        }
        public ActionResult UpdateExperience(int? id)
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int appid = Convert.ToInt32(Session["App_Id"]);
                var emp = db.tbl_Experience.SingleOrDefault(e => e.Exp_Id == id && e.App_Id==appid);
                 if (emp == null)
                  {
                return HttpNotFound();
                     }
                  return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult UpdateExperience(tbl_Experience exp)
        {
            if (exp.CompanyName == null)
            {
                ModelState.AddModelError("", "Please Enter Company Name !");
            }
            else if (exp.CompanyAddress == null)
            {
                ModelState.AddModelError("", "Please Enter Company Address !");
            }
            else if (exp.Industry == null)
            {
                ModelState.AddModelError("", "Please Enter Industry !");
            }
            else if (exp.PhoneNo == null)
            {
                ModelState.AddModelError("", "Please Enter Company Phone No. !");
            }
            else if (exp.JobSpecialization == null)
            {
                ModelState.AddModelError("", "Please Enter Job Specialization !");
            }
            else
            {
                db.Entry(exp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ExperienceDetail");
            }
            return View(exp);
        }
        public ActionResult RemoveExperience(int? id)
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                var obj = db.tbl_Experience.SingleOrDefault(x => x.Exp_Id == id);
            db.tbl_Experience.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ExperienceDetail");
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }

        //---------------------------------------------------JOB Salary DETAIL---------------------------------------------
        public ActionResult JobSalaryPreference() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int AppId = Convert.ToInt32(Session["App_Id"]);
            var Data = db.tbl_JobSalaryPreference.Include(u => u.tbl_FOI);
            return View(db.tbl_JobSalaryPreference.Where(x => x.App_Id == AppId));
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult UpdateJsp() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                tbl_JobSalaryPreference pro = new tbl_JobSalaryPreference();
            ViewBag.categories = new SelectList(db.tbl_FOI.ToList(), "FOI_Id", "FOI_Name", pro.FOI1);
            ViewBag.categories2 = new SelectList(db.tbl_FOI.ToList(), "FOI_Id", "FOI_Name", pro.FOI2);
            ViewBag.categories3 = new SelectList(db.tbl_FOI.ToList(), "FOI_Id", "FOI_Name", pro.FOI3);
            return View();
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult UpdateJsp(tbl_JobSalaryPreference info) {
            if (info.FOI1 == null)
            {
                ModelState.AddModelError("", "Please Select Field Of Interest (One) .");
            }
            else if (info.FOI2 == null) {
                ModelState.AddModelError("", "Please Select Field Of Interest (Two)");
            }
            else if (info.FOI3 == null)
            {
                ModelState.AddModelError("", "Please Select Field Of Interest (Three)");
            }
            else if (info.PWT1 == null)
            {
                ModelState.AddModelError("", "Please Enter Your Prefered Work Type Ist");
            }
            else if (info.PWT2 == null)
            {
                ModelState.AddModelError("", "Please Enter Your Prefered Work Type 2nd");
            }
            else if (info.PWT3 == null)
            {
                ModelState.AddModelError("", "Please Enter Your Prefered Work Type 3rd");
            }
            else if (info.CurrentSalary == null)
            {
                ModelState.AddModelError("", "Please Enter Your Current Salary");
            }
            else if (info.Benifits == null)
            {
                ModelState.AddModelError("", "Please Enter Benifits");
            }
            else if (info.ExpectedGrossSalary == null)
            {
                ModelState.AddModelError("", "Please Enter Your Expected Gross Salary");
            }
            else
            {
                info.App_Id = Convert.ToInt32(Session["App_Id"]);
                db.tbl_JobSalaryPreference.Add(info);
                db.SaveChanges();
                return RedirectToAction("JobSalaryPreference");
            }
            return View(info);
        }
        public ActionResult EditJsp(int? id) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int appid = Convert.ToInt32(Session["App_Id"]);
                var emp = db.tbl_JobSalaryPreference.Include(e => e.tbl_FOI).SingleOrDefault(e => e.JSP_ID == id && e.App_Id==appid);
            if (emp == null)
            {
                return HttpNotFound();
            }
            tbl_JobSalaryPreference pro = new tbl_JobSalaryPreference();
            ViewBag.CategoryId = new SelectList(db.tbl_FOI, "FOI_Id", "FOI_Name", emp.FOI1);
            ViewBag.CategoryId2 = new SelectList(db.tbl_FOI, "FOI_Id", "FOI_Name", emp.FOI2);
            ViewBag.CategoryId3 = new SelectList(db.tbl_FOI, "FOI_Id", "FOI_Name", emp.FOI3);
            return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult EditJsp(tbl_JobSalaryPreference info , int CategoryId, int CategoryId2, int CategoryId3) {
            if (CategoryId == null)
            {
                ModelState.AddModelError("", "Please Select Field Of Interest (One) .");
            }
            else if (CategoryId2 == null)
            {
                ModelState.AddModelError("", "Please Select Field Of Interest (Two)");
            }
            else if (CategoryId3 == null)
            {
                ModelState.AddModelError("", "Please Select Field Of Interest (Three)");
            }
            else if (info.PWT1 == null)
            {
                ModelState.AddModelError("", "Please Enter Your Prefered Work Type Ist");
            }
            else if (info.PWT2 == null)
            {
                ModelState.AddModelError("", "Please Enter Your Prefered Work Type 2nd");
            }
            else if (info.PWT3 == null)
            {
                ModelState.AddModelError("", "Please Enter Your Prefered Work Type 3rd");
            }
            else if (info.CurrentSalary == null)
            {
                ModelState.AddModelError("", "Please Enter Your Current Salary");
            }
            else if (info.Benifits == null)
            {
                ModelState.AddModelError("", "Please Enter Benifits");
            }
            else if (info.ExpectedGrossSalary == null)
            {
                ModelState.AddModelError("", "Please Enter Your Expected Gross Salary");
            }
            else
            {
                var data = db.tbl_JobSalaryPreference.Where(x => x.JSP_ID.Equals(info.JSP_ID)).SingleOrDefault(); ;
                data.PWT1 = info.PWT1;
                data.PWT2 = info.PWT2;
                data.PWT3 = info.PWT3;
                data.FOI1 = CategoryId;
                data.FOI2 = CategoryId2;
                data.FOI3 = CategoryId3;
                data.CurrentSalary = info.CurrentSalary;
                data.Benifits = info.Benifits;
                data.ExpectedGrossSalary = info.ExpectedGrossSalary;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("JobSalaryPreference");
            
            }
            ViewBag.CategoryId = new SelectList(db.tbl_FOI, "FOI_Id", "FOI_Name", CategoryId);
            ViewBag.CategoryId2 = new SelectList(db.tbl_FOI, "FOI_Id", "FOI_Name", CategoryId2);
            ViewBag.CategoryId3 = new SelectList(db.tbl_FOI, "FOI_Id", "FOI_Name", CategoryId2);
            return View(info);
        }
        public ActionResult RemoveJsp(int? id)
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                var obj = db.tbl_JobSalaryPreference.SingleOrDefault(x => x.JSP_ID == id);
            db.tbl_JobSalaryPreference.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("JobSalaryPreference");
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        //---------------------------------------------------Professional References---------------------------------------------
        public ActionResult ProfessionalReference()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int AppId = Convert.ToInt32(Session["App_Id"]);
            return View(db.tbl_ProfessionalReference.Where(x => x.App_Id == AppId));
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult AddPR()
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
        [HttpPost]
        public ActionResult AddPR(tbl_ProfessionalReference pr)
        {
            if (pr.Name == null)
            {
                ModelState.AddModelError("", "Please Enter  Name !");
            }
            else if (pr.Relationship == null)
            {
                ModelState.AddModelError("", "Please Enter Relation !");
            }
            else if (pr.Designation == null)
            {
                ModelState.AddModelError("", "Please Enter Designation !");
            }
            else if (pr.Organization == null)
            {
                ModelState.AddModelError("", "Please Enter Organization Name !");
            }
            else if (pr.ContactNo == null)
            {
                ModelState.AddModelError("", "Please Enter Contact No !");
            }
            else
            {
                pr.App_Id = Convert.ToInt32(Session["App_Id"]);
                db.tbl_ProfessionalReference.Add(pr);
                db.SaveChanges();
                return RedirectToAction("ProfessionalReference");
            }
            return View(pr);
        }
        public ActionResult UpdatePR(int? id)
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int appid = Convert.ToInt32(Session["App_Id"]);
                var emp = db.tbl_ProfessionalReference.SingleOrDefault(e => e.PR_Id == id && e.App_Id== appid);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult UpdatePR(tbl_ProfessionalReference pr)
        {
            if (pr.Name == null)
            {
                ModelState.AddModelError("", "Please Enter  Name !");
            }
            else if (pr.Relationship == null)
            {
                ModelState.AddModelError("", "Please Enter Relation !");
            }
            else if (pr.Designation == null)
            {
                ModelState.AddModelError("", "Please Enter Designation !");
            }
            else if (pr.Organization == null)
            {
                ModelState.AddModelError("", "Please Enter Organization Name !");
            }
            else if (pr.ContactNo == null)
            {
                ModelState.AddModelError("", "Please Enter Contact No !");
            }
            else
            {
                db.Entry(pr).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProfessionalReference");
            }
            return View(pr);
        }
        public ActionResult RemovePR(int? id)
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                var obj = db.tbl_ProfessionalReference.SingleOrDefault(x => x.PR_Id == id);
            db.tbl_ProfessionalReference.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ProfessionalReference");
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }

        //---------------------------------------------------General Information---------------------------------------------
        public ActionResult GeneralInfo() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int AppId = Convert.ToInt32(Session["App_Id"]);
            var emp = db.tbl_GeneralInfo.SingleOrDefault(e => e.App_Id == AppId);
            if (emp == null)
            {
                return View();
            }
            return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult GeneralInfo(tbl_GeneralInfo info )
        {


                if (info.Ans_One_Status ==  null)
            {
                ModelState.AddModelError("", "Please Select Option about Question.1 ");
            }
            else if (info.Ans_One_Status == true && info.Ans_One_Text == null)
            {
                ModelState.AddModelError("", "Enter Name Of Person ");
            }
            else if (info.Ans_Two_Status == null)
            {
                ModelState.AddModelError("", "Please Select Option about Question.2 ");
            }
            else if (info.Ans_Two_Status == true && info.Ans_Two_Text == null)
            {
                ModelState.AddModelError("", "Enter Detail About Question.2 ");
            }
            else if (info.Ans_Three_Status == null)
            {
                ModelState.AddModelError("", "Please Select Option about Question.3 ");
            }
            else if (info.Ans_Three_Status == true && info.Ans_Three_Text == null)
            {
                ModelState.AddModelError("", "Enter Detail About Question.3 ");
            }
            else if (info.GeneralStatus == null || info.GeneralStatus == "")
            {
                ModelState.AddModelError("", "Please Accept or Decline About Profile Statement");
            }
            else {
                if (info.App_Id == null)
                {
                    info.App_Id = Convert.ToInt32(Session["App_Id"]);
                    db.tbl_GeneralInfo.Add(info);
                    db.SaveChanges();
                    return RedirectToAction("GeneralInfo");
                }
                else
                {
                    int AppId = Convert.ToInt32(Session["App_Id"]);
                    info.App_Id = AppId;
                    db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GeneralInfo");
                }
            }
            return View(info);
          
        }

        //---------------------------------------------------Resume Information---------------------------------------------
        public ActionResult ResumeInfo( string id="") {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int Id = Convert.ToInt32(Session["App_Id"]);
                if (id == "Deleted")
                {
                    ModelState.AddModelError("", "Your Resume Has Been Deleted Successfully.");
                }
            var emp = db.tbl_Resumes.SingleOrDefault(e => e.AppId == Id);
            if (emp == null)
            {
                return View();
            }

            ViewBag.check = "Yes";
            return View(emp);
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult ResumeInfo(HttpPostedFileBase file, tbl_Resumes data) {
            if (data.AppId == null)
            {

                if (data != null && file != null)
                {
                    string ResumeName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Resumes/" + Convert.ToInt32(Session["App_Id"]) + ResumeName);
                    file.SaveAs(physicalPath);
                    tbl_Resumes rdata = new tbl_Resumes();
                    rdata.ResumeUrl = (Convert.ToInt32(Session["App_Id"]) + ResumeName);
                    rdata.AppId = Convert.ToInt32(Session["App_Id"]);
                    db.tbl_Resumes.Add(rdata);
                    db.SaveChanges();
                    return RedirectToAction("ResumeInfo");
                }

            }
            else
            {
                if (data != null && file != null)
                {
                    string ResumeName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Resumes/" + Convert.ToInt32(Session["App_Id"]) + ResumeName);
                    file.SaveAs(physicalPath);
                    int AppId = Convert.ToInt32(Session["App_Id"]);
                    data.AppId = AppId;
                    data.ResumeUrl = (Convert.ToInt32(Session["App_Id"]) + ResumeName);
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("UpdateProfile", "Home");
                }
                else if (data != null && file == null)
                {
                    return RedirectToAction("ResumeInfo");
                }

            }
            return View();
        }
        public ActionResult DeleteResume(int ResId) {
            int id = Convert.ToInt32(Session["App_Id"]);
            var obj = db.tbl_Resumes.SingleOrDefault(x => x.AppId == id && x.ResumeId ==ResId);
            db.tbl_Resumes.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ResumeInfo","UpdateProfile", new {id = "Deleted" });
        }

        //---------------------------------------------------Images Information---------------------------------------------
        public ActionResult ImageInfo() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int Id = Convert.ToInt32(Session["App_Id"]);
            var emp = db.tbl_Images.SingleOrDefault(e => e.AppId == Id);
            if (emp == null)
            {
                ViewBag.check = "Yes";
                return View();
            }
            return View(emp);
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult ImageInfo(HttpPostedFileBase file, tbl_Images data) {
            if (data.AppId == null)
            {
                
                if (data != null && file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/ApplicantImages/" + Convert.ToInt32(Session["App_Id"]) + ImageName);
                    file.SaveAs(physicalPath);
                    tbl_Images imgdata = new tbl_Images();
                    imgdata.ImageUrl =(Convert.ToInt32(Session["App_Id"]) + ImageName);
                    imgdata.AppId = Convert.ToInt32(Session["App_Id"]);
                    db.tbl_Images.Add(imgdata);
                    db.SaveChanges();
                    return RedirectToAction("ImageInfo");
                }
               
            }
            else
            {
                if (data != null && file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/ApplicantImages/" + Convert.ToInt32(Session["App_Id"]) + ImageName);
                    file.SaveAs(physicalPath);
                    int AppId = Convert.ToInt32(Session["App_Id"]);
                    data.AppId = AppId;
                    data.ImageUrl = (Convert.ToInt32(Session["App_Id"]) + ImageName);
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ImageInfo");
                }
                else if(data != null && file == null)
                {
                    return RedirectToAction("ImageInfo");
                }
                
            }
            return View();
        }
        //---------------------------------------------------Career Objective---------------------------------------------
        public ActionResult CareerObjective() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int Id = Convert.ToInt32(Session["App_Id"]);
            var Data = db.tbl_CareerObjective.SingleOrDefault(e => e.App_Id == Id);
            if (Data == null)
            {
                ViewBag.check = "Yes";
                return View();
            }
            return View(Data);
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult CareerObjective(tbl_CareerObjective info) {
            if (info.CareerObjective == null) {
                ModelState.AddModelError("", "Update your Career Objective First !");
            }
            else
            {

            if (info.App_Id == null)
            {
                info.App_Id = Convert.ToInt32(Session["App_Id"]);
                db.tbl_CareerObjective.Add(info);
                db.SaveChanges();
                return RedirectToAction("CareerObjective");
            }
            else
            {
                int AppId = Convert.ToInt32(Session["App_Id"]);
                info.App_Id = AppId;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CareerObjective");
                }
            }
            return View(info);
        }
    }
}