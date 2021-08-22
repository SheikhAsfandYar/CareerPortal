using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
namespace HTLCareerPortal.Controllers
{
    [HandleError()]
    public class HomeController : Controller
    {
        HTLCareerEntities db = new HTLCareerEntities();
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(tbl_SignUp data, string re_pass) {
            string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                       @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(emailRegex);
            if (ModelState.IsValid) {

                if (data.Name == null)
                {
                    ModelState.AddModelError("", "Please Enter Name First !");
                }
                else if (data.FatherName == null)
                {
                    ModelState.AddModelError("", "Please Enter Your Father Name First !");
                }
                else if (data.Gender == null)
                {
                    ModelState.AddModelError("", "Please Select Your Gender First !");
                }
                else if (data.Address == null)
                {
                    ModelState.AddModelError("", "Please Enter Your Address First !");
                }
                else if (data.City == null)
                {
                    ModelState.AddModelError("", "Please Enter Your City Name First !");
                }
                else if (!re.IsMatch(data.EmailID))
                {
                        ModelState.AddModelError("", "Email is not valid");
                }
                else if (data.EmailID == null)
                {
                    ModelState.AddModelError("", "Please Enter Email First !");
                }
                else if (data.CellNo == null)
                {
                    ModelState.AddModelError("", "Please Enter Your Cell No Name First !");
                }
                else if (data.Password == null)
                {
                    ModelState.AddModelError("", "Please Enter Your Password  First !");
                }
                else if (re_pass == null)
                {
                    ModelState.AddModelError("", "Please Re-type Your Password  First !");
                }
                else if (data.Password != re_pass)
                {
                    ModelState.AddModelError("", "Your Password not Matched Enter Again!");
                }
                else if (data.Name != null && data.FatherName != null && data.Gender != null && data.Address != null && data.City != null && data.EmailID != null && data.CellNo != null && data.Password != null && data.Password == re_pass)
                {

                    var obj = db.tbl_SignUp.Where(a => a.EmailID == data.EmailID).FirstOrDefault();
                    if (obj == null)
                    {
                        data.UserType = "Applicant";
                        db.tbl_SignUp.Add(data);
                        db.SaveChanges();
                        return RedirectToAction("login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email is Already Existing. Try other Email to Register ! ");
                        return View();
                    }

                }
                else
                    return View();
            }
            return View();

        }
        public ActionResult login(Boolean Remember = false)
        {
            tbl_SignUp obj = new tbl_SignUp();
            if (Request.Cookies["Email"] != null && Request.Cookies["Pass"] != null) {
                obj.EmailID = Request.Cookies["Email"].Value;
                obj.Password = Request.Cookies["Pass"].Value;
                Remember = true;
            }
            return View(obj);

        }
        [HttpPost]
        public ActionResult login(tbl_SignUp objUser, Boolean Remember=false)
        {
            using (HTLCareerEntities db = new HTLCareerEntities())
            {
                //var pass = objUser.password.ToString();
                var obj = db.tbl_SignUp.Where(a => a.EmailID.Equals(objUser.EmailID) && a.Password.Equals(objUser.Password)).FirstOrDefault();

                if (obj != null)
                {
                    if (Remember == true)
                    {
                        Response.Cookies["Email"].Value = objUser.EmailID;
                        Response.Cookies["Pass"].Value = objUser.Password;
                        Response.Cookies["Email"].Expires = DateTime.Now.AddMonths(2);
                        Response.Cookies["Pass"].Expires = DateTime.Now.AddMonths(2);
                    }
                    else {
                        Response.Cookies["Email"].Expires = DateTime.Now.AddMonths(-1);
                        Response.Cookies["Pass"].Expires = DateTime.Now.AddMonths(-1);
                    }
                    Session["App_Id"] = obj.ApplicantId;
                    Session["UserID"] = obj.EmailID;
                    Session["UserName"] = obj.Name;
                    Session["UserType"] = obj.UserType;
                    Session["PI_Id"] = db.tbl_PersonalInfo.Where(x => x.App_Id == (obj.ApplicantId)).Select(x => x.PI_Id).SingleOrDefault();
                    if (obj.UserType == "Applicant")
                    {
                        return RedirectToAction("Index", "Home", new { area = "Applicant" });
                    }
                   else if (obj.UserType == "Admin")
                    {
                        return RedirectToAction("Dashboard", "Home", new { area = "Admin" });
                    }
                    else if (obj.UserType == "Hod")
                    {
                        return RedirectToAction("Index", "Home", new { area = "HOD" });
                    }

                }
                else
                    ModelState.AddModelError("", "Please Enter Correct Credentials ! Incorrect Email OR Password");
            }
            return View();
        }
        public ActionResult logout()
        {
            Session["App_Id"] = null;
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["UserType"] = null;
            Session["PI_Id"] = null;
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("login", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}