using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTLCareerPortal.Areas.Applicant.Models
{
    public class AppliedJobs
    {
        public int id { get; set; }
        public int appId { get; set; }
        public string jobtitle { get; set; }
        public string jobtype { get; set; }
        public string cityname { get; set; }

        public DateTime applyDate { get; set; }



    }
}