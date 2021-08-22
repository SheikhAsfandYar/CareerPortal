using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTLCareerPortal.Areas.Applicant.Models
{
    public class jobSalaryModel
    {
        public int App_Id { get; set; }
        public string FirstWorkPreference { get; set; }
        public string SecondWorkPreference { get; set; }
        public string ThirdWorkPreference { get; set; }
        public string FirstPreference { get; set; }
        public string SecondPreference { get; set; }
        public string ThirdPreference { get; set; }
        public string Benifits { get; set; }
        public string CurrentSalary { get; set; }
        public string ExpectedGrossSalary { get; set; }

    }
}