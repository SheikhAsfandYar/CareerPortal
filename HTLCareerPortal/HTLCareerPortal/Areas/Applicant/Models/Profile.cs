using HTLCareerPortal.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HTLCareerPortal.Areas.Applicant.Models
{
    public class Profile
    {
        string cs = @"Data Source=Asfand\ASFAND; Initial Catalog=HTLCareerPortal; Integrated Security=True";
        public List<tbl_SignUp> GeneralInfo(int id)
        {

            List<tbl_SignUp> Data = new List<tbl_SignUp>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from tbl_SignUp Where ApplicantId ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_SignUp
                    {

                        Name = rdr["Name"].ToString(),
                        FatherName = rdr["FatherName"].ToString(),
                        EmailID = rdr["EmailID"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        Address = rdr["Address"].ToString(),
                        City = rdr["City"].ToString(),
                        CellNo = rdr["CellNo"].ToString(),
                        
                    });
                }
                return Data;
            }
        }
        public List<tbl_PersonalInfo> CompleteInfo(int id)
        {
            List<tbl_PersonalInfo> Data = new List<tbl_PersonalInfo>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from tbl_PersonalInfo Where App_Id ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_PersonalInfo
                    {

                        FirstName = rdr["FirstName"].ToString(),
                        MiddleName = rdr["MiddleName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Company = rdr["Company"].ToString(),
                        CurrentDesignation = rdr["CurrentDesignation"].ToString(),
                        CNIC = rdr["CNIC"].ToString(),
                        PostalCode = rdr["PostalCode"].ToString(),
                        DOB = Convert.ToDateTime( rdr["DOB"]),
                        PlaceOfBirth = rdr["PlaceOfBirth"].ToString(),
                        MaritalStatus = rdr["MaritalStatus"].ToString(),

                    });
                }
                return Data;
            }
        }
        public List<tbl_Education> Education(int id)
        {
            List<tbl_Education> Data = new List<tbl_Education>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from tbl_Education Where App_Id ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_Education
                    {

                        Degree = rdr["Degree"].ToString(),
                        CompletionYear = Convert.ToInt32( rdr["CompletionYear"]),
                        Institute = rdr["Institute"].ToString(),
                        Specialization = rdr["Specialization"].ToString(),
                        CGPA = rdr["CGPA"].ToString(),
                        
                    });
                }
                return Data;
            }
        }
        public List<tbl_Experience> Experience(int id)
        {
            List<tbl_Experience> Data = new List<tbl_Experience>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from tbl_Experience Where App_Id ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_Experience
                    {
                        JobTitle = rdr["JobTitle"].ToString(),
                        CompanyName = rdr["CompanyName"].ToString(),
                        CompanyAddress = rdr["CompanyAddress"].ToString(),
                        Industry = rdr["Industry"].ToString(),
                        PhoneNo = rdr["PhoneNo"].ToString(),
                        JobSpecialization = rdr["JobSpecialization"].ToString(),
                    });
                }
                return Data;
            }
        }
        public List<jobSalaryModel> JobSalary(int id)
        {
            List<jobSalaryModel> Data = new List<jobSalaryModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * from JobSalary_View Where App_Id ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new jobSalaryModel
                    {
                        FirstWorkPreference = rdr["PWT1"].ToString(),
                        SecondWorkPreference= rdr["PWT2"].ToString(),
                       ThirdWorkPreference = rdr["PWT3"].ToString(),
                        FirstPreference = rdr["FirstPreference"].ToString(),
                        SecondPreference = rdr["SecondPreference"].ToString(),
                        ThirdPreference = rdr["ThirdPreference"].ToString(),
                        CurrentSalary = rdr["CurrentSalary"].ToString(),
                        Benifits = rdr["Benifits"].ToString(),
                        ExpectedGrossSalary = rdr["ExpectedGrossSalary"].ToString(),
                    });
                }
                return Data;
            }
        }
        public List<tbl_ProfessionalReference> ProfessionalReferenceData(int id)
        {
            List<tbl_ProfessionalReference> Data = new List<tbl_ProfessionalReference>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * from tbl_ProfessionalReference Where App_Id ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_ProfessionalReference
                    {
                        Name = rdr["Name"].ToString(),
                        Relationship = rdr["Relationship"].ToString(),
                        Designation = rdr["Designation"].ToString(),
                        Organization = rdr["Organization"].ToString(),
                        ContactNo = rdr["ContactNo"].ToString(),
                    });
                }
                return Data;
            }
        }
        public List<tbl_Images> Image(int id)
        {
            List<tbl_Images> Data = new List<tbl_Images>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * from tbl_Images Where AppId ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_Images
                    {
                        ImageUrl = rdr["ImageUrl"].ToString(),
                    });
                }
                return Data;
            }
        }
        public List<tbl_CareerObjective> CareerObj(int id)
        {
            List<tbl_CareerObjective> Data = new List<tbl_CareerObjective>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * from tbl_CareerObjective Where App_Id ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_CareerObjective
                    {
                        CareerObjective = rdr["CareerObjective"].ToString(),
                    });
                }
                return Data;
            }
        }
        public List<tbl_Resumes> Resume(int id)
        {
            List<tbl_Resumes> Data = new List<tbl_Resumes>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * from tbl_Resumes Where AppId ='" + id + "'", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new tbl_Resumes
                    {
                        ResumeUrl = rdr["ResumeUrl"].ToString(),
                    });
                }
                return Data;
            }
        }
        public List<Joblist> Jobs()
        {
            List<Joblist> Data = new List<Joblist>();
            string cs1 = @"Data Source=Asfand\ASFAND; Initial Catalog=HTLCareerPortal; Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("HrGetJob", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", 0);
                //com.Parameters.AddWithValue("@search", search);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new Joblist
                    {
                        jobId = Convert.ToInt32(rdr["pk"]),
                        JobTile = rdr["JobTitle"].ToString(),
                        JobType = rdr["JobType"].ToString(),
                        CityName = rdr["cityName"].ToString()
                    });
                }
                return Data;
            }
        }
        public List<Joblist> JobSearch(string search)
        {
            List<Joblist> Data = new List<Joblist>();
            string cs1 = @"Data Source=Asfand\ASFAND; Initial Catalog=HTLCareerPortal; Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("HrJobSearch", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@search", search);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new Joblist
                    {
                        jobId = Convert.ToInt32(rdr["pk"]),
                        JobTile = rdr["JobTitle"].ToString(),
                        JobType = rdr["JobType"].ToString(),
                        CityName = rdr["cityName"].ToString()
                    });
                }
                return Data;
            }
        }
        public List<Joblist> JobDetail(int id)
        {
            List<Joblist> Data = new List<Joblist>();
            string cs1 = @"Data Source=Asfand\ASFAND; Initial Catalog=HTLCareerPortal; Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("HrGetJob", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new Joblist
                    {
                        jobId =Convert.ToInt32( rdr["pk"]),
                        JobTile = rdr["JobTitle"].ToString(),
                        ScopeResponse = rdr["ScopeOfResponsibility"].ToString(),
                        Experience = rdr["Experience"].ToString(),
                        Education = rdr["Education"].ToString(),
                        SkillsRequired = rdr["SkillsRequired"].ToString(),
                        CityName = rdr["cityName"].ToString(),
                        compensationBenifits = rdr["CompensationBenefits"].ToString()
                    });
                }
                return Data;
            }
        }
        public List<AppliedJobs> appliedjobs(int id)
        {
            List<AppliedJobs> Data = new List<AppliedJobs>();
            string cs1 = @"Data Source=Asfand\ASFAND; Initial Catalog=HTLCareerPortal; Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs1))
            {
                con.Open();
                SqlCommand com = new SqlCommand("HrAppliedJobs", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new AppliedJobs
                    { 
                        id = Convert.ToInt32(rdr["pk"]),
                        appId = Convert.ToInt32(rdr["App_Id"]),
                        jobtitle = rdr["JobTitle"].ToString(),
                        jobtype = rdr["JobType"].ToString(),
                        cityname = rdr["cityName"].ToString(),
                        applyDate = Convert.ToDateTime( rdr["ApplyDate"]),

                    });
                }
                return Data;
            }
        }
        //----------------------------------------- JOB STATUS FUNCTION THAT AUTOMATICALLY UPDATE ITS STATUS ACTIVE OR INACTIVE

        //public void updatejobstatus()
        //{
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("UPDATE JobSetup set JobStatus ='ACTIVE' where JobClosingDate > '"+ DateTime.Now +"' AND JobStatus='INACTIVE'", con);
        //        com.CommandType = CommandType.Text;
        //        com.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("UPDATE JobSetup set JobStatus ='INACTIVE' where JobClosingDate < '" + DateTime.Now + "' AND JobStatus='INACTIVE'", con);
        //        com.CommandType = CommandType.Text;
        //        com.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
        //----------------------------------------- JOB STATUS FUNCTION THAT AUTOMATICALLY UPDATE ITS STATUS ACTIVE OR INACTIVE
        public List<AppliedFor> ApplicantsAppliedForAll()
        {
            List<AppliedFor> Data = new List<AppliedFor>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from ViewAppliedApplicants", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new AppliedFor
                    {
                        App_Id = Convert.ToInt32(rdr["App_Id"]),
                        ApplicantName = rdr["Name"].ToString(),
                        ApplicantEmail = rdr["EmailID"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        City = rdr["City"].ToString(),
                        JobId = Convert.ToInt32(rdr["JobId"]),
                        JobTitle = rdr["JobTitle"].ToString(),
                        CurrentSalary = rdr["CurrentSalary"].ToString(),
                        ExpectedSalary = rdr["ExpectedGrossSalary"].ToString(),
                        Company = rdr["Company"].ToString(),
                        CurrentDesignation = rdr["CurrentDesignation"].ToString(),
                        DepartmentId = Convert.ToInt32(rdr["Department"]),
                        applyDate = Convert.ToDateTime(rdr["ApplyDate"]),
                        CellNo = rdr["CellNo"].ToString(),
                        Resume = rdr["ResumeUrl"].ToString()
                    });
                }
                return Data;
            }
        }
        public List<AppliedFor> ApplicantsAppliedForFiltered(int JobTitle , int DepartmentId , string City , string Gender , string DateFrom , string DateTo, int CurrentSalary, int ExpectedSalary, string keywords )
        {
            List<AppliedFor> Data = new List<AppliedFor>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int count = 0;
                string query = "SELECT * from ViewAppliedApplicants  Where ";
                if (JobTitle != 0)
                {
                    count++;
                    query += " JobId ='" + JobTitle + "' ";
                }
                if (DepartmentId != 0) {
                    
                    if (count > 0)
                    { 
                        query += "AND ";               
                    }
                    count++;
                    query += " Department = '" + DepartmentId + "' ";
                }
                if (City != "")
                {

                    if (count > 0)
                    {
                        query += "AND ";      
                    }
                    count++;
                    query += " City ='" + City + "' ";
                }
                if (Gender != "")
                {

                    if (count > 0)
                    {
                        query += "AND ";
                    }
                    count++;
                    query += " Gender ='" + Gender + "' ";
                }
                if (CurrentSalary != 0)
                {

                    if (count > 0)
                    {
                        query += "AND ";

                    }
                    count++;
                    query += " CurrentSalary <=" + CurrentSalary + " ";
                }
                if (ExpectedSalary != 0)
                {

                    if (count > 0)
                    {
                        query += "AND ";

                    }
                    count++;
                    query += " ExpectedGrossSalary <=" + ExpectedSalary + "";
                }
               
                if (DateFrom !="")
                {

                    if (count > 0)
                    {
                        query += "AND ";
                       
                    }
                    count++;
                    query += " ApplyDate >='" + DateFrom + "' ";
                }
                if (DateTo != "")
                {

                    if (count > 0)
                    {
                        query += "AND ";
                     
                    }
                    count++;
                    query += " ApplyDate <='" +Convert.ToDateTime(DateTo).AddDays(+1) + "' ";
                }
                if (keywords != "")
                {

                    if (count > 0)
                    {
                        query += "AND ";
                    }
                    count++;
                    query += "( Keyword1 like'%" + keywords + "%' ";
                }
                if (keywords != "")
                {

                    if (count > 0)
                    {
                        query += "OR ";
                    }
                    count++;
                    query += " Keyword2 like'%" + keywords + "%' ";
                }
                if (keywords != "")
                {

                    if (count > 0)
                    {
                        query += "OR ";
                    }
                    count++;
                    query += " Keyword3 like'%" + keywords + "%' )";
                }

                con.Open();
                SqlCommand com = new SqlCommand();
                //if (JobTitle != 0 && DepartmentId != 0 && City != "" && Gender != "" && DateFrom != "" & DateTo != "") {
                //     com = new SqlCommand("SELECT * from ViewAppliedApplicants  Where JobId ='" + JobTitle + "' AND Department ='"+ DepartmentId+ "' AND City ='" + City + "' AND Gender ='" + Gender + "' AND ApplyDate >='" + DateFrom + "' AND ApplyDate <='" + DateTo + "'", con);
                //}
                com = new SqlCommand(query, con);
                
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    Data.Add(new AppliedFor
                    {
                        App_Id = Convert.ToInt32(rdr["App_Id"]),
                        ApplicantName = rdr["Name"].ToString(),
                        ApplicantEmail = rdr["EmailID"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        City = rdr["City"].ToString(),
                        JobId = Convert.ToInt32(rdr["JobId"]),
                        JobTitle = rdr["JobTitle"].ToString(),
                        CurrentSalary = rdr["CurrentSalary"].ToString(),
                        ExpectedSalary = rdr["ExpectedGrossSalary"].ToString(),
                        Company = rdr["Company"].ToString(),
                        CurrentDesignation = rdr["CurrentDesignation"].ToString(),
                        DepartmentId = Convert.ToInt32(rdr["Department"]),
                        applyDate = Convert.ToDateTime(rdr["ApplyDate"]),
                        CellNo = rdr["CellNo"].ToString(),
                        Resume = rdr["ResumeUrl"].ToString()

                    });
                }
                return Data;
            }
        }
    }
}
