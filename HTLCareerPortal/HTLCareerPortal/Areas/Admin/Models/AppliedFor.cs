using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTLCareerPortal.Areas.Admin.Models
{
    public class AppliedFor
    {
        public int App_Id { get; set; }
        public String ApplicantName { get; set; }
        public String ApplicantEmail { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public string CurrentSalary { get; set; }
        public string ExpectedSalary { get; set; }
        public string Company { get; set; }
        public string CurrentDesignation { get; set; }
        public string CellNo { get; set; }
        public DateTime applyDate { get; set; }

        public string Resume { get; set; }
    }
}