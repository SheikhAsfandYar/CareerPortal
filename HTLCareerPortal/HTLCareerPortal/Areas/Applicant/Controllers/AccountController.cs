using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace HTLCareerPortal.Areas.Applicant.Controllers
{
    [HandleError()]
    public class AccountController : Controller
    {
        HTLCareerEntities db = new HTLCareerEntities();
        // GET: Applicant/Account
        public ActionResult AccountDetail()
        {
            if (Session["App_Id"] != null && Session["UserType"].ToString() == "Applicant")
            {
                int Id = Convert.ToInt32(Session["App_Id"]);
            var Data = db.tbl_SignUp.SingleOrDefault(e => e.ApplicantId == Id);
            if (Data == null)
            {
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
        public ActionResult AccountDetail(tbl_SignUp data , string re_pass) {
            string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(emailRegex);
            if (ModelState.IsValid)
            {

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
              
                else if (re_pass == null || re_pass == "")
                {
                    ModelState.AddModelError("", "Please Enter Your Password To Update !");
                }
                //else if (data.Password == null)
                //{
                //    ModelState.AddModelError("", "Please Enter Your New Password  !");
                //}
                else if (data.Name != null && data.FatherName != null && data.Gender != null && data.Address != null && data.City != null && data.EmailID != null && data.CellNo != null )
                {

                    int id = Convert.ToInt32(Session["App_Id"]);
                    var obj = db.tbl_SignUp.Where(a => a.Password == data.Password && a.ApplicantId == id).Any();
                    if (obj != null)
                    {
                        //int AppId = Convert.ToInt32(Session["App_Id"]);
                        //obj.ApplicantId = AppId;
                        //obj.Name = data.Name;
                        //obj.FatherName = data.FatherName;
                        //obj.Password = data.Password;
                        //obj.Gender = data.Gender;
                        //obj.EmailID = data.EmailID;
                        //obj.City = data.City;
                        //obj.CellNo = data.CellNo;
                        //obj.UserType = "Applicant";
                        //obj.Address = data.Address;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ModelState.AddModelError("", "Successfully Updated !");
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password is not Valid, Enter Correct Password ! ");
                        return View();
                    }

                }
                else
                    return View();
            }
            return View();

        }
        public ActionResult Updatepassword() {
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
        public ActionResult Updatepassword(tbl_SignUp data, string New_pass , string re_pass) {
            if (data.Password == null)
            {
                ModelState.AddModelError("", "Enter Your Password First");
            }
            else if (New_pass == null || New_pass == "")
            {
                ModelState.AddModelError("", "Enter Your New Password First");
                return View(data);
            }
            else if (re_pass == null || re_pass == "")
            {
                ModelState.AddModelError("", "Re-Type Your  Password First");
                return View(data);
            }
            else if (re_pass != New_pass)
            {
                ModelState.AddModelError("", "You New Password is not Matched with Re-Type Password.");
                return View(data);
            }
            else { 
            int id = Convert.ToInt32(Session["App_Id"]);
            var obj = db.tbl_SignUp.Where(a => a.Password == data.Password && a.ApplicantId == id ).FirstOrDefault();
            if (obj != null)
            { 
                obj.Password = New_pass;
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ModelState.AddModelError("", "Your Password has been Updated Succesfully.");
            }
            else
            {
                ModelState.AddModelError("", "Your Entered Password is Incorrect. Please Enter your Correct Password to Update New.");
            }
            }
            return View();
        }
    }
}