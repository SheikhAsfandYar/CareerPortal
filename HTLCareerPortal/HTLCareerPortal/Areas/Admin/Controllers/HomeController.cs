using HTLCareerPortal.Areas.Applicant.Models;
using System;
using System.Linq;
using System.IO;
using System.Data;
using System.Web.Mvc;
using HTLCareerPortal.Areas.Admin.Models;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace HTLCareerPortal.Areas.Admin.Controllers
{
    
    [HandleError]
    public class HomeController : Controller
    {
        HTLCareerEntities db = new HTLCareerEntities();
        static List<AppliedFor> selectedforHod = new List<AppliedFor>();
        Profile Data = new Profile();

        public ActionResult Dashboard() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin")
            {
                ViewBag.TotalJobs = db.JobSetups.Where(x => x.JobStatus == "ACTIVE").Count();
                ViewBag.TotalApplicants = db.tbl_SignUp.Count();

                return View(db.JobSetups.Where(x => x.JobStatus == "ACTIVE").ToList());
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
            }
        //------------------------------------------------------------------Find Now
        // GET: Admin/Home
        public ActionResult Index(string Keywords="", int CurrentSalary=0,int ExpectedSalary=0,int JobTitle = 0, int DepartmentId = 0, string City = "", string Gender = "", string DateFrom = "", string DateTo = "")
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin")
            {
                if (Keywords=="" && CurrentSalary == 0 && ExpectedSalary ==0 && JobTitle == 0 && DepartmentId == 0 && City == "" && Gender == "" && DateFrom == "" && DateTo == "")
            {
                ViewBag.JobTitles = new SelectList(db.JobSetups.Where(x => x.JobStatus == "ACTIVE").ToList(), "pk", "JobTitle");
                ViewBag.Department = new SelectList(db.tbl_Department.ToList(), "DepId", "DepName");
                    ViewBag.Hodlist = new SelectList(db.tbl_Department.ToList(), "DepId", "DepHod");
                    //ViewBag.City = new SelectList(db.citySetups.ToList(), "cityCode", "cityName");
                    return View(Data.ApplicantsAppliedForAll());
                }
            else {
                ViewBag.JobTitles = new SelectList(db.JobSetups.Where(x=>x.JobStatus=="ACTIVE").ToList(), "pk", "JobTitle");
                ViewBag.Department = new SelectList(db.tbl_Department.ToList(), "DepId", "DepName");
                    ViewBag.Hodlist = new SelectList(db.tbl_Department.ToList(), "DepId", "DepHod");
                    //ViewBag.City = new SelectList(db.citySetups.ToList(), "cityCode", "cityName");
                    return View(Data.ApplicantsAppliedForFiltered(JobTitle,DepartmentId,City,Gender, DateFrom.ToString(), DateTo.ToString(), CurrentSalary, ExpectedSalary,Keywords));
                }
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult Excel(string Keywords,int CurrentSalary=0, int ExpectedSalary=0,int JobTitle = 0, int DepartmentId = 0, string City = "", string Gender = "", string DateFrom = "", string DateTo = "")
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin")
            {
                DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[12] {new DataColumn("Job Title"),
                                             new DataColumn("Applicant Name"),
                                            new DataColumn("Email"),
                                            new DataColumn("City"),
                                            new DataColumn("Apply Date"),
                                            new DataColumn("Gender"),
                                            new DataColumn("Cell No"),
                                            new DataColumn("Company"),
                                            new DataColumn("Current Designation"),
                                            new DataColumn("Current Salary"),
                                            new DataColumn("Expected Gross Salary"),
                                             new DataColumn("Resumes")

            });
            var info = Data.ApplicantsAppliedForAll();
            if (Keywords=="" && ExpectedSalary==0 && CurrentSalary==0  && JobTitle == 0 && DepartmentId == 0 && City == "" && Gender == "" && DateFrom == "" && DateTo == "")
            {
                info = Data.ApplicantsAppliedForAll();
            }
            else
            {
                   // Data.ApplicantsAppliedForFiltered(JobTitle, DepartmentId, City, Gender, DateFrom.ToString(), DateTo.ToString(), CurrentSalary, ExpectedSalary, Keywords)
                info = Data.ApplicantsAppliedForFiltered(JobTitle, DepartmentId, City, Gender, DateFrom.ToString(), DateTo.ToString(), CurrentSalary, ExpectedSalary, Keywords).ToList();
            }
              
                foreach (var list in info)
            {
                dt.Rows.Add(list.JobTitle,list.ApplicantName, list.ApplicantEmail, list.City, list.applyDate, list.Gender,list.CellNo,list.Company,list.CurrentDesignation,list.CurrentSalary,list.ExpectedSalary,list.Resume);
                    
                     
                }

            using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
            {
                    int a = 1;
                    var ws = wb.Worksheets.Add("Hyperlinks");
                    ws.Cell(a, 1).Value = "JOB TITLE";
                    //ws.Cell(a, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Justify;
                    ws.Cell(a, 2).Value = "APPLICANT NAME";
                    ws.Cell(a, 3).Value = "EMAIL ID";
                    ws.Cell(a, 4).Value = "CITY";
                    ws.Cell(a, 5).Value = "APPLY DATE";
                    ws.Cell(a, 6).Value = "GENDER";
                    ws.Cell(a, 7).Value = "CELL NO";
                    ws.Cell(a, 8).Value = "COMPANY";
                    ws.Cell(a, 9).Value = "CURRENT DESIGNATION";
                    ws.Cell(a, 10).Value = "SALARY";
                    ws.Cell(a, 11).Value = "EXPECTED SALARY";
                    ws.Cell(a, 12).Value = "RESUME/CV";
                    for (int i = 0; i <= dt.Rows.Count-1; i++)
                    {
                        
                        a++;
                    
                        ws.Cell(a, 1).Value = dt.Rows[i]["Job Title"];
                        ws.Cell(a, 2).Value = dt.Rows[i]["Applicant Name"];
                        ws.Cell(a, 3).Value = dt.Rows[i]["Email"];
                        ws.Cell(a, 4).Value = dt.Rows[i]["City"];
                        ws.Cell(a, 5).Value = dt.Rows[i]["Apply Date"];
                        ws.Cell(a, 6).Value = dt.Rows[i]["Gender"];
                        ws.Cell(a, 7).Value = dt.Rows[i]["Cell No"];
                        ws.Cell(a, 8).Value = dt.Rows[i]["Company"];
                        ws.Cell(a, 9).Value = dt.Rows[i]["Current Designation"];
                        ws.Cell(a, 10).Value = dt.Rows[i]["Current Salary"];
                        ws.Cell(a, 11).Value = dt.Rows[i]["Expected Gross Salary"];
                        ws.Cell(a, 12).Value = "Resume";
                        ws.Cell(a, 12).Hyperlink = new XLHyperlink(@"file:///C:\Users\Asfands\Downloads\" + dt.Rows[i]["Resumes"] + "");
                    }
                    //  wb.Worksheets.Add(dt);
                    ws.FirstRow().Style.Font.Bold = true;
                    ws.FirstRow().Style.Font.FontSize = 12;
                    ws.FirstRow().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Columns().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    ws.Columns().AdjustToContents();

                    
                    using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Applicants.xlsx");
                }

            }
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        //--------------------------------------------------------------------------------------
        public ActionResult Applicants(string Gender="" , string Email="") {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin") {
                if (Gender == ""  && Email == "")
                {
                    return View(db.tbl_SignUp.Where(x => x.UserType == "Applicant").ToList());
                }
                else if (Gender != "" && Email == "" )
                {
                    return View(db.tbl_SignUp.Where(x => x.UserType == "Applicant" && x.Gender == Gender).ToList());
                }
                else if (Gender == "" && Email != "")
                {
                    return View(db.tbl_SignUp.Where(x => x.UserType == "Applicant" && x.EmailID.Contains( Email)).ToList());
                }
                else {
                    return View(db.tbl_SignUp.Where(x => x.UserType == "Applicant" && x.EmailID.Contains(Email) && x.Gender == Gender).ToList());
                }
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }

        public ActionResult ApplicantProfile(int id =0) {
            if (Session["App_Id"] != null && (Session["UserType"].ToString() =="Admin" || Session["UserType"].ToString() == "Hod"))
            {
                Session["profileId"] = id;
                return View();
            }
        
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public JsonResult SignUp()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.GeneralInfo(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult PersonalInfo()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.CompleteInfo(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Education()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.Education(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Experience()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.Experience(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult JobSalary()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.JobSalary(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProfessionalReference()
        {

            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.ProfessionalReferenceData(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Image()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.Image(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CareerObjective()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.CareerObj(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Resume()
        {
            int id = Convert.ToInt32(Session["profileId"]);

            return Json(Data.Resume(id), JsonRequestBehavior.AllowGet);
        }


        //----------------------------------------------------------------------------------------------
        public JsonResult PassToHod(AppliedFor info)
        {

            if (info.DepartmentId == 0)
            {
                return Json(new { success = true, responseText = "empty" }, JsonRequestBehavior.AllowGet);
            }
            var obj = db.tbl_AdminToHod.Where(x => x.JobId == info.JobId && x.AppId == info.App_Id && x.DepId == info.DepartmentId).SingleOrDefault();
            if (obj == null)
            {
                tbl_AdminToHod data = new tbl_AdminToHod();
                data.JobId = info.JobId;
                data.AppId = info.App_Id;
                data.DepId = info.DepartmentId;
                db.tbl_AdminToHod.Add(data);
                db.SaveChanges();
                return Json(new { success = true, responseText = "no" }, JsonRequestBehavior.AllowGet);

            }
            else
            {

                return Json(new { success = true, responseText = "yes" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult AdminToHod() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin")
            {
                return View(db.tbl_AdminToHod.ToList());
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult DelAdminToHod(int id) {
            var data = db.tbl_AdminToHod.SingleOrDefault(x => x.ATHid.Equals(id));
            db.tbl_AdminToHod.Remove(data);
            db.SaveChanges();
            return RedirectToAction("AdminToHod");
        }
        //-------------------------------------------------------------Department Setup-----------------------------------------

        public ActionResult DepartmentList() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin")
            {
                return View(db.tbl_Department.ToList());
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        public ActionResult AddDepartment() {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult AddDepartment(tbl_Department data) {

            if (data.DepName == null || data.DepName == "")
            {
                ModelState.AddModelError("", "Enter Department Name First");
                return View();
            }
            else if (data.DepHod == null || data.DepHod == "") {
                ModelState.AddModelError("", "Enter Department HOD Name First.");
                return View();
            }
            else { 
            db.tbl_Department.Add(data);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
            }
        }
        public ActionResult UpdateDepartment(int id) {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Admin")
            {
                return View(db.tbl_Department.Where(x=>x.DepId==id).SingleOrDefault());
        }
            else
            {
                return RedirectToAction("login", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult UpdateDepartment(tbl_Department data) {
            if (data.DepName == null || data.DepName == "")
            {
                ModelState.AddModelError("", "Enter Department Name First");
                return View();
            }
            else if (data.DepHod == null || data.DepHod == "")
            {
                ModelState.AddModelError("", "Enter Department HOD Name First.");
                return View();
            }
            else
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DepartmentList");
            }
        }
        public ActionResult RemoveDepartment(int id) {
            var obj = db.tbl_Department.SingleOrDefault(x => x.DepId == id);
            db.tbl_Department.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        //----------------------------------------------------------------SHortlisted / Rejected Lists

        public ActionResult Shortlisted(int id = 0) {
            return View(db.tbl_AdminToHod.Where(x=>x.Status == true).ToList());
        }
        public ActionResult Rejected(int id = 0)
        {
            return View(db.tbl_AdminToHod.Where(x => x.Status == false).ToList());
        }
    }
}